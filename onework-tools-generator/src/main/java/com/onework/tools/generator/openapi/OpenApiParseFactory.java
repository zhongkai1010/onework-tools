package com.onework.tools.generator.openapi;

import com.onework.tools.generator.openapi.entity.OpenApi;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.openapi.entity
 * @Description: 描述
 * @date Date : 2022年04月28日 10:10
 */
public class OpenApiParseFactory {

    /**
     * @param json
     * @return
     */
    public static OpenApi parseJson(String json) {

        JsonOpenApiParser jsonOpenApiParser = new JsonOpenApiParser(json);
        OpenApi openApiDocument = jsonOpenApiParser.parseDocument();
        return openApiDocument;
    }

    public static OpenApi parseYaml(String yaml) {
        YamlOpenApiParser yamlOpenApiParser = new YamlOpenApiParser(yaml);
        OpenApi openApiDocument = yamlOpenApiParser.parseDocument();
        return openApiDocument;
    }
}
