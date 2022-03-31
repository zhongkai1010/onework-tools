package com.onework.tools.server.database;

import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.onework.tools.domain.database.ConnectionRepository;
import com.onework.tools.domain.database.dao.Connection;
import com.onework.tools.server.database.entity.DatabaseConnection;
import com.onework.tools.server.database.error.DatabaseServerException;
import com.onework.tools.server.database.service.IDatabaseConnectionService;

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

    private final IDatabaseConnectionService databaseConnectionService;

    public ConnectionRepositoryImpl(IDatabaseConnectionService databaseConnectionService) {
        this.databaseConnectionService = databaseConnectionService;
    }

    @Override
    public Connection getConnectionByName(String name) {

        DatabaseConnection databaseConnection = getByName(name);
        if (databaseConnection == null) {
            return null;
        }
        Connection connection = new Connection();
        BeanUtils.copyProperties(databaseConnection, connection,DatabaseConnection.class);
        return connection;
    }

    @Override
    public void deleteConnection(String name) throws DatabaseServerException {
        DatabaseConnection databaseConnection = getByName(name);
        if (!databaseConnectionService.removeById(databaseConnection)) {
            throw new DatabaseServerException(ServerDatabaseModule.DELETE_CONNECTION);
        }
    }

    @Override
    public void addConnection(Connection connection) throws DatabaseServerException {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        BeanUtils.copyProperties(connection, databaseConnection);
        if (!databaseConnectionService.save(databaseConnection)) {
            throw new DatabaseServerException(ServerDatabaseModule.ADD_CONNECTION);
        }
    }

    @Override
    public void updateConnection(Connection connection) throws DatabaseServerException {

        DatabaseConnection databaseConnection = new DatabaseConnection();
        BeanUtils.copyProperties(connection, databaseConnection);
        boolean result =
            databaseConnectionService.lambdaUpdate().eq(DatabaseConnection::getName, databaseConnection.getName())
                .update(databaseConnection);
        if (!result) {
            throw new DatabaseServerException(ServerDatabaseModule.UPDATE_CONNECTION);
        }
    }

    private DatabaseConnection getByName(String name) {
        LambdaQueryWrapper<DatabaseConnection> queryWrapper = new LambdaQueryWrapper<>();
        queryWrapper.eq(DatabaseConnection::getName, name);
        return databaseConnectionService.getOne(queryWrapper);
    }
}
