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
@TableName("ow_model_data_items")
public class OwModelDataItems implements Serializable {

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
     * 数据项uid
     */
    private String itemUid;

    /**
     * 数据项类型
     */
    private String itemType;

    /**
     * 数组类型子类型
     */
    private String arrayType;

    /**
     * 数组类型子类型
     */
    private Integer arrayDepth;

    /**
     * 对象类型引用值
     */
    private String objectRef;

    /**
     * 数据项类型值
     */
    private String typeValue;

    /**
     * 默认值
     */
    private String defaultValue;

    /**
     * 是否为空
     */
    private Boolean isNull;

    /**
     * 长度
     */
    private Integer length;

    /**
     * 精确度
     */
    private Integer precision;

    /**
     * 是否唯一
     */
    private Boolean isUnique;

    private LocalDateTime createdAt;

    private LocalDateTime updatedAt;

    private LocalDateTime deletedAt;


}
