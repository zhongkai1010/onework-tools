package com.onework.tools;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

/**
 * @author ZK
 */
@SpringBootApplication(scanBasePackages = "com.onework.tools")
@MapperScan("com.onework.tools.generator.mapper")
public class ToolsWebApiApplication {

    public static void main(String[] args) {
        SpringApplication.run(ToolsWebApiApplication.class, args);
    }
}
