package com.onework.tools.domain.database.schema;

import lombok.Getter;
import lombok.NonNull;
import lombok.Setter;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: DataBaseColumn
 * @author: 钟凯
 * @description: 数据库表字段
 * @date: 2021/12/7 23:35
 * @version: 1.0
 */
@Setter
@Getter
public class DataColumn {

    /**
     * 名称
     */
    @NonNull
    private String name;

    /**
     * 类型
     */
    @NonNull
    private String type;

    /**
     * 长度
     */
    private Long length;

    /**
     * 精度
     */
    private Integer precision;

    /**
     * 是否为空
     */
    @NonNull
    private Boolean allowNull;

    /**
     * 是否主键
     */
    @NonNull
    private Boolean primarykey;

    /**
     * 序号
     */
    private Integer order;

    /**
     * 默认值
     */
    private String defaultValue;

    /**
     * 描述
     */
    private String description;

    @Override
    public String toString() {
        return "Column{" + "name='" + name + '\'' + ", type='" + type + '\'' + ", length=" + length + ", precision="
            + precision + ", allowNull=" + allowNull + ", primarykey=" + primarykey + ", order=" + order
            + ", defaultValue='" + defaultValue + '\'' + ", description='" + description + '\'' + '}';
    }
}
