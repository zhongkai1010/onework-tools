package com.onework.tools.server.database.repository;

import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.onework.tools.domain.database.dao.Connection;
import com.onework.tools.domain.database.repository.ConnectionRepository;
import com.onework.tools.server.database.ServerDatabaseException;
import com.onework.tools.server.database.ServerDatabaseModule;
import com.onework.tools.server.database.entity.DatabaseConnection;
import com.onework.tools.server.database.mapper.DatabaseConnectionMapper;
import org.springframework.beans.BeanUtils;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.database
 * @Description: 描述
 * @date Date : 2022年03月31日 9:11
 */
@Repository
public class ConnectionRepositoryImpl implements ConnectionRepository {

    private final DatabaseConnectionMapper databaseConnectionMapper;

    public ConnectionRepositoryImpl(DatabaseConnectionMapper databaseConnectionMapper) {
        this.databaseConnectionMapper = databaseConnectionMapper;
    }

    @Override
    public Connection getConnectionByName(String name) {

        DatabaseConnection databaseConnection = getByName(name);
        if (databaseConnection == null) {
            return null;
        }
        Connection connection = new Connection();
        BeanUtils.copyProperties(databaseConnection, connection);
        return connection;
    }

    @Override
    public void deleteConnection(String name) throws ServerDatabaseException {
        DatabaseConnection databaseConnection = getByName(name);
        if (databaseConnectionMapper.deleteById(databaseConnection) == 0) {
            throw new ServerDatabaseException(ServerDatabaseModule.DELETE_CONNECTION);
        }
    }

    @Override
    public void addConnection(Connection connection) throws ServerDatabaseException {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        BeanUtils.copyProperties(connection, databaseConnection);

        if (databaseConnectionMapper.insert(databaseConnection) == 0) {
            throw new ServerDatabaseException(ServerDatabaseModule.ADD_CONNECTION);
        }

        connection.setUid(databaseConnection.getUid());
    }

    @Override
    public void updateConnection(Connection connection) throws ServerDatabaseException {

        DatabaseConnection databaseConnection = new DatabaseConnection();
        BeanUtils.copyProperties(connection, databaseConnection);

        boolean result = new LambdaUpdateChainWrapper<>(databaseConnectionMapper).eq(DatabaseConnection::getName,
            databaseConnection.getName()).update(databaseConnection);

        if (!result) {
            throw new ServerDatabaseException(ServerDatabaseModule.UPDATE_CONNECTION);
        }
    }

    private DatabaseConnection getByName(String name) {
        return new LambdaQueryChainWrapper<>(databaseConnectionMapper).eq(DatabaseConnection::getName, name).one();
    }
}
