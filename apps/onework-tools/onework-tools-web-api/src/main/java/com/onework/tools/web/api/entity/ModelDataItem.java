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
 * @since 2022-03-22
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_model_data_items")
@Schema(name = "ModelDataItem对象", description = "")
public class ModelDataItem extends BaseEntity {

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

    @Schema(description = "数据模型uid")
    @TableField("data_uid")
    private String dataUid;

    @Schema(description = "数据项uid")
    @TableField("item_uid")
    private String itemUid;

    @Schema(description = "数据项类型")
    @TableField("item_type")
    private String itemType;

    @Schema(description = "数组类型子类型")
    @TableField("array_type")
    private String arrayType;

    @Schema(description = "数组类型子类型")
    @TableField("array_depth")
    private Integer arrayDepth;

    @Schema(description = "对象类型引用值")
    @TableField("object_ref")
    private String objectRef;

    @Schema(description = "数据项类型值")
    @TableField("type_value")
    private String typeValue;

    @Schema(description = "默认值")
    @TableField("default_value")
    private String defaultValue;

    @Schema(description = "是否为空")
    @TableField("is_null")
    private Boolean isNull;

    @Schema(description = "长度")
    @TableField("length")
    private Integer length;

    @Schema(description = "精确度")
    @TableField("`precision`")
    private Integer precision;

    @Schema(description = "是否唯一")
    @TableField("is_unique")
    private Boolean isUnique;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
