package com.onework.tools.generator;

import com.baomidou.mybatisplus.generator.FastAutoGenerator;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator
 * @Description: 描述
 * @date Date : 2022年03月28日 14:16
 */
public class App {

    public static void main(String[] args) {

        FastAutoGenerator.create("", "", "").globalConfig(builder -> {

        }).packageConfig(builder -> {

        });
        //        try {
        //
        //            String outputDir = System.getProperty("user.dir").concat("/onework-tools-web-api/src/main/java");
        //            String mapperXmlPath = System.getProperty("user.dir")
        //                .concat("/onework-tools-web-api/src/main/resources/mapper");
        //            String configPath = System.getProperty("user.dir")
        //                .concat("/onework-tools-generator/src/main/resources/application.properties");
        //
        //            InputStream applicationInputStream = new FileInputStream(configPath);
        //            Properties properties = new Properties();
        //            properties.load(applicationInputStream);
        //
        //            String datasourceUrl = properties.getProperty("datasource.url");
        //            String datasourceUserName = properties.getProperty("datasource.username");
        //            String datasourcePassword = properties.getProperty("datasource.password");
        //
        //            System.out.println("输出目录：" + outputDir);
        //            System.out.println("数据库连接：" + datasourceUrl);
        //
        //            // @formatter:off
//
//            DataSourceConfig.Builder dataSourceConfigBuilder = new DataSourceConfig.Builder(datasourceUrl, datasourceUserName, datasourcePassword)
//                .dbQuery(new MySqlQuery())
//                .typeConvert(new MySqlTypeConvert())
//                .keyWordsHandler(new MySqlKeyWordsHandler());
//
//            FastAutoGenerator.create(dataSourceConfigBuilder)
//                .globalConfig(builder -> builder
//                    .enableSwagger()
//                    .author("钟凯")
//                    .fileOverride()
//                    .disableOpenDir()
//                    .dateType(DateType.TIME_PACK)
//                    .outputDir(outputDir))
//                .packageConfig(builder -> builder
//                    .parent("com.onework.tools.web.api")
//                    .controller("controller.generate")
//                    .pathInfo(Collections.singletonMap(OutputFile.mapperXml, mapperXmlPath)))
//                .templateConfig(builder -> builder
//                    .disable(TemplateType.CONTROLLER)
//                    .disable(TemplateType.MAPPER)
//                    .disable(TemplateType.SERVICE)
//                    .disable(TemplateType.SERVICEIMPL)
//                    .disable(TemplateType.XML)
//                    .entity("templates/entity.java"))
//                .strategyConfig(builder -> builder
//                    .addTablePrefix("ow_")
//                    .addTableSuffix("s")
//                    .enableCapitalMode()
//                    .controllerBuilder()
//                    .superClass("com.onework.tools.common.web.AbstractCrudController")
//                    .enableRestStyle()
//                    .entityBuilder()
//                    .superClass("com.onework.tools.common.domain.BaseEntity")
//                    .enableTableFieldAnnotation() // 开启生成实体时生成字段注解
//                    .idType(IdType.ASSIGN_ID)
//                    .naming(NamingStrategy.underline_to_camel) // 数据库表映射到实体的命名策略：下划线转驼峰命
//                    .columnNaming(NamingStrategy.underline_to_camel) // 数据库表字段映射到实体的命名策略：下划线转驼峰命
//                    .logicDeleteColumnName("deleted_at").logicDeletePropertyName("deletedAt")
//                    .addTableFills( // 添加表字段填充，"create_time"字段自动填充为插入时间，"modify_time"字段自动填充为插入修改时间
//                        new Column("created_at", FieldFill.INSERT),
//                        new Column("updated_at", FieldFill.INSERT_UPDATE),
//                        new Column("deleted_at", FieldFill.DEFAULT),
//                        new Property("createdAt", FieldFill.INSERT),
//                        new Property("updatedAt", FieldFill.INSERT_UPDATE),
//                        new Property("deletedAt", FieldFill.DEFAULT))
//                    .enableLombok()
//                    .enableChainModel()
//                ).execute();
//            // @formatter:on
        //        } catch (IOException e) {
        //            e.printStackTrace();
        //        }
    }
}
