package com.onework.tools.modularity.database.domain.schema.entity;

import lombok.Data;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: DataBaseColumn
 * @author: 钟凯
 * @description: 数据库表字段
 * @date: 2021/12/7 23:35
 * @version: 1.0
 */
@Data
public class DataColumn {

    private String name;
    private String type;
    private Long length;
    private Integer precision;
    private Boolean isNull;
    private Boolean isUnique;
    private Integer order;
    private String defaultValue;
    private String description;

    @Override
    public String toString() {
        return "Column{" + "name='" + name + '\'' + ", type='" + type + '\'' + ", length=" + length + ", precision="
            + precision + ", allowNull=" + isNull + ", primarykey=" + isUnique + ", order=" + order
            + ", defaultValue='"
            + defaultValue + '\'' + ", description='" + description + '\'' + '}';
    }
}
