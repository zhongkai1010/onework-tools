package com.onework.tools.web.api.entity;

import com.baomidou.mybatisplus.annotation.FieldFill;
import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableLogic;
import com.baomidou.mybatisplus.annotation.TableName;
import com.onework.tools.common.domain.BaseEntity;
import java.io.Serializable;
import java.time.LocalDateTime;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Getter;
import lombok.Setter;
import lombok.experimental.Accessors;

/**
 * <p>
 * 
 * </p>
 *
 * @author 钟凯
 * @since 2022-03-22
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_database_connections")
@Schema(name = "DatabaseConnection对象", description = "")
public class DatabaseConnection extends BaseEntity {

    private static final long serialVersionUID = 1L;

    @Schema(description = "唯一值，不重复")
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    @Schema(description = "连接名称")
    @TableField("`name`")
    private String name;

    @Schema(description = "数据库类型")
    @TableField("db_type")
    private String dbType;

    @Schema(description = "默认数据库")
    @TableField("`database`")
    private String database;

    @Schema(description = "连接用户名")
    @TableField("username")
    private String username;

    @Schema(description = "连接密码")
    @TableField("`password`")
    private String password;

    @Schema(description = "主机地址")
    @TableField("`host`")
    private String host;

    @Schema(description = "端口")
    @TableField("`port`")
    private Integer port;

    @Schema(description = "其它配置")
    @TableField("config")
    private String config;

    @Schema(description = "描述")
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
