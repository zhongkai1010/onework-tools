package com.onework.tools.configure;

import org.springdoc.core.GroupedOpenApi;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

import io.swagger.v3.oas.models.Components;
import io.swagger.v3.oas.models.OpenAPI;
import io.swagger.v3.oas.models.info.Info;
import io.swagger.v3.oas.models.info.License;
import io.swagger.v3.oas.models.security.SecurityRequirement;
import io.swagger.v3.oas.models.security.SecurityScheme;


/**
 * @author ZK
 */
@Configuration
public class SwaggerConfig implements WebMvcConfigurer {

        @Bean
        public GroupedOpenApi defaultGroup() {
            // @formatter:off
            return GroupedOpenApi.builder()
                .group("default")
                .addOperationCustomizer((operation, handlerMethod) -> {
                    operation.addSecurityItem(new SecurityRequirement().addList("basicScheme"));
                    return operation;
                })
                .packagesToScan("com.onework.tools.web.api.controller").build();
            // @formatter:on
        }

        @Bean
        public OpenAPI customOpenApi(@Value("${springdoc.version}") String appVersion) {
            // @formatter:off
            return new OpenAPI()
                .components(new Components()
                    .addSecuritySchemes("basicScheme",
                        new SecurityScheme()
                            .type(SecurityScheme.Type.HTTP)
                            .scheme("basic")))
                .info(new Info()
                    .title("Petstore API")
                        .version(appVersion)
                        .license(new License()
                            .name("Apache 2.0")
                            .url("http://springdoc.org")));
            // @formatter:on
        }
}