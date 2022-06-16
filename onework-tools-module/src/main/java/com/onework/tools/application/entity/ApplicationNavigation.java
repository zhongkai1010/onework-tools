package com.onework.tools.application.entity;

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
 * @since 2022-06-13
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_application_navigations")
public class ApplicationNavigation implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 应用id
     */
    @TableField("app_id")
    private String appId;

    /**
     * 应用名称
     */
    @TableField("app_name")
    private String appName;

    /**
     * 上级id
     */
    @TableField("parent_id")
    private String parentId;

    /**
     * 上级路径
     */
    @TableField("parent_ids")
    private String parentIds;

    /**
     * 上级名称
     */
    @TableField("parent_name")
    private String parentName;

    /**
     * 名称
     */
    @TableField("`name`")
    private String name;

    /**
     * 路径
     */
    @TableField("path")
    private String path;

    /**
     * 其它信息
     */
    @TableField("meta")
    private String meta;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;

}
