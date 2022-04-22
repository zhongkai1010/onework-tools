package com.onework.tools.database.schema;

import com.onework.tools.database.schema.entity.DbConnection;
import com.onework.tools.database.schema.imlp.MsSqlSchemaServer;
import com.onework.tools.database.schema.imlp.MySqlDbSchemaServer;
import lombok.extern.slf4j.Slf4j;

import javax.sql.DataSource;
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

        DataSource dataSource =
            DbConnection.create(databaseType).host(host).port(port).user(user).password(password).database(database)
                .build();

        return getDbSchemaServer(databaseType, dataSource);
    }

    public static DbSchemaServer getDbSchemaServer(@NotNull DatabaseType databaseType, @NotNull String host,
        @NotNull String database, @NotNull String user, @NotNull String password) {

        return getDbSchemaServer(databaseType, host, null, database, user, password);
    }

    public static DbSchemaServer getDbSchemaServer(@NotNull DatabaseType databaseType, DataSource dataSource) {

        if (databaseType == DatabaseType.MSSQL) {
            return getMsSqlSchemaServer(dataSource);
        }
        if (databaseType == DatabaseType.MYSQL) {
            return getMysqlSchemaServer(dataSource);
        }
        log.error("DbSchemaFactory getDbSchemaServer DatabaseType value is not find");

        return null;
    }

    public static DbSchemaServer getMysqlSchemaServer(DataSource dataSource) {

        if (dataSource == null) {
            log.error("DbSchemaFactory getMysqlSchemaServer connection is null");
            return null;
        }

        return new MySqlDbSchemaServer(dataSource);
    }

    public static DbSchemaServer getMsSqlSchemaServer(DataSource dataSource) {

        if (dataSource == null) {
            log.error("DbSchemaFactory getMsSqlSchemaServer connection is null");
            return null;
        }
        return new MsSqlSchemaServer(dataSource);
    }
}


