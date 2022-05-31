package com.onework.tools.generator.openapi;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.onework.tools.generator.openapi.entity.OpenApi;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.openapi.entity
 * @Description: 描述
 * @date Date : 2022年04月28日 10:13
 */
public class JsonOpenApiParser extends BaseOpenApiParser {

    protected JsonOpenApiParser(String sourceContext) {
        super(sourceContext);
    }

    @Override
    public OpenApi parseDocument() {
        ObjectMapper objectMapper = new ObjectMapper();
        try {
            return objectMapper.readValue(this.sourceContext, OpenApi.class);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
            System.out.println(e.getMessage());
        }
        return null;
    }

    private OpenApi getOpenApiDocument(Object object) {

        OpenApi document = new OpenApi();
        //        JSONObject jsonObject = Convert.convert(JSONObject.class, object);
        //        JSONArray tagsJsonArray = jsonObject.getJSONArray("tags");
        //        Map<String, Tag> tags = getTags(tagsJsonArray);
        //        document.setTags(tags);
        //        JSONObject pathsJsonObject = jsonObject.getObject("paths", JSONObject.class);
        //        Map<String, PathItem> paths = getPaths(pathsJsonObject);
        //        document.setPaths(paths);

        return document;
    }

    //    private Map<String, Tag> getTags(Object object) {
    //
    //        Map<String, Tag> tags = new HashMap<>(16);
    //        JSONArray jsonArray = Convert.convert(JSONArray.class, object);
    //        jsonArray.forEach(value -> {
    //            JSONObject jsonObject = Convert.convert(JSONObject.class, value);
    //            Tag tag = new Tag();
    //            tag.setName(jsonObject.getString("name"));
    //            tag.setDescription(jsonObject.getString("description"));
    //            tags.put(tag.getName(), tag);
    //        });
    //        return tags;
    //    }
    //
    //    private Map<String, PathItem> getPaths(Object object) {
    //        Map<String, PathItem> pathMap = new HashMap<>(16);
    //
    //        JSONObject jsonObject = Convert.convert(JSONObject.class, object);
    //        Map<String, Object> objectMap = jsonObject.getInnerMap();
    //        objectMap.forEach((key, value) -> {
    //
    //            JSONObject pathJsonObject = Convert.convert(JSONObject.class, value);
    //            Map<String, Object> objectMap1 = pathJsonObject.getInnerMap();
    //
    //            objectMap1.forEach((key1, value1) -> {
    //                OperationType operationType = EnumUtil.fromStringQuietly(OperationType.class, key1);
    //                PathItem pathItem = getPathItem(operationType, value1);
    //                pathMap.put(key, pathItem);
    //            });
    //
    //        });
    //        return pathMap;
    //    }
    //
    //    private PathItem getPathItem(OperationType operationType, Object object) {
    //        PathItem pathItem = new PathItem();
    //        return pathItem;
    //    }

}
