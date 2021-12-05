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
@TableName("ow_database_connections")
public class OwDatabaseConnections implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    private String uid;

    /**
     * 连接名称
     */
    private String name;

    /**
     * 数据库类型
     */
    private String dbType;

    /**
     * 默认数据库
     */
    private String database;

    /**
     * 连接用户名
     */
    private String username;

    /**
     * 连接密码
     */
    private String password;

    /**
     * 主机地址
     */
    private String host;

    /**
     * 端口
     */
    private Integer port;

    /**
     * 其它配置
     */
    private String config;

    /**
     * 描述
     */
    private String description;

    private LocalDateTime createdAt;

    private LocalDateTime updatedAt;

    private LocalDateTime deletedAt;


}
