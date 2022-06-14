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
@TableName("ow_files")
public class File implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 文件类别id
     */
    @TableField("category_id")
    private String categoryId;

    /**
     * 文件类别名称
     */
    @TableField("category_name")
    private String categoryName;

    /**
     * 文件名称
     */
    @TableField("`name`")
    private String name;

    /**
     * 文件大小（kb）
     */
    @TableField("size")
    private Long size;

    /**
     * 文件后缀
     */
    @TableField("ext")
    private String ext;

    /**
     * 物理路径
     */
    @TableField("physical_path")
    private String physicalPath;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
