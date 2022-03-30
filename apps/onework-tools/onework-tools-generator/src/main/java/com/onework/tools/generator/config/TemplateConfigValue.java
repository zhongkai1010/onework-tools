package com.onework.tools.generator.config;

import lombok.Data;
import lombok.experimental.Accessors;

/**
 * disable	禁用所有模板 <br/>
 * disable(TemplateType...)	禁用模板	TemplateType.ENTITY <br/>
 * entity(String)	设置实体模板路径(JAVA)	/templates/entity.java <br/>
 * entityKt(String)	设置实体模板路径(kotlin)	/templates/entity.java <br/>
 * service(String)	设置 service 模板路径	/templates/service.java <br/>
 * serviceImpl(String)	设置 serviceImpl 模板路径	/templates/serviceImpl.java <br/>
 * mapper(String)	设置 mapper 模板路径	/templates/mapper.java <br/>
 * mapperXml(String)	设置 mapperXml 模板路径	/templates/mapper.xml <br/>
 * controller(String)	设置 controller 模板路径	/templates/controller.java <br/>
 *
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: TemplateConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 21:01
 * @version: 1.0
 */
@Data
@Accessors(chain = true)
public class TemplateConfigValue {

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
    private String entity;

    /**
     * 设置实体模板路径(kotlin)	/templates/entity.java
     */
    private String entityKt;

    /**
     * 设置 service 模板路径	/templates/service.java
     */
    private String service;

    /**
     * 设置 serviceImpl 模板路径	/templates/serviceImpl.java
     */
    private String serviceImpl;

    /**
     * 设置 mapper 模板路径	/templates/mapper.java
     */
    private String mapper;

    /**
     * 设置 mapperXml 模板路径	/templates/mapper.xml
     */
    private String mapperXml;

    /**
     * 设置 controller 模板路径	/templates/controller.java
     */
    private String controller;

}
