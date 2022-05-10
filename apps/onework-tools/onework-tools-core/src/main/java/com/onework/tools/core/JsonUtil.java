package com.onework.tools.core;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.util.Objects;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core
 * @Description: 描述
 * @date Date : 2022年05月10日 16:34
 */

public class JsonUtil {
    private static ObjectMapper objectMapper = new ObjectMapper();

    static {
        // init objectMapper
        objectMapper.setSerializationInclusion(JsonInclude.Include.NON_NULL);
    }

    /**
     * 对象转json字符串
     */
    public static String obj2Str(Object obj) {
        if (Objects.isNull(obj)) {
            return null;
        }

        if (obj instanceof String) {
            return (String)obj;
        }

        try {
            return objectMapper.writeValueAsString(obj);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
            return null;
        }
    }

    /**
     * json字符串转对象
     */
    public static <T> T str2Obj(String jsonStr, Class<T> clazz) {
        if (Objects.isNull(jsonStr) || Objects.isNull(clazz)) {
            return null;
        }

        try {
            return clazz.equals(String.class) ? (T)jsonStr : objectMapper.readValue(jsonStr, clazz);
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }

    /**
     * json字符串转对象
     */
    public static <T> T str2Obj(String jsonStr, TypeReference<T> valueTypeRef) {
        if (Objects.isNull(jsonStr) || Objects.isNull(valueTypeRef)) {
            return null;
        }

        try {
            return objectMapper.readValue(jsonStr, valueTypeRef);
        } catch (IOException e) {
            e.printStackTrace();

            return null;
        }
    }

    /**
     * 获取自定义规则 json对象（规则：objectName1:jsonString;objectName2:jsonString;）
     *
     * @param str        字符串
     * @param objectName 获取字符串中的对象
     * @param clazz      对象类型
     * @param <T>        实体类
     * @return
     */
    public static <T> T getObject(String str, String objectName, Class<T> clazz) {
        // 解析获取对应json
        String s = objectName + ":";
        int startIndex = str.indexOf(s) + s.length();
        int endIndex = str.substring(startIndex).indexOf(";") + startIndex;

        String jsonStr = str.substring(startIndex, endIndex);

        // 反序列化
        return getJsonObject(jsonStr, clazz);
    }

    /**
     * 反序列化json字符串
     *
     * @param jsonStr json字符串
     * @param clazz   反序列化class对象
     * @param <T>     class对象
     */
    public static <T> T getJsonObject(String jsonStr, Class<T> clazz) {
        ObjectMapper objectMapper = new ObjectMapper();
        try {
            return objectMapper.readValue(jsonStr, clazz);
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    /**
     * 获取自定义规则 json对象（规则：objectName1:jsonString;objectName2:jsonString;）
     *
     * @param str        字符串
     * @param objectName 获取字符串中的对象
     * @param tClass     集合类类型
     * @param vClass     集合泛型类类型
     * @param <T>        集合类型
     * @param <V>        集合泛型类型
     */
    public static <T, V> T getObjectCollection(String str, String objectName, Class<T> tClass, Class<V> vClass) {
        // 解析获取对应json
        String s = objectName + ":";
        int startIndex = str.indexOf(s) + s.length();
        int endIndex = str.substring(startIndex).indexOf(";") + startIndex;

        String jsonStr = str.substring(startIndex, endIndex);

        // 反序列化
        return getJsonObjectCollection(jsonStr, tClass, vClass);
    }

    /**
     * 反序列化集合json字符串
     *
     * @param jsonStr json字符串
     * @param tClass  集合类类型
     * @param vClass  集合泛型类类型
     * @param <T>     集合类型
     * @param <V>     集合泛型类型
     */
    public static <T, V> T getJsonObjectCollection(String jsonStr, Class<T> tClass, Class<V> vClass) {
        ObjectMapper objectMapper = new ObjectMapper();
        try {
            return objectMapper.readValue(jsonStr,
                objectMapper.getTypeFactory().constructParametricType(tClass, vClass));
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }
}

