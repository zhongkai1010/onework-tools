package onework.sample.mybatisplus.generate;

import com.baomidou.mybatisplus.annotation.FieldFill;
import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.generator.FastAutoGenerator;
import com.baomidou.mybatisplus.generator.config.DataSourceConfig;
import com.baomidou.mybatisplus.generator.config.OutputFile;
import com.baomidou.mybatisplus.generator.config.TemplateType;
import com.baomidou.mybatisplus.generator.config.converts.MySqlTypeConvert;
import com.baomidou.mybatisplus.generator.config.querys.MySqlQuery;
import com.baomidou.mybatisplus.generator.config.rules.NamingStrategy;
import com.baomidou.mybatisplus.generator.fill.Column;
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

    public SampleGenerateApplicationBoot(final DataSourceProperties dataSourceProperties) {
        this.dataSourceProperties = dataSourceProperties;
    }

    /**
     * 拼接表名称
     *
     * @param tables 表名字符串
     * @return 表名称数组
     */
    private static List<String> getTables(final String tables) {
        return "all".equals(tables) ? Collections.emptyList() : Arrays.asList(tables.split(","));
    }

    /**
     * @param subPath: 子目录
     * @return String
     * @author ZK
     * @description 获取输出目录
     * @date 2021/12/23 21:34
     */
    private static String getGeneratePath(final String subPath) {
        return System.getProperty("user.dir").concat(subPath);
    }

    /**
     * 全局生成
     */
    public void executeByAllTable() {

        final String outputDir = getGeneratePath("/src/main/java/");
        final String outputXmlDir = getGeneratePath("/src/main/resources/mapper");
        log.info("输出目录：" + outputDir);

        final DataSourceConfig.Builder dataSourceConfig = getDataSourceConfig();

        // @formatter:off
        FastAutoGenerator.create(dataSourceConfig).globalConfig(
            builder -> builder
                .author("zhongkai")
                .enableSwagger()
                .fileOverride()
                .disableOpenDir()
                .outputDir(outputDir))
            .packageConfig(builder -> builder
                .parent("onework.sample.mybatisplus.generate")
                .pathInfo(Collections.singletonMap(OutputFile.mapperXml, outputXmlDir)))
            .templateConfig(builder -> builder
                .disable(TemplateType.CONTROLLER)
                .entity("/templates/entity.java")
            )
            .strategyConfig(builder -> builder
                .addTablePrefix("ow_")
                .addTableSuffix("s")
                .entityBuilder()
                .enableTableFieldAnnotation() // 开启生成实体时生成字段注解
                .idType(IdType.ASSIGN_ID)
                .naming(NamingStrategy.underline_to_camel) // 数据库表映射到实体的命名策略：下划线转驼峰命
                .columnNaming(NamingStrategy.underline_to_camel) // 数据库表字段映射到实体的命名策略：下划线转驼峰命
                .addTableFills(new Column("created_at", FieldFill.INSERT))
                .addTableFills(new Column("updated_at", FieldFill.UPDATE))
                .logicDeleteColumnName("deleted_at")
                .logicDeletePropertyName("deletedAt")
                .enableLombok()
            )
            .execute();
        // @formatter:on
        log.info("代码生成完成...");
    }

    /**
     * 交互方式生成
     */
    public void executeByCustomTable() {

        final String outputDir = getGeneratePath("/src/main/java/");
        final String outputXmlDir = getGeneratePath("/src/main/resources/mapper");
        log.info("输出目录：" + outputDir);

        final DataSourceConfig.Builder dataSourceConfig = getDataSourceConfig();

        // @formatter:off
        FastAutoGenerator.create(dataSourceConfig).globalConfig(
                (scanner, builder) -> builder
                    .author(scanner.apply("请输入作者名称？"))
                    .enableSwagger()
                    .fileOverride()
                    .disableOpenDir()
                    .outputDir(outputDir))
            .packageConfig((scanner, builder)  -> builder
                .parent(scanner.apply("请输入包名？"))
                .pathInfo(Collections.singletonMap(OutputFile.mapperXml, outputXmlDir)))
            .templateConfig(builder -> builder
                .disable(TemplateType.CONTROLLER)
                .entity("/templates/entity.java")
            )
            .strategyConfig((scanner, builder)  -> builder
                .addInclude(getTables(scanner.apply("请输入表名，多个英文逗号分隔？所有输入 all")))
                .addTablePrefix("ow_")
                .addTableSuffix("s")
                .entityBuilder()
                .enableTableFieldAnnotation() // 开启生成实体时生成字段注解
                .idType(IdType.ASSIGN_ID)
                .naming(NamingStrategy.underline_to_camel) // 数据库表映射到实体的命名策略：下划线转驼峰命
                .columnNaming(NamingStrategy.underline_to_camel) // 数据库表字段映射到实体的命名策略：下划线转驼峰命
                .addTableFills(new Column("created_at", FieldFill.INSERT))
                .addTableFills(new Column("updated_at", FieldFill.UPDATE))
                .logicDeleteColumnName("deleted_at")
                .logicDeletePropertyName("deletedAt")
                .enableLombok()
            )
            .execute();
        // @formatter:on
        log.info("代码生成完成...");
    }

    /**
     * @return Builder
     * @author ZK
     * @description 获取数据库配置
     * @date 2021/12/23 21:31
     */
    private DataSourceConfig.Builder getDataSourceConfig() {
        final String url = dataSourceProperties.getUrl();
        final String username = dataSourceProperties.getUsername();
        final String password = dataSourceProperties.getPassword();

        final DataSourceConfig.Builder dataSourceConfig = new DataSourceConfig.Builder(url, username, password);
        dataSourceConfig.dbQuery(new MySqlQuery());
        dataSourceConfig.typeConvert(new MySqlTypeConvert()).keyWordsHandler(new MySqlKeyWordsHandler());

        return dataSourceConfig;
    }
}
