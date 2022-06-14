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
@TableName("ow_file_categories")
public class FileCategory implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 类别编码
     */
    @TableField("`code`")
    private String code;

    /**
     * 类别名称
     */
    @TableField("`name`")
    private String name;

    /**
     * 所属文件总数
     */
    @TableField("file_count")
    private Integer fileCount;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
