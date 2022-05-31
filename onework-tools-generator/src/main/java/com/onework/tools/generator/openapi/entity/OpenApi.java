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
 * @date Date : 2022年04月28日 10:11
 */
@Data
public class OpenApi {

    private Map<String, Map<OperationType,Operation>> paths;

    private List<Tag> tags;
}
