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
@TableName("ow_database_columns")
public class OwDatabaseColumns implements Serializable {

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
     * 连接uid
     */
    private String cnUid;

    /**
     * 数据库uid
     */
    private String dbUid;

    /**
     * 数据库表uid
     */
    private String tbUid;

    /**
     * 数据库uid
     */
    private String dbName;

    /**
     * 类型
     */
    private String type;

    /**
     * 是否为空
     */
    private Boolean isNull;

    /**
     * 是否主键
     */
    private Boolean isUnique;

    /**
     * 长度
     */
    private Long length;

    /**
     * 精度
     */
    private Integer precision;

    /**
     * 序号
     */
    private Integer oredr;

    /**
     * 默认值
     */
    private String defaultValue;

    /**
     * 描述
     */
    private String description;

    private LocalDateTime createdAt;

    private LocalDateTime updatedAt;

    private LocalDateTime deletedAt;


}
