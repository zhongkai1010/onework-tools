package com.onework.tools.domain.database.dao;

import cn.hutool.core.bean.BeanUtil;
import com.onework.tools.domain.database.schema.entity.DataColumn;
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
    private String name;

    private String cnUid;
    private String dbUid;
    private String dbName;
    private String tbUid;
    private String tbName;

    private String type;
    private Long length;
    private Integer precision;
    private Boolean isNull;
    private Boolean isUnique;
    private Integer order;
    private String defaultValue;
    private String description;

    public static Column getColumn(DataColumn dataColumn, Table table) {

        Column column = BeanUtil.copyProperties(dataColumn, Column.class);
        column.setCnUid(table.getCnUid());
        column.setDbUid(table.getDbUid());
        column.setDbName(table.getDbName());
        column.setTbUid(table.getUid());
        column.setTbName(table.getName());
        return column;
    }
}
