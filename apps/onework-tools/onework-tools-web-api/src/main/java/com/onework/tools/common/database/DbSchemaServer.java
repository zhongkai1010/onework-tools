package com.onework.tools.common.database;

import com.onework.tools.common.database.model.DataBaseColumn;
import lombok.extern.slf4j.Slf4j;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.database
 * @Description: 描述
 * @date Date : 2022年03月23日 14:56
 */
@Slf4j
public abstract class DbSchemaServer {

    private final DbConnection dbConnection;

    protected DbSchemaServer(DbConnection dbConnection) {
        this.dbConnection = dbConnection;
    }

    /**
     * 描述
     *
     * @return List<Database>
     */
    public abstract ArrayList<String> getDatabase();

    /**
     * 描述
     *
     * @param databaseName 数据库名称
     * @return List
     */
    public abstract ArrayList<String> getTables(String databaseName);

    /**
     * 描述
     *
     * @param databaseName 数据库名称
     * @param tableName    表名称
     * @return List<Column>
     */
    public abstract ArrayList<DataBaseColumn> getColumns(String databaseName, String tableName);

    /**
     * @param sql
     * @return
     */
    protected ArrayList<String> getDatabaseOrTableNames(String sql) {
        ArrayList<String> names = new ArrayList<>();
        try (Connection connection = dbConnection.getConnection(); Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(sql)) {
            while (resultSet.next()) {
                String value = resultSet.getString(1);
                names.add(value);
            }
        } catch (SQLException e) {
            log.error("数据库操作失败，失败原因：" + e.getMessage());
            e.printStackTrace();
        }
        return names;
    }

    protected ArrayList<DataBaseColumn> getDatabaseColumns(String sql) {
        ArrayList<DataBaseColumn> dataBaseColumns = new ArrayList<>();
        try (Connection connection = this.dbConnection.getConnection();
            Statement statement = connection.createStatement(); ResultSet resultSet = statement.executeQuery(sql)) {
            while (resultSet.next()) {
                DataBaseColumn dataBaseColumn = new DataBaseColumn();
                dataBaseColumn.setName(resultSet.getString("name"));
                dataBaseColumn.setType(resultSet.getString("type"));
                dataBaseColumn.setLength(resultSet.getInt("length"));
                dataBaseColumn.setDescription(resultSet.getString("description"));
                dataBaseColumn.setPrecision(resultSet.getInt("precision"));
                dataBaseColumn.setAllowNull(resultSet.getBoolean("allowNull"));
                dataBaseColumn.setPrimarykey(resultSet.getBoolean("primarykey"));
                dataBaseColumn.setDefaultValue(resultSet.getString("defaultValue"));
                dataBaseColumn.setOrder(resultSet.getInt("order"));
                dataBaseColumns.add(dataBaseColumn);
            }
        } catch (SQLException e) {
            log.error("数据库操作失败，失败原因：" + e.getMessage());
            e.printStackTrace();
        }
        return dataBaseColumns;
    }
}
