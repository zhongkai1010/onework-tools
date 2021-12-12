package com.onework.tools.webapi;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

/**
 * @author ZK
 */
@SpringBootApplication
@MapperScan("com.onework.tools.generator.mapper")
@ComponentScan("com.onework.tools.database")
public class ToolsWebApiApplication {

  public static void main(String[] args) {
    SpringApplication.run(ToolsWebApiApplication.class, args);
  }

}
