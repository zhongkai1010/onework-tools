package com.onework.tools.database.schema;

import com.onework.tools.database.DbConnection;
import com.onework.tools.database.DbSchemaServer;

/**
 * @author Administrator
 */
public class MySqlDbSchemaServer extends DbSchemaServer {

    public MySqlDbSchemaServer(DbConnection dbConnection) {
        super(dbConnection);
    }

    @Override
    protected String getDatabasesSql() {
        return "SELECT db.SCHEMA_NAME AS NAME FROM information_schema.`SCHEMATA` AS db";
    }

    @Override
    protected String getTablesSql(String dbName) {
        return String.format(
            "SELECT db.TABLE_NAME AS NAME FROM information_schema.`TABLES` AS db WHERE db.TABLE_SCHEMA = '%s'", dbName);
    }

    @Override
    protected String getColumnsSql(String dbName, String dbTable) {
        return String.format(
            "SELECT ORDINAL_POSITION AS `order`, COLUMN_DEFAULT AS `defaultValue`, COLUMN_NAME AS `name`, DATA_TYPE AS `type`, COLUMN_COMMENT AS `description`, IFNULL( NUMERIC_PRECISION, 0) AS `precision`, IFNULL( CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION ) AS `length`,( CASE IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END ) AS `allowNull`, ( CASE COLUMN_KEY WHEN 'PRI' THEN 1 ELSE 0 END ) AS `primarykey` FROM information_schema.`COLUMNS` WHERE TABLE_SCHEMA = '%s' AND TABLE_NAME = '%s'",
            dbName, dbTable);
    }
}
