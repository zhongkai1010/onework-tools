package com.onework.tools.module;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication(scanBasePackages = "com.onework.tools")
public class OneworkToolsModuleApplication {

    public static void main(String[] args) {
        SpringApplication.run(OneworkToolsModuleApplication.class, args);
    }

}
