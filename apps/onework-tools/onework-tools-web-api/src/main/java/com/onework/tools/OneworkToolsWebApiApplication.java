package com.onework.tools;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

/**
 *
 * @author Administrator
 */
@SpringBootApplication(scanBasePackages = "com.onework.tools")
public class OneworkToolsWebApiApplication {

    public static void main(String[] args) {
        SpringApplication.run(OneworkToolsWebApiApplication.class, args);
    }

}
