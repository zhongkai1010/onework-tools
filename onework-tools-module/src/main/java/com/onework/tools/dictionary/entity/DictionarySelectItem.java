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
@TableName("ow_dictionary_select_items")
public class DictionarySelectItem implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

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
     * 字典组id
     */
    @TableField("group_id")
    private String groupId;

    /**
     * 字典组名称
     */
    @TableField("group_name")
    private String groupName;

    /**
     * 上级id
     */
    @TableField("parent_id")
    private String parentId;

    /**
     * 上级名称
     */
    @TableField("parent_name")
    private String parentName;

    /**
     * 上级路径
     */
    @TableField("parent_ids")
    private String parentIds;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
