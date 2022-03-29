package com.onework.tools.generator.params;

import com.baomidou.mybatisplus.generator.config.rules.DateType;
import lombok.Data;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: GlobalConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 20:53
 * @version: 1.0
 * <p>
 * fileOverride	覆盖已生成文件	默认值:false
 * disableOpenDir	禁止打开输出目录	默认值:true
 * outputDir(String)	指定输出目录	/opt/baomidou/ 默认值: windows:D:// linux or mac : /tmp
 * author(String)	作者名	baomidou 默认值:作者
 * enableKotlin	开启 kotlin 模式	默认值:false
 * enableSwagger	开启 swagger 模式	默认值:false
 * dateType(DateType)	时间策略	DateType.ONLY_DATE 默认值: DateType.TIME_PACK
 * commentDate(String)	注释日期	默认值: yyyy-MM-dd
 * <p/>
 */
@Data
public class GlobalConfigParams {

    /**
     * 覆盖已生成文件 默认值:false
     */
    private final Boolean fileOverride = false;

    /**
     * 禁止打开输出目录 默认值:true
     */
    private final Boolean disableOpenDir = false;

    /**
     * 指定输出目录	/opt/baomidou/默认值:windows:D:// linux or mac : /tmp
     */
    private static final String outputDir = "/";

    /**
     * 作者名 zhongkai 默认值:作者
     */
    private static final String author = "";

    /**
     * 开启 kotlin 模式	默认值:false
     */
    private final Boolean enableKotlin = false;

    /**
     * 开启 swagger 模式	默认值:false
     */
    private final Boolean enableSwagger = false;

    /**
     * 时间策略	DateType.ONLY_DATE 默认值: DateType.TIME_PACK
     */
    private final DateType dateType = DateType.TIME_PACK;

    /**
     * 注释日期 默认值:yyyy-MM-dd
     */
    private static final String commentDate = "yyyy-MM-dd";
}
