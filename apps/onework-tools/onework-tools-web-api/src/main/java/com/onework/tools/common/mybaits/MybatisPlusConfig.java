package com.onework.tools.common.mybaits;

import com.baomidou.mybatisplus.annotation.DbType;
import com.baomidou.mybatisplus.extension.plugins.MybatisPlusInterceptor;
import com.baomidou.mybatisplus.extension.plugins.inner.PaginationInnerInterceptor;
import org.mybatis.spring.annotation.MapperScan;
import org.mybatis.spring.mapper.MapperScannerConfigurer;
import org.springframework.context.annotation.Bean;
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
@MapperScan("com.onework.tools.server.*.mapper")
public class MybatisPlusConfig {

    @Bean
    public MapperScannerConfigurer mapperScannerConfigurer() {
        MapperScannerConfigurer scannerConfigurer = new MapperScannerConfigurer();
        //可以通过环境变量获取你的mapper路径,这样mapper扫描可以通过配置文件配置了
        scannerConfigurer.setBasePackage("com.onework.tools.server.*.mapper");
        return scannerConfigurer;
    }
}
