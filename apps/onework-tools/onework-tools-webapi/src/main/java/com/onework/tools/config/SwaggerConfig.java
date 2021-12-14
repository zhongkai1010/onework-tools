package com.onework.tools.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.EnableWebMvc;
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry;
import org.springframework.web.servlet.config.annotation.ViewControllerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import springfox.documentation.builders.ApiInfoBuilder;
import springfox.documentation.builders.PathSelectors;
import springfox.documentation.builders.RequestHandlerSelectors;
import springfox.documentation.service.ApiInfo;
import springfox.documentation.service.Contact;
import springfox.documentation.spi.DocumentationType;
import springfox.documentation.spring.web.plugins.Docket;

/**
* swagger配置
 * * @author 钟凯
 * * @since 2021-12-12
*/
@Configuration
@EnableWebMvc
public class SwaggerConfig implements WebMvcConfigurer {
    @Bean
    public Docket createRestApi() {
        ApiInfo apiInfo =
            new ApiInfoBuilder()
                .title("日志管理系统API")
                .description("日志管理系统采用SpringBoot开发，API文档集成Swagger")
                .version("1.0")
                .contact(new Contact("余静", "https://github.com/yutils", "3373217@qq.com"))
                .license("我的首页")
                .licenseUrl("https://weibo.com/32005200")
                .build();
        return new Docket(DocumentationType.SWAGGER_2)
            .apiInfo(apiInfo)
            .select()
            .apis(RequestHandlerSelectors.basePackage("com.onework.tools.generator.controller"))
            .paths(PathSelectors.any())
            .build();
    }

    @Override
    public void addResourceHandlers(ResourceHandlerRegistry registry) {
        registry.
                addResourceHandler( "/swagger-ui/**")
            .addResourceLocations("classpath:/META-INF/resources/webjars/springfox-swagger-ui/")
            .resourceChain(false);
    }

    @Override
    public void addViewControllers(ViewControllerRegistry registry) {
        registry.addViewController( "/swagger-ui/")
            .setViewName("forward:" +  "/swagger-ui/index.html");
    }
}
