package com.onework.tools.service.model.entity;

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
 * @since 2022-04-21
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_model_items")
public class ModelItem implements Serializable {

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
     * 数据项类型
     */
    @TableField("`type`")
    private String type;

    /**
     * 使用累计总数
     */
    @TableField("cumulate")
    private Integer cumulate;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;

}
