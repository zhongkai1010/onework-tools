package com.onework.tools.database;

import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.baomidou.mybatisplus.core.toolkit.Wrappers;
import com.onework.tools.generator.entity.DatabaseColumn;
import com.onework.tools.generator.entity.DatabaseConnection;
import com.onework.tools.generator.mapper.DatabaseConnectionMapper;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDateTime;
import java.util.ArrayList;

/**
 * @ClassName: DatabaseManagerImpl
 * @Description: 数据库管理器
 * @Author: 钟凯
 * @Date: 2021/12/8 1:27
 **/
@Service
@RequiredArgsConstructor
public class DatabaseManagerImpl implements DatabaseManager {

    private final DataProviderFactory dataProviderFactory;

    private final DatabaseConnectionMapper databaseConnectionMapper;

    /**
     * 判断连接是否存在 true:存在，false，不存在
     *
     * @return boolean
     */
    @Override
    public boolean connectionExist(Connection connection) {
        LambdaQueryWrapper<DatabaseConnection> userQueryWrapper = Wrappers.lambdaQuery();
        userQueryWrapper
            .eq(DatabaseConnection::getHost, connection.getDatabaseHost())
            .eq(DatabaseConnection::getPort,connection.getPort())
            .eq(DatabaseConnection::getDbType,connection.getDbType());
        long count = databaseConnectionMapper.selectCount(userQueryWrapper);
        return count > 0;
    }

    /**
     * 添加数据库连接
     *
     */
    @Override
    @Transactional(rollbackFor = Exception.class)
    public void addConnection(Connection connection) {
        if (this.connectionExist(connection)) {
            throw new RuntimeException("connection");
        }
        DatabaseConnection databaseConnection = new DatabaseConnection();
        databaseConnection
            .setName(connection.getName())
            .setDbType(connection.getDbType().toString())
            .setUsername(connection.getDataBaseUserName())
            .setPassword(connection.getDatabasePassword())
            .setHost(connection.getDatabaseHost())
            .setPort(connection.getPort())
            .setUsername("sa")
            .setPassword("123456")
            .setCreatedAt(LocalDateTime.now())
            .setUpdatedAt(LocalDateTime.now());


        databaseConnectionMapper.insert(databaseConnection);
    }

    /**
     * 修改数据库连接
     *
     */
    @Override
    public void updateConnection(Connection connection) {
        LambdaQueryWrapper<DatabaseConnection> userQueryWrapper;
        userQueryWrapper = Wrappers.lambdaQuery();
        userQueryWrapper
            .eq(DatabaseConnection::getHost, connection.getDatabaseHost())
            .eq(DatabaseConnection::getPort, connection.getPort())
            .eq(DatabaseConnection::getDbType, connection.getDbType());
        DatabaseConnection databaseConnection = databaseConnectionMapper.selectOne(userQueryWrapper);
        if (databaseConnection == null) {
            throw new NullPointerException("connection");
        }
        databaseConnection.setPassword(connection.getDatabasePassword());
        databaseConnectionMapper.updateById(databaseConnection);
    }

    /**
     * 删除数据库连接
     *
     * @param connection
     *            数据库连接
     */
    @Override
    public void deleteConnection(Connection connection) {
        LambdaQueryWrapper<DatabaseConnection> userQueryWrapper = Wrappers.lambdaQuery();
        userQueryWrapper.eq(DatabaseConnection::getHost, connection.getDatabaseHost()).eq(DatabaseConnection::getPort,
            connection.getPort());
        DatabaseConnection databaseConnection = databaseConnectionMapper.selectOne(userQueryWrapper);
        databaseConnectionMapper.deleteById(databaseConnection);
    }

    /**
     * 获取所有数据库连接
     *
     * @return ArrayList<DataBaseConnection>
     */
    @Override
    public ArrayList<Connection> getAllConnections() {
        return null;
    }

    /**
     * 检查数据库连接是否正常
     *
     * @param connection
     *            数据库库连接
     * @return boolean true：正常，false：无法连接
     */
    @Override
    public boolean authenticateConnection(Connection connection) {
        return false;
    }

    /**
     * 获取离线和在线数据库
     *
     * @param connection
     *            数据库连接
     * @return ArrayList<Database> 数据库表
     */
    @Override
    public ArrayList<Database> getAllDatabase(Connection connection) {
        return null;
    }

    /**
     * 获取在线数据库
     *
     * @param connection
     *            数据库连接
     * @return ArrayList<Database> 数据库表
     */
    @Override
    public ArrayList<Database> getOnlineDatabase(Connection connection) {
        DataProvider dataProvider = dataProviderFactory.getDataProvider(connection.getDbType());
        ArrayList<Database> database = dataProvider.getDatabase(connection);
        database.forEach((v) -> v.setSyncStatus(true));
        return database;
    }

    /**
     * 获取离线数据库
     *
     * @param connection
     *            数据库连接
     * @return ArrayList<Database> 数据库表
     */
    @Override
    public ArrayList<Database> getOfflineDatabase(Connection connection) {
        return null;
    }

    /**
     * 获取在线数据库表字段
     *
     * @param database
     *            表
     * @return ArrayList<DataBaseTable> 表
     */
    @Override
    public ArrayList<Table> getOnlineTables(Database database) {
        return null;
    }

    /**
     * 获取离线表表字段
     *
     * @param database
     *            数据库
     * @return ArrayList<DataBaseTable> 表
     */
    @Override
    public ArrayList<Table> getOfflineTables(Database database) {
        return null;
    }

    /**
     * 获取在线表字段
     *
     * @param table
     *            表
     * @return ArrayList<DatabaseColumn> 字段
     */
    @Override
    public ArrayList<DatabaseColumn> getOnlineColumns(Table table) {
        return null;
    }

    /**
     * 获取离线表字段
     *
     * @param table
     *            表
     * @return ArrayList<DatabaseColumn> 字段
     */
    @Override
    public ArrayList<DatabaseColumn> getOfflineColumns(Table table) {
        return null;
    }

    /**
     * 获取所有字段
     *
     * @return ArrayList<DatabaseColumn>
     */
    @Override
    public ArrayList<DatabaseColumn> getAllColumns() {
        return null;
    }

}
