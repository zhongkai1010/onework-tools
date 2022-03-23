package com.onework.tools.common.database.schema;

import com.onework.tools.common.database.DbConnection;
import com.onework.tools.common.database.DbSchemaServer;
import com.onework.tools.common.database.model.DataBaseColumn;

import java.sql.Connection;
import java.util.ArrayList;

/**
 * @author Administrator
 */
public class MySqlDbSchemaServer extends DbSchemaServer {

    public MySqlDbSchemaServer(DbConnection dbConnection) {
        super(dbConnection);
    }

    @Override
    public ArrayList<String> getDatabase() {
        String sql = "SELECT db.SCHEMA_NAME AS NAME FROM information_schema.`SCHEMATA` AS db";
        return getDatabaseOrTableNames(sql);
    }

    @Override
    public ArrayList<String> getTables(String databaseName) {
        String sql = "SELECT db.TABLE_NAME FROM information_schema.`TABLES` AS db WHERE db.TABLE_SCHEMA = '%s'";
        return getDatabaseOrTableNames(String.format(sql, databaseName));
    }

    @Override
    public ArrayList<DataBaseColumn> getColumns(String databaseName, String tableName) {
        String sql =
            "SELECT ORDINAL_POSITION AS `order`, COLUMN_DEFAULT AS `defaultValue`, COLUMN_NAME AS `name`, DATA_TYPE AS `type`, COLUMN_COMMENT AS `description`, IFNULL( NUMERIC_PRECISION, 0) AS `precision`, IFNULL( CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION ) AS `length`,( CASE IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END ) AS `allowNull`, ( CASE COLUMN_KEY WHEN 'PRI' THEN 1 ELSE 0 END ) AS `primarykey` FROM information_schema.`COLUMNS` WHERE TABLE_SCHEMA = '%s' AND TABLE_NAME = '%s'";
        return getDatabaseColumns(String.format(sql, databaseName, tableName));
    }
}

