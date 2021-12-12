package com.onework.tools.database;

import lombok.*;

/**
 *
 *
 * @author ZK
 */
@Setter
@Getter
public class DatabaseConnection {

    /**
     * 数据库连接字符串
     */
    @NonNull
    private String host;

    /**
     * 数据库类型
     */
    @NonNull
    private DatabaseType dbType;

    /**
     * 数据库用户名
     */
    @NonNull
    private String user;

    /**
     * 数据库密码
     */
    @NonNull
    private String password;

    /**
     * 数据库
     */
    @NonNull
    private String database;

    /**
     * 端口
     */
    @NonNull
    private Integer port;

    /**
     * 获取jdbc连接url
     * 
     * @return String
     */
    public String getUrl() {
        switch (dbType) {
            case MSSQL:
                return String.format("jdbc:sqlserver://%s:%s;DatabaseName=%s", host, port, database);
            case MYSQL:
                return String.format("jdbc:mysql://%s:%s/%s", host, port, database);
            default:
                return "";
        }
    }
}
