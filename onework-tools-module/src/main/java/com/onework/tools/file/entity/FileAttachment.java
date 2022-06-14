package com.onework.tools.file.entity;

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
 * @since 2022-06-14
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_file_attachments")
public class FileAttachment implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 文件id
     */
    @TableField("file_id")
    private String fileId;

    /**
     * 文件名称
     */
    @TableField("file_name")
    private String fileName;

    /**
     * 文件类别id
     */
    @TableField("category_id")
    private String categoryId;

    /**
     * 关联id
     */
    @TableField("object_id")
    private String objectId;

    /**
     * 版本
     */
    @TableField("version")
    private Integer version;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
