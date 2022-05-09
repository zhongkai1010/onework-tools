package com.onework.tools.database.entity;

import com.baomidou.mybatisplus.annotation.FieldFill;
import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableLogic;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import java.time.LocalDateTime;
import lombok.Getter;
import lombok.Setter;
import lombok.experimental.Accessors;

/**
 * <p>
 * 
 * </p>
 *
 * @author zhongkai
 * @since 2022-05-09
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_database_tables")
public class DatabaseTable implements Serializable {

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
     * 连接uid
     */
    @TableField("cn_uid")
    private String cnUid;

    /**
     * 数据库uid
     */
    @TableField("db_uid")
    private String dbUid;

    /**
     * 数据库名称
     */
    @TableField("db_name")
    private String dbName;

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
