package com.onework.tools.database.schema.entity;

import com.onework.tools.database.schema.DatabaseType;
import com.zaxxer.hikari.HikariConfig;
import com.zaxxer.hikari.HikariDataSource;
import lombok.Getter;
import lombok.extern.slf4j.Slf4j;

import javax.sql.DataSource;

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

    private DbConnection(DatabaseType type) {
        databaseType = type;
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

    public DataSource build() {
        try {

            String url = getUrl();
            HikariConfig config = new HikariConfig();
            config.setJdbcUrl(url);
            config.setUsername(user);
            config.setPassword(password);
            config.setConnectionTimeout(5000);

            return new HikariDataSource(config);

        } catch (Exception e) {
            log.error(String.format("DbConnection get Connection is error,%s", e.getMessage()), e);
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
            url = String.format("jdbc:mysql://%s:%s/%s", host, port == null ? "1433" : port,
                database == null ? "master" : database);
        }

        if (databaseType == DatabaseType.MSSQL) {
            url = String.format("jdbc:sqlserver://%s:%s;databaseName=%s", host, port == null ? "3306" : port,
                database == null ? "mysql" : database);
        }

        if (url == null) {
            log.error("DatabaseType get Url is error, not find dbType");
        }

        return url;
    }
}
