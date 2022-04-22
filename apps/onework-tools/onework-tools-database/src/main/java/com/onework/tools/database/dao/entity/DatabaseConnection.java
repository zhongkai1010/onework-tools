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
@TableName("ow_database_connections")
public class DatabaseConnection implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 连接名称
     */
    @TableField("`name`")
    private String name;

    /**
     * 数据库类型
     */
    @TableField("db_type")
    private String dbType;

    /**
     * 默认数据库
     */
    @TableField("`database`")
    private String database;

    /**
     * 连接用户名
     */
    @TableField("username")
    private String username;

    /**
     * 连接密码
     */
    @TableField("`password`")
    private String password;

    /**
     * 主机地址
     */
    @TableField("`host`")
    private String host;

    /**
     * 端口
     */
    @TableField("`port`")
    private Integer port;

    /**
     * 其它配置
     */
    @TableField("config")
    private String config;

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
