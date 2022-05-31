package com.onework.tools.generator.mybaits;

import com.baomidou.mybatisplus.generator.config.rules.DateType;
import lombok.Data;
import lombok.experimental.Accessors;

/**
 * fileOverride	覆盖已生成文件	默认值:false <br/>
 * disableOpenDir	禁止打开输出目录	默认值:true <br/>
 * outputDir(String)	指定输出目录	/opt/baomidou/ 默认值: windows:D:// linux or mac : /tmp <br/>
 * author(String)	作者名	baomidou 默认值:作者 <br/>
 * enableKotlin	开启 kotlin 模式	默认值:false <br/>
 * enableSwagger	开启 swagger 模式	默认值:false <br/>
 * dateType(DateType)	时间策略	DateType.ONLY_DATE 默认值: DateType.TIME_PACK <br/>
 * commentDate(String)	注释日期	默认值: yyyy-MM-dd <br/>
 *
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: GlobalConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 20:53
 * @version: 1.0
 */
@Data
@Accessors(chain = true)
public class GlobalConfigValue {

    /**
     * 覆盖已生成文件 默认值:false
     */
    private Boolean fileOverride = true;

    /**
     * 禁止打开输出目录 默认值:true
     */
    private Boolean disableOpenDir = true;

    /**
     * 指定输出目录 默认值:System.getProperty("user.dir")
     */
    private String outputDir = System.getProperty("user.dir").concat("/onework-tools-generator/src/main/java");

    /**
     * 作者名 zhongkai 默认值:作者
     */
    private String author = "zhongkai";

    /**
     * 开启 kotlin 模式 默认值:false
     */
    private Boolean enableKotlin = false;

    /**
     * 开启 swagger 模式	默认值:false
     */
    private Boolean enableSwagger = false;

    /**
     * 时间策略	DateType.ONLY_DATE 默认值: DateType.TIME_PACK
     */
    private DateType dateType = DateType.TIME_PACK;

    /**
     * 注释日期 默认值:yyyy-MM-dd
     */
    private String commentDate = "yyyy-MM-dd";
}
