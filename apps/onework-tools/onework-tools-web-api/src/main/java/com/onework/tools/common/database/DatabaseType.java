package com.onework.tools.common.database;

import lombok.extern.slf4j.Slf4j;

import java.sql.Driver;

/**
 * 描述
 *
 * @author ZK
 */
@Slf4j
public class DatabaseType {

    private final String className;

    public DatabaseType(String className) {
        this.className = className;
    }

    public static final DatabaseType MYSQL = new DatabaseType("com.mysql.cj.jdbc.Driver");

    public static final DatabaseType MSSQL = new DatabaseType("com.microsoft.sqlserver.jdbc.SQLServerDriver");

    public Driver getDriver() {
        try {
            return (Driver)Class.forName(className).newInstance();
        } catch (Exception e) {
            log.error("DatabaseType get Driver is error", e);
        }
        return null;
    }
}
