package com.onework.tools.generator.entity;

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
 * @author 钟凯
 * @since 2021-12-12
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_model_data_items")
public class ModelDataItem implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 名称
     */
    @TableField("name")
    private String name;

    /**
     * 编码
     */
    @TableField("code")
    private String code;

    /**
     * 数据模型uid
     */
    @TableField("data_uid")
    private String dataUid;

    /**
     * 数据项uid
     */
    @TableField("item_uid")
    private String itemUid;

    /**
     * 数据项类型
     */
    @TableField("item_type")
    private String itemType;

    /**
     * 数组类型子类型
     */
    @TableField("array_type")
    private String arrayType;

    /**
     * 数组类型子类型
     */
    @TableField("array_depth")
    private Integer arrayDepth;

    /**
     * 对象类型引用值
     */
    @TableField("object_ref")
    private String objectRef;

    /**
     * 数据项类型值
     */
    @TableField("type_value")
    private String typeValue;

    /**
     * 默认值
     */
    @TableField("default_value")
    private String defaultValue;

    /**
     * 是否为空
     */
    @TableField("is_null")
    private Boolean isNull;

    /**
     * 长度
     */
    @TableField("length")
    private Integer length;

    /**
     * 精确度
     */
    @TableField("precision")
    private Integer precision;

    /**
     * 是否唯一
     */
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
