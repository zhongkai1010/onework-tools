package com.onework.tools.database;

import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Component;

import java.sql.Driver;
import java.util.List;

/**
 * @ClassName: MysqlDatabaseMetadataManager
 * @Description: Mysql数据库管理器
 * @Author: 钟凯
 * @Date: 2021/12/14 21:25
 **/
@Component
@Slf4j
public class MysqlDatabaseMetadataManager extends AbstractMetadataManager {

    public MysqlDatabaseMetadataManager(DatabaseConnection databaseConnection) {
        super(databaseConnection);
    }

    /**
     * 返回jdbc驱动
     *
     * @return Driver
     */
    @Override
    protected Driver getDriver() {
        return new com.microsoft.sqlserver.jdbc.SQLServerDriver();
    }

    /**
     * 描述
     *
     * @return List<Database>
     */
    @Override
    public List<String> getDatabase() {
        String sql = "SELECT db.SCHEMA_NAME AS NAME FROM information_schema.`SCHEMATA` AS db";
        return getDatabaseOrTableNames(sql);
    }

    /**
     * 描述
     *
     * @return List
     */
    @Override
    public List<String> getTables(String databaseName) {
        String sql = "SELECT db.TABLE_NAME FROM information_schema.`TABLES` AS db WHERE db.TABLE_SCHEMA = '%s'";
        return getDatabaseOrTableNames(String.format(sql, databaseName));
    }

    /**
     * 描述
     *
     * @param databaseName
     *            数据库名称
     * @param tableName
     *            表名称
     * @return List<Column>
     */
    @Override
    public List<DataBaseColumn> getColumns(String databaseName, String tableName) {
        String sql =
            "SELECT ORDINAL_POSITION AS `order`, COLUMN_DEFAULT AS `defaultValue`, COLUMN_NAME AS `name`, DATA_TYPE AS `type`, COLUMN_COMMENT AS `description`, IFNULL( NUMERIC_PRECISION, 0) AS `precision`, IFNULL( CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION ) AS `length`,( CASE IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END ) AS `allowNull`, ( CASE COLUMN_KEY WHEN 'PRI' THEN 1 ELSE 0 END ) AS `primarykey` FROM information_schema.`COLUMNS` WHERE TABLE_SCHEMA = '%s' AND TABLE_NAME = '%s'";
        return getDatabaseColumns(String.format(sql, databaseName, tableName));
    }
}
