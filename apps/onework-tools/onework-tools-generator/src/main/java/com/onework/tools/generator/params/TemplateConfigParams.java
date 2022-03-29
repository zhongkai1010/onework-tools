package com.onework.tools.generator.params;

import lombok.Data;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: TemplateConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 21:01
 * @version: 1.0
 * <p>
 * disable	禁用所有模板
 * disable(TemplateType...)	禁用模板	TemplateType.ENTITY
 * entity(String)	设置实体模板路径(JAVA)	/templates/entity.java
 * entityKt(String)	设置实体模板路径(kotlin)	/templates/entity.java
 * service(String)	设置 service 模板路径	/templates/service.java
 * serviceImpl(String)	设置 serviceImpl 模板路径	/templates/serviceImpl.java
 * mapper(String)	设置 mapper 模板路径	/templates/mapper.java
 * mapperXml(String)	设置 mapperXml 模板路径	/templates/mapper.xml
 * controller(String)	设置 controller 模板路径	/templates/controller.java
 * <p/>
 */
@Data
public class TemplateConfigParams {

    /**
     * 禁用所有模板
     */
    private Boolean disable = false;

    private Boolean disableEntity = false;
    private Boolean disableService = false;
    private Boolean disableServiceImpl = false;
    private Boolean disableMapper = false;
    private Boolean disableMapperXml = false;
    private Boolean disableController = false;

    /**
     * 设置实体模板路径(JAVA)	/templates/entity.java
     */
    private String entity = null;

    /**
     * 设置实体模板路径(kotlin)	/templates/entity.java
     */
    private String entityKt = null;

    /**
     * 设置 service 模板路径	/templates/service.java
     */
    private String service = null;

    /**
     * 设置 serviceImpl 模板路径	/templates/serviceImpl.java
     */
    private String serviceImpl = null;

    /**
     * 设置 mapper 模板路径	/templates/mapper.java
     */
    private String mapper = null;

    /**
     * 设置 mapperXml 模板路径	/templates/mapper.xml
     */
    private String mapperXml = null;

    /**
     * 设置 controller 模板路径	/templates/controller.java
     */
    private String controller = null;

}
