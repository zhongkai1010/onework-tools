package com.onework.tools.generator.openapi.entity;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.openapi.entity
 * @Description: 描述
 * @date Date : 2022年04月28日 9:49
 */
@Data
public class Parameter {
    private String name;
    private ParameterIn in;
    private Schema schema;
    private Boolean required;
    private String description;
    private String type;
}
