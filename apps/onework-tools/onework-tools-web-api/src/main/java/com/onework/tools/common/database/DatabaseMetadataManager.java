package com.onework.tools.common.database;

import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @ClassName: DataProviderFactory
 * @Description: 数据提供者工厂
 * @Author: 钟凯
 * @Date: 2021/12/8 22:04
 **/
@Component
public interface DatabaseMetadataManager {

    /**
     * 描述
     *
     * @return List<Database>
     */
    List<String> getDatabase();

    /**
     * 描述
     *
     * @param databaseName 数据库名称
     * @return List
     */
    List<String> getTables(String databaseName);

    /**
     * 描述
     *
     * @param databaseName 数据库名称
     * @param tableName    表名称
     * @return List<Column>
     */
    List<DataBaseColumn> getColumns(String databaseName, String tableName);
}
