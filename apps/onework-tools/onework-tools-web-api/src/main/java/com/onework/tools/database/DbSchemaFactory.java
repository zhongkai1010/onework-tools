package com.onework.tools.database;

import com.onework.tools.database.schema.MsSqlSchemaServer;
import com.onework.tools.database.schema.MySqlDbSchemaServer;
import lombok.extern.slf4j.Slf4j;

import javax.validation.constraints.NotNull;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.database
 * @Description: 描述
 * @date Date : 2022年03月23日 15:21
 */
@Slf4j
public class DbSchemaFactory {

    public static DbSchemaServer getDbSchemaServer(@NotNull DatabaseType databaseType, @NotNull String host,
        Integer port, @NotNull String database, @NotNull String user, @NotNull String password) {
        DbConnection dbConnection =
            DbConnection.create(databaseType).host(host).port(port).user(user).password(password).database(database).build();
        return getDbSchemaServer(dbConnection);
    }

    public static DbSchemaServer getDbSchemaServer(@NotNull DatabaseType databaseType, @NotNull String host,
        @NotNull String database, @NotNull String user, @NotNull String password) {

        return getDbSchemaServer(databaseType, host, null, database, user, password);
    }

    public static DbSchemaServer getDbSchemaServer(DbConnection dbConnection) {
        if (dbConnection.getDatabaseType() == DatabaseType.MSSQL) {
            return getMsSqlSchemaServer(dbConnection);
        }
        if (dbConnection.getDatabaseType() == DatabaseType.MYSQL) {
            return getMysqlSchemaServer(dbConnection);
        }
        log.error("DbSchemaFactory getDbSchemaServer DatabaseType value is not find");

        return null;
    }

    public static DbSchemaServer getMysqlSchemaServer(DbConnection dbConnection) {

        if (dbConnection == null) {
            log.error("DbSchemaFactory getMysqlSchemaServer connection is null");
            return null;
        }

        return new MySqlDbSchemaServer(dbConnection);
    }

    public static DbSchemaServer getMsSqlSchemaServer(DbConnection dbConnection) {

        if (dbConnection == null) {
            log.error("DbSchemaFactory getMsSqlSchemaServer connection is null");
            return null;
        }
        return new MsSqlSchemaServer(dbConnection);
    }
}


