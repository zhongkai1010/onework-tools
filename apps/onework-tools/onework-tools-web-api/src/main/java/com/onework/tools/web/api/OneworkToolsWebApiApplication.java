package com.onework.tools.web.api;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

/**
 * @author Administrator
 */
@SpringBootApplication
@MapperScan(basePackages = "com.onework.tools.web.api.mapper")
public class OneworkToolsWebApiApplication {

    public static void main(String[] args) {
        SpringApplication.run(OneworkToolsWebApiApplication.class, args);
    }

}
