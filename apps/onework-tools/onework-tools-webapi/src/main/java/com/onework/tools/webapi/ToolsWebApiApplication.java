package com.onework.tools.webapi;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

/**
 * @author ZK
 */
@SpringBootApplication
@MapperScan("com.onework.tools.webapi.mapper")
public class ToolsWebApiApplication {

  public static void main(String[] args) {
    SpringApplication.run(ToolsWebApiApplication.class, args);
  }

}
