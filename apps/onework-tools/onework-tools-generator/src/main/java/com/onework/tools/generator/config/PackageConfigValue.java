package com.onework.tools.generator.config;

import com.baomidou.mybatisplus.generator.config.OutputFile;
import lombok.Data;

import java.util.Map;

/**
 * parent(String)	父包名	默认值:com.baomidou <br/>
 * moduleName(String)	父包模块名	默认值:无 <br/>
 * entity(String)	Entity 包名	默认值:entity <br/>
 * service(String)	Service 包名	默认值:service <br/>
 * serviceImpl(String)	Service Impl 包名	默认值:service.impl <br/>
 * mapper(String)	Mapper 包名	默认值:mapper <br/>
 * xml(String)	Mapper XML 包名	默认值:mapper.xml <br/>
 * controller(String)	Controller 包名	默认值:controller <br/>
 * other(String)	自定义文件包名	输出自定义文件时所用到的包名 <br/>
 * pathInfo(Map<OutputFile, String>)	路径配置信息	Collections.singletonMap(OutputFile.mapperXml, "D://") <br/>
 *
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: GeneratorConfig
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 20:07
 * @version: 1.0
 */
@Data
public class PackageConfigValue {

    /**
     * 父包名
     * 默认值: com.onework.tools
     */

    private String parent = "com.onework.tools";

    /**
     * 父包模块名	默认值:无
     */
    private String moduleName = null;

    /**
     * Entity 包名 默认值:entity
     */
    private String entity = "entity";

    /**
     * Service 包名 默认值:service
     */
    private static String service = "service";

    /**
     * Service Impl 包名 默认值:service.impl
     */
    private static String serviceImpl = "service.impl";

    /**
     * Mapper 包名 默认值:mapper
     */
    private static String mapper = "mapper";

    /**
     * Mapper XML 包名 默认值:mapper.xml
     */
    private static String xml = "mapper.xml";

    /**
     * Controller 包名 默认值:controller
     */
    private static String controller = "controller";

    /**
     * 自定义文件包名 输出自定义文件时所用到的包名
     */
    private static String other = null;

    /**
     * Collections.singletonMap(OutputFile.mapperXml, "D://")
     */
    private Map<OutputFile, String> pathInfo = null;

}
