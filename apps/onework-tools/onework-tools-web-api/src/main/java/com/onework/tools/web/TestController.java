package com.onework.tools.web;

import io.swagger.v3.oas.annotations.OpenAPIDefinition;
import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.info.Info;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.web.api.controller
 * @Description: 描述
 * @date Date : 2022年03月22日 15:45
 */
@RestController
@RequestMapping("/test")
@OpenAPIDefinition(info = @Info(description = "测试服务"))
public class TestController {

    @Operation(description = "验证Api")
    @GetMapping(value = "index")
    public String index() {
        return "hello word";
    }
}
