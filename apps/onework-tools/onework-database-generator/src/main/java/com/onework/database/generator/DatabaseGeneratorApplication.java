package com.onework.database.generator;

import com.baomidou.mybatisplus.annotation.FieldFill;
import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.generator.FastAutoGenerator;
import com.baomidou.mybatisplus.generator.config.DataSourceConfig;
import com.baomidou.mybatisplus.generator.config.OutputFile;
import com.baomidou.mybatisplus.generator.config.TemplateType;
import com.baomidou.mybatisplus.generator.config.converts.MySqlTypeConvert;
import com.baomidou.mybatisplus.generator.config.querys.MySqlQuery;
import com.baomidou.mybatisplus.generator.config.rules.DateType;
import com.baomidou.mybatisplus.generator.config.rules.NamingStrategy;
import com.baomidou.mybatisplus.generator.fill.Column;
import com.baomidou.mybatisplus.generator.fill.Property;
import com.baomidou.mybatisplus.generator.keywords.MySqlKeyWordsHandler;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.Collections;
import java.util.Properties;

/**
 * @author ZK
 */
public class DatabaseGeneratorApplication {
  public static void main(String[] args) {
    try {
      String outputDir = System.getProperty("user.dir").concat("/onework-tools-webapi/src/main/java");
      String mapperXmlPath = System.getProperty("user.dir") .concat("/onework-tools-webapi/src/main/resources/mapper");
      String configPath = System.getProperty("user.dir") .concat("/onework-database-generator/src/main/resources/application.properties");

      InputStream applicationInputStream = new FileInputStream(configPath);
      Properties properties = new Properties();
      properties.load(applicationInputStream);

      String datasourceUrl = properties.getProperty("datasource.url");
      String datasourceUserName = properties.getProperty("datasource.username");
      String datasourcePassword = properties.getProperty("datasource.password");

      System.out.println("输出目录：" + outputDir);
      System.out.println("数据库连接：" + datasourceUrl);

      DataSourceConfig.Builder dataSourceConfigBuilder = new DataSourceConfig.Builder(datasourceUrl,datasourceUserName,datasourcePassword)
     .dbQuery(new MySqlQuery()).typeConvert(new MySqlTypeConvert()).keyWordsHandler(new MySqlKeyWordsHandler());

      FastAutoGenerator.create(dataSourceConfigBuilder)
          .globalConfig(builder -> builder
              .enableSwagger()
              .author("钟凯")
              //.fileOverride()
              .disableOpenDir()
              .dateType(DateType.TIME_PACK)
              .outputDir(outputDir)
          )
          .packageConfig(builder -> builder
              .parent("com.onework.tools.generator")
              .pathInfo(Collections.singletonMap(OutputFile.mapperXml, mapperXmlPath))
          )
          .templateConfig(builder -> builder
                  //.disable(TemplateType.CONTROLLER)
                  .entity("templates/entity.java")
          )
          .strategyConfig(builder -> builder
              .addTablePrefix("ow_")
              .addTableSuffix("s")
              .enableCapitalMode()
              .controllerBuilder()
              .enableRestStyle()
              .entityBuilder()
              .enableTableFieldAnnotation() // 开启生成实体时生成字段注解
              .idType(IdType.ASSIGN_ID)
              //.addSuperEntityColumns("id", "created_by", "created_time", "updated_by", "updated_time")
              .naming(NamingStrategy.underline_to_camel)  //数据库表映射到实体的命名策略：下划线转驼峰命
              .columnNaming(NamingStrategy.underline_to_camel) //数据库表字段映射到实体的命名策略：下划线转驼峰命
              .logicDeleteColumnName("deleted_at")
              .logicDeletePropertyName("deletedAt")
              .addTableFills( //添加表字段填充，"create_time"字段自动填充为插入时间，"modify_time"字段自动填充为插入修改时间
                  new Column("created_at", FieldFill.INSERT),
                  new Column("updated_at", FieldFill.INSERT_UPDATE),
                  new Column("deleted_at", FieldFill.DEFAULT),
                  new Property("createdAt", FieldFill.INSERT),
                  new Property("updatedAt", FieldFill.INSERT_UPDATE),
                  new Property("deletedAt", FieldFill.DEFAULT)
              )
              .enableLombok()
              .enableChainModel()

          ).execute();
    } catch (IOException e) {
      e.printStackTrace();
    }
  }
}
