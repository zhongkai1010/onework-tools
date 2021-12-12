package com.onework.tools.database;

import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @ClassName: MssqlDatabaseMetadataManager
 * @Description: sql
 * @Author: 钟凯
 * @Date: 2021/12/14 21:25
 **/
@Component
@Slf4j
public class MssqlDatabaseMetadataManager extends AbstractMetadataManager {

    public MssqlDatabaseMetadataManager(DatabaseConnection databaseConnection) {
        super(databaseConnection);
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
    public List<String> getTables(String tableName) {
        String sql = "SELECT db.TABLE_NAME FROM information_schema.`TABLES` AS db WHERE db.TABLE_SCHEMA = '%s'";
        return getDatabaseOrTableNames(String.format(sql, tableName));
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
            "SELECT COLUMN_NAME AS `name`, DATA_TYPE AS `type`, CHARACTER_MAXIMUM_LENGTH AS `length`, NUMERIC_SCALE AS `precision`, COLUMN_COMMENT AS `description`,( CASE IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END) AS `allowNull`, ( CASE COLUMN_KEY WHEN 'PRI' THEN 1 ELSE 0 END ) AS `primarykey` FROM information_schema.`COLUMNS` WHERE TABLE_SCHEMA = '%s' AND TABLE_NAME = '%s'";
        return getDatabaseColumns(String.format(sql, databaseName, tableName));
    }
}
