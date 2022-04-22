package com.onework.tools.database.dao.entity;

import com.baomidou.mybatisplus.annotation.*;
import lombok.Getter;
import lombok.Setter;
import lombok.experimental.Accessors;

import java.io.Serializable;
import java.time.LocalDateTime;

/**
 * <p>
 *
 * </p>
 *
 * @author zhongkai
 * @since 2022-03-31
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_database_columns")
public class DatabaseColumn implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 名称
     */
    @TableField("`name`")
    private String name;

    /**
     * 编码
     */
    @TableField("`code`")
    private String code;

    /**
     * 连接uid
     */
    @TableField("cn_uid")
    private String cnUid;

    /**
     * 数据库uid
     */
    @TableField("db_uid")
    private String dbUid;

    /**
     * 数据库表uid
     */
    @TableField("tb_uid")
    private String tbUid;

    /**
     * 数据库uid
     */
    @TableField("db_name")
    private String dbName;

    /**
     * 类型
     */
    @TableField("`type`")
    private String type;

    /**
     * 是否为空
     */
    @TableField("is_null")
    private Boolean isNull;

    /**
     * 是否主键
     */
    @TableField("is_unique")
    private Boolean isUnique;

    /**
     * 长度
     */
    @TableField("length")
    private Long length;

    /**
     * 精度
     */
    @TableField("`precision`")
    private Integer precision;

    /**
     * 序号
     */
    @TableField("oredr")
    private Integer oredr;

    /**
     * 默认值
     */
    @TableField("default_value")
    private String defaultValue;

    /**
     * 描述
     */
    @TableField("description")
    private String description;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;

}
