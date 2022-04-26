package com.onework.tools.model.entity;

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
 * @since 2022-04-27
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
     * 数据项code
     */
    @TableField("data_code")
    private String dataCode;

    /**
     * 数据项name
     */
    @TableField("data_name")
    private String dataName;

    /**
     * 对象类型引用值
     */
    @TableField("ref_code")
    private String refCode;

    /**
     * 数组类型子类型
     */
    @TableField("array_code")
    private String arrayCode;

    /**
     * 默认值
     */
    @TableField("default_value")
    private String defaultValue;

    /**
     * 扩展属性
     */
    @TableField("extData")
    private String extData;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
