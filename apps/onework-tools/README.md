# OneWork-Tools
# 一、概述
# 二、场景
（1）启动注册模块，其中包括模块中功能、异常、接口等信息

（2）启动初始化数据库结构，后续启动如何迁移数据库脚本

（3）

# 三、功能
## （1）基础
onework-tools-core

系统日志

数据日志







## （2）模块
onework-tools-module

onework-tools-identity

onework-tools-organization

部门

职务

onework-tools-authorize

角色

onework-tools-dictionary

数据字典

分类字典

onework-tools-file

onework-tools-flow

流程

onework-tools-form

表单

onework-tools-message

系统通告

消息

通知

## （3）辅助
onework-tools-generator

onework-tools-database

onework-tools-model

onework-tools-translate

# 四、插件
Spring Boot

lombok

org.apdplat.word

mybatis-plus

com.alibaba.fastjson

p6spy

mysql

# 五、过程
## （1）各类关系型数据库JDBC驱动及版本兼容
|排名|数据库|类型|得分|
| ----- | ----- | ----- | ----- |
|1|Oracle|关系型数据库|1345.00|
|2|MySQL|关系型数据库|1241.64|
|3|Microsoft SQL Server|关系型数据库|1037.64|
|4|PostgreSQL|关系型数据库|555.06|
|5|MongoDB|文档数据库|453.83|
|6|IBM Db2|关系型数据库|161.62|
|7|Redis|键值对（Key-value）数据库|155.42|
|8|Elasticsearch|搜索和数据分析引擎|151.55|
|9|SQLite|关系型数据库|123.31|
|10|Microsoft Access|关系型数据库|118.75|

## （2）领域模式划分项目层次结构，考虑代码生成器代码与业务代码合理
**onework-tools-core 层**

> 提供：eventbus、chche、job、message、log、authorize、authority 功能

**onework-tools-generator 层**

> 附属功能独立包，代码生成器工具

**onework-tools-domain 层**

> 领域服务包，包括各种业务功能实现，例如：用户身份验证、权限管理、数据库同步（database）、模型管理（model）等

**onework-tools-server 层**

> 提供web api或系统服务的数据支撑，面向具体终端，依赖domain层，结合mybaits实现domain层定义接口规范，同时提供终端数据组装

**onework-tools-web-api 层**

> 提供具体服务restfull api接口，同时包括各模块具体测试类和相关配置

## （3）多模块中Maven如何进行版本管理
通过Maven的POM文件继承功能，建立根POM，将版本放在properties标签中集中配置，dependencyManagement管理依赖包，dependencyManagement中依赖包版本通过\${xxx.version}进行配置，其他模块中POM文件直接在dependencies标签填写groupId、artifactId标签内容，这样其他模块POM文件继承根POM的版本

其中子模块只能有一个parent标签，导致springboot parent无法导入，可以使用spring-boot-dependencies方式解决

**根POM文件**

![image](images/iFlUbf3gXlyFHQilWEwSOPYOEraTVklgWJB6qvTJPOM.png)

**子项目：**

![image](images/1kVvWE0YwMnJpoCdnyv9Zwwhef8s2aZbKsHfvX-Ry7s.png)

## （4）如何简化Mybaits plus代码生成工具参数
利用构建者模式方进行构建，将参数封装Bean（get和set赋值和取值），便于后续提供外部接口

```java
GeneratorConfigValue generatorConfigValue = new GeneratorConfigValue();

        generatorConfigValue.getPackageConfigValue()
            .setParent("com.onework.tools.server")
            .setModuleName("database");

        generatorConfigValue.getTemplateConfigValue()
            .setDisableController(true);

        generatorConfigValue.getStrategyConfigValue()
            .setAddTablePrefix(new String[] { "ow_" })
            .setAddTableSuffix(new String[] { "s" })
            .setEnableCapitalMode(true)
            .setLikeTable(new LikeTable("database"))
        .getEntityBuilder()
            .setIdType(IdType.ASSIGN_ID)
            .setNaming(NamingStrategy.underline_to_camel)
            .setColumnNaming(NamingStrategy.underline_to_camel)
            .setLogicDeleteColumnName("deleted_at")
            .setEnableTableFieldAnnotation(true)
            .setAddTableFills( new IFill[] {
                    new Column("created_at", FieldFill.INSERT),
                    new Column("updated_at", FieldFill.INSERT_UPDATE),
                    new Column("deleted_at", FieldFill.DEFAULT),
            })
            .setEnableLombok(true).setEnableChainModel(true);

        GeneratorTool generatorTool = new GeneratorTool(fastAutoGenerator, generatorConfigValue);
        generatorTool.execute();
```
## （5）如何利用线程池高效执行批量数据插入
hutool工具类进行集合分页，利用ThreadPoolExecutor管理线程池，同时考虑数据库事务的阻塞

```java
final int pageSize = 10;
        int pageCount = (tables.size() + pageSize - 1) / pageSize;
        ThreadPoolExecutor threadPoolExecutor = ThreadUtil.newExecutor(pageCount, pageCount);
        for (int i = 0; i < pageCount; i++) {
            int page = i;
            threadPoolExecutor.execute(() -> {
                //                // 1.获取事务定义
                //                DefaultTransactionDefinition def = new DefaultTransactionDefinition();
                //                // 2.设置事务隔离级别，开启新事务
                //                def.setPropagationBehavior(TransactionDefinition.PROPAGATION_REQUIRES_NEW);
                //                TransactionStatus status = dataSourceTransactionManager.getTransaction(def);
                try {
                    List<Table> pageTables = CollUtil.page(page, pageSize, tables);
                    handleColumns(dbSchemaServer, pageTables);
                } catch (Exception ex) {
                    // dataSourceTransactionManager.rollback(status);
                    log.error(String.format("%s：批量提交失败", Thread.currentThread().getName()), ex);
                }
                // 3.提交事务
                //dataSourceTransactionManager.commit(status);
            });
        }
        while (true) {
            int count = threadPoolExecutor.getActiveCount();
            if (count == 0) {
                database.setLastSyncDate(LocalDateTime.now());
                database.setIsSync(true);
                databaseRepository.updateDatabase(database);
                threadPoolExecutor.shutdown();

                return executeResult.ok();
            }
        }
```
## （6）Mybaits plus 中如何手动控制事务操作
```java
// 1.获取事务定义
DefaultTransactionDefinition def = new DefaultTransactionDefinition();
// 2.设置事务隔离级别，开启新事务
def.setPropagationBehavior(TransactionDefinition.PROPAGATION_REQUIRES_NEW);
TransactionStatus status = dataSourceTransactionManager.getTransaction(def);
```
## （7）各类DTO数据映射，例如DTO、DAO、POCO对象之间转换工具
hutool中BeanUtil中的BeanUtil.copyProperties方法进行转换，减少手动赋值，后续考虑mapstruct

```java
    public static Column getColumn(DataColumn dataColumn, Table table) {

        Column column = BeanUtil.copyProperties(dataColumn, Column.class);
        column.setCnUid(table.getCnUid());
        column.setDbUid(table.getDbUid());
        column.setDbName(table.getDbName());
        column.setTbUid(table.getUid());
        column.setTbName(table.getName());
        return column;
    }
```
## （8）利用 p6spy包对sql语句分析与调试，Mppper批量时候生成具体sql语句
```xml
            <dependency>
                <groupId>p6spy</groupId>
                <artifactId>p6spy</artifactId>
                <version>3.9.1</version>
            </dependency>
```
**spy.properties文件**

```xml
#3.2.1以上使用
modulelist=com.baomidou.mybatisplus.extension.p6spy.MybatisPlusLogFactory,com.p6spy.engine.outage.P6OutageFactory
#3.2.1以下使用或者不配置
#modulelist=com.p6spy.engine.logging.P6LogFactory,com.p6spy.engine.outage.P6OutageFactory
# 自定义日志打印
logMessageFormat=com.baomidou.mybatisplus.extension.p6spy.P6SpyLogger
#日志输出到控制台
appender=com.baomidou.mybatisplus.extension.p6spy.StdoutLogger
# 使用日志系统记录 sql
#appender=com.p6spy.engine.spy.appender.Slf4JLogger
# 设置 p6spy driver 代理
deregisterdrivers=true
# 取消JDBC URL前缀
useprefix=true
# 配置记录 Log 例外,可去掉的结果集有error,info,batch,debug,statement,commit,rollback,result,resultset.
excludecategories=info,debug,result,commit,resultset
# 日期格式
dateformat=yyyy-MM-dd HH:mm:ss
# 实际驱动可多个
#driverlist=org.h2.Driver
# 是否开启慢SQL记录
outagedetection=true
# 慢SQL记录标准 2 秒
outagedetectioninterval=2
```
## （9）统一异常编码管理，如何划分各模块不同异常以及异常消息的集中管理
**基础异常**

```java
public abstract class BaseException extends RuntimeException {

    private static final long serialVersionUID = 7969689764816292922L;
    private final String code;
    private final Object[] formatParams;

    protected BaseException(String code) {
        this(code, null);
    }

    protected BaseException(String code, String[] formatParams) {

        this.code = code;
        this.formatParams = formatParams;
    }

    /**
     * 获取模块编码，便于区分不同模块异常
     *
     * @return
     */
    protected abstract String getModuleCode();

    @Override
    public String getMessage() {

        String message = "unknown unknown";
        String moduleCode = getModuleCode();
        String key = String.format("%s.%s", moduleCode, code);

        if (ErrorMessageManger.ErrorMessageCodeMap.containsKey(key)) {
            message = ErrorMessageManger.ErrorMessageCodeMap.get(key);
        }

        if (formatParams != null) {
            message = String.format(message, formatParams);
        }

        return message;
    }
}
```
**异常消息管理**

```java
@Component
public class DomainDatabaseModule implements ModuleInfo {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "2001";

    // region 异常常量

    public final static String DB_TYPE_IS_NULL = "0001";

    public final static String CONNECTION_NAME_IS_NULL = "0002";

    public final static String DB_HOST_IS_NULL = "0003";

    public final static String DB_USER_IS_NULL = "0004";

    public final static String DB_PASSWORD_IS_NULL = "0005";

    public final static String DB_CONNECTION_ERROR = "0006";

    public final static String DB_SCHEMA_SERVER_ERROR = "0007";

    public final static String SYSC_CONNECTION_ERROR = "0008";
    public final static String SYSC_CONNECTION_DATABASE_ERROR = "0009";
    public final static String SYSC_DATABASE_CONNECTION_ERROR = "0010";
    public final static String SYSC_TABLE_ERROR = "0011";



    //endregion

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorCodeMap() {
        return new Hashtable<String, String>() {{

            put(DB_TYPE_IS_NULL, "数据库类型不能为空");
            put(CONNECTION_NAME_IS_NULL, "数据库连接名称不能为空");
            put(DB_HOST_IS_NULL, "数据库连接地址不能为空");
            put(DB_USER_IS_NULL, "数据库连接用户不能为空");
            put(DB_PASSWORD_IS_NULL, "数据库连接密码不能为空");
            put(DB_CONNECTION_ERROR, "数据库连接失败");
            put(DB_SCHEMA_SERVER_ERROR, "获取数据库结构服务异常");

            put(SYSC_CONNECTION_ERROR, "同步数据数库，数据库连接异常，连接名称：%s");
            put(SYSC_CONNECTION_DATABASE_ERROR, "同步数据库，数据库异常，数据库名称：%s");
            put(SYSC_DATABASE_CONNECTION_ERROR, "同步数据库,数据连接异常，数据库名称：%s");
            put(SYSC_TABLE_ERROR, "同步数据库%表异常");
        }};
    }
}

```
## （10）包装方法执行结果，对执行结果进行包装，便于判断
```java
public class ExecuteResult {

    public final static ExecuteResult SUCCESS = new ExecuteResult(true);

    public final static ExecuteResult FAIL = new ExecuteResult(false);

    private boolean result;

    public ExecuteResult() {

        result = false;
    }

    public ExecuteResult(Boolean result) {

        this.result = result;
    }

    public ExecuteResult ok() {
        result = true;
        return this;
    }

    public ExecuteResult fail() {
        result = false;
        return this;
    }

    public <T extends Throwable> ExecuteResult fail(T t) {
        result = false;
        return this;
    }

    public boolean equals(ExecuteResult o) {
        return o.result == result;
    }
```
（11）使用RestTemplate做api请求，并编写拦截器进行日志记录，对于Steam对象只能读取一次，不能进行多次读取

（12）如何Spring boot 启动嵌入初始化操作

**@PostConstruct**

对于注入到Spring容器中的类，在其成员函数前添加@PostConstruct注解，则在执行Spring beans初始化时，就会执行该函数。
但由于该函数执行时，其他Spring beans可能并未初始化完成，因此在该函数中执行的初始化操作应当不依赖于其他Spring beans。

```bash
@Component
public class Construct {
    @PostConstruct
    public void doConstruct() throws Exception {
        System.out.println("初始化：PostConstruct");
    }
}
```
**CommandLineRunner**

```bash
@Component
public class InitCommandLineRunner implements CommandLineRunner {
    @Override
    public void run(String... args) throws Exception {
        System.out.println("初始化：InitCommandLineRunner");
    }
}
```
**ApplicationRunner**

```bash
@Component
public class InitApplicationRunner implements ApplicationRunner {
    @Override
    public void run(ApplicationArguments applicationArguments) throws Exception {
        System.out.println("初始化：InitApplicationRunner");
    }
}
```


# 六、其它