package onework.sample.mybatisplus.generate;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.generator.FastAutoGenerator;
import com.baomidou.mybatisplus.generator.config.DataSourceConfig;
import com.baomidou.mybatisplus.generator.config.OutputFile;
import com.baomidou.mybatisplus.generator.config.converts.MySqlTypeConvert;
import com.baomidou.mybatisplus.generator.config.querys.MySqlQuery;
import com.baomidou.mybatisplus.generator.config.rules.DateType;
import com.baomidou.mybatisplus.generator.config.rules.NamingStrategy;
import com.baomidou.mybatisplus.generator.engine.FreemarkerTemplateEngine;
import com.baomidou.mybatisplus.generator.keywords.MySqlKeyWordsHandler;
import lombok.extern.slf4j.Slf4j;
import org.springframework.boot.autoconfigure.jdbc.DataSourceProperties;
import org.springframework.stereotype.Component;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-plus-sample
 * @Package onework.sample.mybatisplus.generate
 * @Description: 描述
 * @date Date : 2021年12月23日 14:47
 */
@Slf4j @Component public class SampleGenerateApplicationBoot {

    private final DataSourceProperties dataSourceProperties;

    public SampleGenerateApplicationBoot(DataSourceProperties dataSourceProperties) {
        this.dataSourceProperties = dataSourceProperties;
    }

    /**
     * 全局生成
     */
    public void executeByAllTable() {
        String url = dataSourceProperties.getUrl();
        String username = dataSourceProperties.getUsername();
        String password = dataSourceProperties.getPassword();
        String outputDir = System.getProperty("user.dir").concat("/src/main/java/onework/sample/mybatisplus/generate");
        String outputPath = outputDir.replaceAll("/", "\\\\");
        log.info("输出目录：" + outputPath);

        DataSourceConfig.Builder dataSourceConfigBuilder =
            new DataSourceConfig.Builder(url, username, password).dbQuery(new MySqlQuery())
                .typeConvert(new MySqlTypeConvert()).keyWordsHandler(new MySqlKeyWordsHandler());

        FastAutoGenerator.create(dataSourceConfigBuilder).globalConfig(
            builder -> builder.enableSwagger().author("钟凯").fileOverride().disableOpenDir().dateType(DateType.TIME_PACK)
                .outputDir(outputDir)).packageConfig(builder -> builder.parent("com.onework.tools.generator")
            .pathInfo(Collections.singletonMap(OutputFile.mapperXml, outputDir))).templateConfig(builder -> builder
            // .disable(TemplateType.CONTROLLER)
            .entity("templates/entity.java")).strategyConfig(
            builder -> builder.addTablePrefix("ow_").addTableSuffix("s").enableCapitalMode().controllerBuilder()
                .superClass("com.onework.tools.common.web.AbstractCrudController").enableRestStyle().entityBuilder()
                .superClass("com.onework.tools.common.domain.BaseEntity").enableTableFieldAnnotation() // 开启生成实体时生成字段注解
                .idType(IdType.ASSIGN_ID)
                // .addSuperEntityColumns("id", "created_by", "created_time", "updated_by", "updated_time")
                .naming(NamingStrategy.underline_to_camel) // 数据库表映射到实体的命名策略：下划线转驼峰命
                .columnNaming(NamingStrategy.underline_to_camel) // 数据库表字段映射到实体的命名策略：下划线转驼峰命
                .logicDeleteColumnName("deleted_at").logicDeletePropertyName("deletedAt")
                // 添加表字段填充，"create_time"字段自动填充为插入时间，"modify_time"字段自动填充为插入修改时间

                .enableLombok().enableChainModel()).execute();
    }

    /**
     * 交互方式生成
     */
    public void executeByCustomTable() {
        /*FastAutoGenerator.create("url", "username", "password")
            // 全局配置
            .globalConfig((scanner, builder) -> builder.author(scanner.apply("请输入作者名称？")).fileOverride())
            // 包配置
            .packageConfig((scanner, builder) -> builder.parent(scanner.apply("请输入包名？")))
            // 策略配置
            .strategyConfig(
                (scanner, builder) -> builder.addInclude(getTables(scanner.apply("请输入表名，多个英文逗号分隔？所有输入 all")))
                    .controllerBuilder().enableRestStyle().enableHyphenStyle().entityBuilder().enableLombok()
                    .addTableFills(new Column("create_time", FieldFill.INSERT)).build())
            *//*
                模板引擎配置，默认 Velocity 可选模板引擎 Beetl 或 Freemarker
               .templateEngine(new BeetlTemplateEngine())
               .templateEngine(new FreemarkerTemplateEngine())
             *//*.execute();*/
    }

    // 处理 all 情况

    /**
     * 拼接表名称
     *
     * @param tables 表名字符串
     * @return 表名称数组
     */
    protected static List<String> getTables(String tables) {
        return "all".equals(tables) ? Collections.emptyList() : Arrays.asList(tables.split(","));
    }
}
