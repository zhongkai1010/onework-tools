package com.onework.tools.common.database;

import lombok.Getter;
import lombok.extern.slf4j.Slf4j;

import java.sql.Connection;
import java.sql.Driver;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 * @author Administrator
 */
@Slf4j
public class DbConnection {

    @Getter
    private final DatabaseType databaseType;
    private String host;
    private String user;
    private String password;
    private Integer port;
    private String database;

    private Connection connection;

    private DbConnection(DatabaseType type) {
        this.databaseType = type;
    }

    public static DbConnection create(DatabaseType type) {

        return new DbConnection(type);
    }

    public DbConnection host(String host) {
        this.host = host;
        return this;
    }

    public DbConnection port(Integer port) {
        this.port = port;
        return this;
    }

    public DbConnection user(String user) {
        this.user = user;
        return this;
    }

    public DbConnection password(String password) {
        this.password = password;
        return this;
    }

    public DbConnection database(String database) {
        this.database = database;
        return this;
    }

    public DbConnection build() {
        try {
            Driver driver = this.databaseType.getDriver();
            DriverManager.registerDriver(driver);

            String url = getUrl();
            if (user != null && password != null) {
                this.connection = DriverManager.getConnection(url, user, password);
            } else {
                this.connection = DriverManager.getConnection(url);
            }

            return this;
        } catch (Exception e) {
            log.error("DbConnection get Connection is error", e);
            return null;
        }
    }

    public Connection getConnection() {
        try {
            if (connection == null) {
                build();
            }
            if (connection.isClosed()) {
                build();
            }
            return connection;
        } catch (Exception e) {
            log.error("DbConnection getConnection is error", e);
            return null;
        }
    }

    /**
     * 获取jdbc的url
     *
     * @return jdbc的url
     */
    private String getUrl() {
        String url = null;

        if (databaseType == DatabaseType.MYSQL) {
            url = String.format("jdbc:mysql://%s:%s/%s", host, port == null ? "1433" : port, database);
        }

        if (databaseType == DatabaseType.MSSQL) {
            url = String.format("jdbc:sqlserver://%s:%s;databaseName=%s", host, port, database);
        }

        if (url == null) {
            log.error("DatabaseType get Url is error, not find dbType");
        } else {
            log.info(String.format("DatabaseType get url is %s", url));
        }
        return url;
    }
}
