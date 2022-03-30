package com.onework.tools.generator.config;

import com.baomidou.mybatisplus.generator.function.ConverterFileName;
import lombok.Data;

/**
 * superClass(Class<?>)	设置父类	BaseController.class  <br/>
 * superClass(String)	设置父类	com.baomidou.global.BaseController <br/>
 * enableHyphenStyle	开启驼峰转连字符	默认值:false <br/>
 * enableRestStyle	开启生成@RestController 控制器	默认值:false <br/>
 * convertFileName(ConverterFileName)	转换文件名称 <br/>
 * formatFileName(String)	格式化文件名称 <br/>
 *
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: ControllerConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 21:15
 * @version: 1.0
 */
@Data
public class ControllerConfigValue {

    /**
     * 设置父类	com.baomidou.global.BaseController
     */
    private String superClass = null;

    /**
     * 开启驼峰转连字符	默认值:false
     */
    private Boolean enableHyphenStyle = false;

    /**
     * 开启生成@RestController 控制器	默认值:false
     */
    private Boolean enableRestStyle = false;

    /**
     * 转换文件名称
     */
    private ConverterFileName convertFileName = null;

    /**
     * 格式化文件名称
     */
    private String formatFileName = null;

}
