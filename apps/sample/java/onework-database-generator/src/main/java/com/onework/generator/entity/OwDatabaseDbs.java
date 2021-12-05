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
@TableName("ow_database_dbs")
public class OwDatabaseDbs implements Serializable {

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
     * 是否同步
     */
    private Boolean isSync;

    /**
     * 最后同步时间
     */
    private LocalDateTime lastSyncDate;

    /**
     * 描述
     */
    private String description;

    private LocalDateTime createdAt;

    private LocalDateTime updatedAt;

    private LocalDateTime deletedAt;


}
