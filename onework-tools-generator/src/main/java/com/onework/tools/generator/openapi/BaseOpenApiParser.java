package com.onework.tools.generator.openapi;

import com.onework.tools.generator.openapi.entity.OpenApi;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.openapi.entity
 * @Description: 描述
 * @date Date : 2022年04月28日 10:21
 */
public abstract class BaseOpenApiParser implements OpenApiParser {

    protected String sourceContext;

    protected BaseOpenApiParser(String sourceContext) {
        this.sourceContext = sourceContext;
    }

    /**
     * 解析文件
     * @return OpenApiDocument对象
     */
    @Override
    public abstract OpenApi parseDocument();
}
