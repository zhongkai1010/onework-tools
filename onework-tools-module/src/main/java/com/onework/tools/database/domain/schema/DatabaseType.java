package com.onework.tools.database.domain.schema;

import lombok.extern.slf4j.Slf4j;

import java.sql.Driver;
import java.util.HashMap;

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

    public static final HashMap<String, DatabaseType> Map = new HashMap<String, DatabaseType>() {
        private static final long serialVersionUID = 4123027492945398091L;

        {
            put("mssql", DatabaseType.MSSQL);
            put("mysql", DatabaseType.MYSQL);
        }
    };

    public Driver getDriver() {
        try {
            return (Driver)Class.forName(className).newInstance();
        } catch (Exception e) {
            log.error("DatabaseType get Driver is error", e);
        }
        return null;
    }
}
