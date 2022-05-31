package com.onework.tools.generator.openapi.entity;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.openapi.entity
 * @Description: 描述
 * @date Date : 2022年04月28日 9:51
 */
public enum ParameterIn {
    /**
     * 与 Path Templating 一起使用，当参数的值是URL操作路径的一部分时可以使用，但是不包含主机地址或基础路径。比如在路径 /items/{itemId} 中，路径参数是 itemId。
     */
    path,
    /**
     * 追加在URL地址之后的参数，比如 /items?id=### 中，查询参数是 id。
     */
    query,
    /**
     * 请求中使用的自定义请求头，注意在 RFC7230 中规定，请求头的命名是不区分大小写的。
     */
    header,
    /**
     * 用于传递特定的cookie值。
     */
    cookie
}
