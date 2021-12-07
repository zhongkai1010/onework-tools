package com.onework.database.generator;

import com.baomidou.mybatisplus.generator.FastAutoGenerator;
import com.baomidou.mybatisplus.generator.config.INameConvert;
import com.baomidou.mybatisplus.generator.config.OutputFile;
import com.baomidou.mybatisplus.generator.config.rules.NamingStrategy;

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

      FastAutoGenerator.create(datasourceUrl, datasourceUserName, datasourcePassword)
          .globalConfig(builder -> builder
              .author("钟凯")
              .outputDir(outputDir)
          )
          .packageConfig(builder -> builder
              .parent("com.onework.tools.webapi.generator")
              .pathInfo(Collections.singletonMap(OutputFile.mapperXml, mapperXmlPath))
          )
          .strategyConfig(builder -> builder
              .addTablePrefix("ow_")
              .addTableSuffix("s")
              .enableCapitalMode()
              .controllerBuilder()
              .entityBuilder()

              .enableLombok()
              .enableChainModel()

          )
//          .templateConfig(builder ->
//              builder.disable(TemplateType.CONTROLLER))
          .execute();
    } catch (IOException e) {
      e.printStackTrace();
    }
  }
}
