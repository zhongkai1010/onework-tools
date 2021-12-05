package com.onework.generator.entity;

import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import java.time.LocalDateTime;
import lombok.Getter;
import lombok.Setter;

/**
 * <p>
 * 
 * </p>
 *
 * @author 钟凯
 * @since 2021-12-04
 */
@Getter
@Setter
@TableName("ow_model_data_behaviors")
public class OwModelDataBehaviors implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    private String uid;

    /**
     * 名称
     */
    private String name;

    /**
     * 编码
     */
    private String code;

    /**
     * 数据模型uid
     */
    private String dataUid;

    /**
     * 输入参数，多条记录，[{type:AppCode.model.itemType,valueValue:"",value:""}]
     */
    private String inputs;

    /**
     * 输出参数,单条记录， {type:AppCode.model.itemType,valueValue:"",value:""}]
     */
    private String outputs;

    /**
     * 操作类型
     */
    private String operationType;

    /**
     * 描述
     */
    private String description;

    private LocalDateTime createdAt;

    private LocalDateTime updatedAt;

    private LocalDateTime deletedAt;


}
