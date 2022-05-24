package com.onework.tools.component.mybaits;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.context.annotation.Configuration;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.configure
 * @className: MybatisPlusConfig
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/19 9:03
 * @version: 1.0
 */
@Configuration
@MapperScan("com.onework.tools.modularity.*.mapper")
public class MybatisPlusConfig {

}
