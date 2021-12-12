package com.onework.tools.database;

import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Component;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

/**
 * @ClassName: AbstractMetadataManager
 * @Description: 抽象数据库元数据管理器
 * @Author: 钟凯
 * @Date: 2021/12/14 22:02
 **/
@Component
@Slf4j
public abstract class AbstractMetadataManager implements DatabaseMetadataManager {

    public final DatabaseConnection databaseConnection;

    public AbstractMetadataManager(DatabaseConnection databaseConnection) {
        this.databaseConnection = databaseConnection;
    }

    protected Connection getConnection() {
        String url = databaseConnection.getUrl();
        try {
            return DriverManager.getConnection(url, databaseConnection.getUser(), databaseConnection.getPassword());
        } catch (SQLException e) {
            log.error("数据库操作失败，具体错误：" + e.getMessage());
            e.printStackTrace();
            return null;
        }
    }

    protected List<String> getDatabaseOrTableNames(String sql) {
        List<String> names = new ArrayList<>();
        try {
            Connection connection = this.getConnection();
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(sql);
            while (resultSet.next()) {
                String value = resultSet.getString(1);
                names.add(value);
            }
            resultSet.close();
            statement.close();
            connection.close();
        } catch (SQLException e) {
            log.error("数据库操作失败，失败原因：" + e.getMessage());
            e.printStackTrace();
        }
        return names;
    }

    protected List<DataBaseColumn> getDatabaseColumns(String sql) {
        List<DataBaseColumn> dataBaseColumns = new ArrayList<>();
        try {
            Connection connection = this.getConnection();
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(sql);
            while (resultSet.next()) {
                DataBaseColumn dataBaseColumn = new DataBaseColumn();
                dataBaseColumn.setName(resultSet.getString("name"));
                dataBaseColumn.setType(resultSet.getString("type"));
                dataBaseColumn.setLength(resultSet.getInt("length"));
                dataBaseColumn.setDescription(resultSet.getString("description"));
                dataBaseColumn.setPrecision(resultSet.getInt("precision"));
                dataBaseColumn.setLength(resultSet.getInt("length"));
                dataBaseColumn.setAllowNull(resultSet.getBoolean("allowNull"));
                dataBaseColumn.setPrimarykey(resultSet.getBoolean("primarykey"));
                dataBaseColumn.setDefaultValue(resultSet.getString("defaultValue"));
                dataBaseColumn.setOrder(resultSet.getInt("order"));
                dataBaseColumns.add(dataBaseColumn);
            }
            resultSet.close();
            statement.close();
            connection.close();
        } catch (SQLException e) {
            log.error("数据库操作失败，失败原因：" + e.getMessage());
            e.printStackTrace();
        }
        return dataBaseColumns;
    }

}
