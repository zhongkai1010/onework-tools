package com.onework.tools.model.entity;

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
 * @since 2022-04-27
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_model_data_behaviors")
public class ModelDataBehavior implements Serializable {

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
     * 数据模型code
     */
    @TableField("data_code")
    private String dataCode;

    /**
     * 数据模型name
     */
    @TableField("data_name")
    private String dataName;

    /**
     * 输入参数，多条记录，[{type:AppCode.model.itemType,valueValue:"",value:""}]
     */
    @TableField("inputs")
    private String inputs;

    /**
     * 输出参数,单条记录， {type:AppCode.model.itemType,valueValue:"",value:""}]
     */
    @TableField("output")
    private String output;

    /**
     * 操作类型
     */
    @TableField("operation_type")
    private String operationType;

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
