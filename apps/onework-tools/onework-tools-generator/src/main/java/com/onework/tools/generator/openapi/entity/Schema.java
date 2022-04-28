package com.onework.tools.generator.openapi.entity;

import lombok.Data;

import java.util.List;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.openapi.entity
 * @Description: 描述
 * @date Date : 2022年04月28日 15:37
 */
@Data
public class Schema {
    private PropertieType type;
    private String title;
    private Map<String, Propertie> properties;
    private List<String> required;
    private String description;
    private Schema items;
}
