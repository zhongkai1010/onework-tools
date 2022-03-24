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
 * @since 2022-03-24
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_database_columns")
@Schema(name = "DatabaseColumn对象", description = "")
public class DatabaseColumn extends BaseEntity {

    private static final long serialVersionUID = 1L;

    @Schema(description = "唯一值，不重复")
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    @Schema(description = "名称")
    @TableField("`name`")
    private String name;

    @Schema(description = "编码")
    @TableField("`code`")
    private String code;

    @Schema(description = "连接uid")
    @TableField("cn_uid")
    private String cnUid;

    @Schema(description = "数据库uid")
    @TableField("db_uid")
    private String dbUid;

    @Schema(description = "数据库表uid")
    @TableField("tb_uid")
    private String tbUid;

    @Schema(description = "数据库uid")
    @TableField("db_name")
    private String dbName;

    @Schema(description = "类型")
    @TableField("`type`")
    private String type;

    @Schema(description = "是否为空")
    @TableField("is_null")
    private Boolean isNull;

    @Schema(description = "是否主键")
    @TableField("is_unique")
    private Boolean isUnique;

    @Schema(description = "长度")
    @TableField("length")
    private Long length;

    @Schema(description = "精度")
    @TableField("`precision`")
    private Integer precision;

    @Schema(description = "序号")
    @TableField("oredr")
    private Integer oredr;

    @Schema(description = "默认值")
    @TableField("default_value")
    private String defaultValue;

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
