package com.onework.tools;

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
@ComponentScan(basePackages="com.onework.tools")
public class ToolsWebApiApplication {

  public static void main(String[] args) {
    SpringApplication.run(ToolsWebApiApplication.class, args);
  }
}
