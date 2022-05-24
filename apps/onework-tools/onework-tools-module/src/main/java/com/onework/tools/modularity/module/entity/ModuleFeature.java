package com.onework.tools.modularity.module.entity;

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
 * @since 2022-05-24
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_module_features")
public class ModuleFeature implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 模块编码
     */
    @TableField("module_code")
    private String moduleCode;

    /**
     * 模块名称
     */
    @TableField("module_name")
    private String moduleName;

    /**
     * 编码
     */
    @TableField("`code`")
    private String code;

    /**
     * 名称
     */
    @TableField("`name`")
    private String name;

    /**
     * 状态
     */
    @TableField("state")
    private String state;

    /**
     * 描述
     */
    @TableField("description")
    private String description;

    /**
     * 扩展信息
     */
    @TableField("ext_data")
    private String extData;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
