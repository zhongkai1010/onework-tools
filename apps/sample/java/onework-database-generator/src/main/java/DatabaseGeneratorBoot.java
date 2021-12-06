import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import com.baomidou.mybatisplus.core.mapper.Mapper;
import com.baomidou.mybatisplus.generator.FastAutoGenerator;
import com.baomidou.mybatisplus.generator.config.OutputFile;
import com.baomidou.mybatisplus.generator.config.TemplateType;
import com.baomidou.mybatisplus.generator.engine.FreemarkerTemplateEngine;
import com.onework.generator.entity.OwDatabaseColumns;
import com.onework.generator.entity.OwDatabaseDbs;
import com.onework.generator.mapper.OwDatabaseColumnsMapper;
import com.onework.generator.service.IOwDatabaseColumnsService;
import com.onework.generator.service.impl.OwDatabaseColumnsServiceImpl;

import java.util.Collections;

public class DatabaseGeneratorBoot {
  public static void main(String[] args) {
    String outputDir = System.getProperty("user.dir") + "/src/main/java";
    String mapperXmlPath = System.getProperty("user.dir")+"/src/main/resources/mapper";
    System.out.println("输出目录：" + outputDir);
    FastAutoGenerator.create("jdbc:mysql://127.0.0.1:3306/onework", "root", "123456")
        .globalConfig(builder -> builder
            .author("钟凯")
            .outputDir(outputDir)
        )
        .packageConfig(builder -> builder
            .parent("com.onework.generator")
            .pathInfo(Collections.singletonMap(OutputFile.mapperXml, mapperXmlPath))
        )
        .strategyConfig(builder -> builder
            .entityBuilder()
            .enableLombok()
            .enableChainModel()
        )
        .templateConfig(builder ->
            builder.disable(TemplateType.CONTROLLER))
        .execute();

    IOwDatabaseColumnsService databaseColumnsService = new OwDatabaseColumnsServiceImpl();
    System.out.println(databaseColumnsService.list());
  }
}
