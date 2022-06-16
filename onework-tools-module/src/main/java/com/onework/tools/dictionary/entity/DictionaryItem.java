package com.onework.tools.dictionary.entity;

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
 * @since 2022-06-16
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_dictionary_items")
public class DictionaryItem implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 字典组id
     */
    @TableField("group_id")
    private String groupId;

    /**
     * 名称
     */
    @TableField("`name`")
    private String name;

    /**
     * 值
     */
    @TableField("`value`")
    private String value;

    /**
     * 字典组名称
     */
    @TableField("group_name")
    private String groupName;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
