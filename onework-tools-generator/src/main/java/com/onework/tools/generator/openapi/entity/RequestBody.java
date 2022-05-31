package com.onework.tools.generator.openapi.entity;

import lombok.Data;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.openapi.entity
 * @Description: 描述
 * @date Date : 2022年04月28日 16:16
 */
@Data
public class RequestBody {
    private  String description;
    private Map<String,Content> content;
}
