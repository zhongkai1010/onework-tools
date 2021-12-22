package com.onework.sample.mybaits.entity;

import lombok.Data;

import java.time.LocalDateTime;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-sample
 * @Package com.onework.sample.mybaits.entity
 * @Description: 描述
 * @date Date : 2021年12月22日 10:00
 */
@Data public class DatabaseConnection {

    private String uid;

    private String name;

    private String dbType;

    private String database;

    private String username;

    private String password;

    private String host;

    private Integer port;

    private String config;

    private String description;

    private LocalDateTime createdAt;

    private LocalDateTime updatedAt;

    private LocalDateTime deletedAt;

    @Override public String toString() {
        return "DatabaseConnection{" + "uid='" + uid + '\'' + ", name='" + name + '\'' + ", dbType='" + dbType + '\''
            + ", database='" + database + '\'' + ", username='" + username + '\'' + ", password='" + password + '\''
            + ", host='" + host + '\'' + ", port=" + port + ", config='" + config + '\'' + ", description='"
            + description + '\'' + ", createdAt=" + createdAt + ", updatedAt=" + updatedAt + ", deletedAt=" + deletedAt
            + '}';
    }
}
