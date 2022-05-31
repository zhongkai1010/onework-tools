package com.onework.tools.domain.module;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.module
 * @Description: 功能操作
 * @date Date : 2022年04月26日 10:38
 */
public class AppFeatureOperate {

    /**
     *
     */
    private String code;

    /**
     *
     */
    private String name;

    /**
     * 操作类型
     */
    private String type;

    public AppFeatureOperate(String code, String name) {
        this.code = code;
        this.name = name;
    }
}
