package com.onework.tools.domain.database.schema.imlp;

import com.onework.tools.domain.database.schema.DbSchemaServer;

import javax.sql.DataSource;

/**
 * @author Administrator
 */
public class MySqlDbSchemaServer extends DbSchemaServer {

    public MySqlDbSchemaServer(DataSource dataSource) {
        super(dataSource);
    }

    @Override
    protected String getDatabasesSql() {
        return "SELECT db.SCHEMA_NAME AS NAME FROM information_schema.`SCHEMATA` AS db WHERE db.SCHEMA_NAME NOT IN ('mysql','information_schema','performance_schema','sys')";
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
