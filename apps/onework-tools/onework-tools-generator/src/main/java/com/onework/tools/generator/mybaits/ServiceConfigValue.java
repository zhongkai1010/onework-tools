package com.onework.tools.generator.mybaits;

import com.baomidou.mybatisplus.generator.function.ConverterFileName;
import lombok.Data;
import lombok.experimental.Accessors;

/**
 * superServiceClass(Class<?>)	设置 service 接口父类	BaseService.class <br/>
 * superServiceClass(String)	设置 service 接口父类	com.baomidou.global.BaseService <br/>
 * superServiceImplClass(Class<?>)	设置 service 实现类父类	BaseServiceImpl.class <br/>
 * superServiceImplClass(String)	设置 service 实现类父类	com.baomidou.global.BaseServiceImpl <br/>
 * convertServiceFileName(ConverterFileName)	转换 service 接口文件名称 <br/>
 * convertServiceImplFileName(ConverterFileName)	转换 service 实现类文件名称 <br/>
 * formatServiceFileName(String)	格式化 service 接口文件名称 <br/>
 * formatServiceImplFileName(String)	格式化 service 实现类文件名称 <br/>
 *
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: ServiceConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 21:15
 * @version: 1.0
 */
@Data
@Accessors(chain = true)
public class ServiceConfigValue {

    /**
     * 设置 service 接口父类	com.baomidou.global.BaseService
     */
    private String superServiceClass;

    /**
     * 设置 service 实现类父类	com.baomidou.global.BaseServiceImpl
     */
    private String superServiceImplClass;

    /**
     * 转换 service 接口文件名称
     */
    private ConverterFileName convertServiceFileName;

    /**
     * 转换 service 实现类文件名称
     */
    private ConverterFileName convertServiceImplFileName;

    /**
     * 格式化 service 接口文件名称
     */
    private String formatServiceFileName;

    /**
     * 格式化 service 实现类文件名称
     */
    private String formatServiceImplFileName;
}
