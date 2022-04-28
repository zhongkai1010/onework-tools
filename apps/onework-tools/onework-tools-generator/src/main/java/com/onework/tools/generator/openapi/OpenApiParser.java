package com.onework.tools.generator.openapi;

import com.onework.tools.generator.openapi.entity.OpenApi;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.openapi.entity
 * @Description: 描述
 * @date Date : 2022年04月28日 10:14
 */
public interface OpenApiParser {

    /**
     * 解析 OpenApi文件
     *
     * @return OpenApiDocument对象
     */
    OpenApi parseDocument();
}
