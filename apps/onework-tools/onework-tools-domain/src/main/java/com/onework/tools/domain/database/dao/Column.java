package com.onework.tools.domain.database.dao;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.dao
 * @Description: 描述
 * @date Date : 2022年03月29日 16:31
 */

@Data
public class Column {

    private String uid;

    private String cnUid;

    private String dbUid;
    private String dbName;

    private String tbUid;
    private String tbName;

    private String name;
    private String type;
    private Long length;
    private Integer precision;
    private Boolean allowNull;
    private Boolean primarykey;
    private Integer order;
    private String defaultValue;
    private String description;
}
