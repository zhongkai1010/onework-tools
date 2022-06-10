package com.onework.tools.database.domain.repository.lmpl;

import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.database.DatabaseException;
import com.onework.tools.database.domain.repository.ConnectionRepository;
import com.onework.tools.database.domain.vo.ConnectionVo;
import com.onework.tools.database.entity.DatabaseConnection;
import com.onework.tools.database.mapper.DatabaseConnectionMapper;
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
    public ConnectionVo getConnectionByName(String name) {

        DatabaseConnection databaseConnection = getByName(name);
        if (databaseConnection == null) {
            return null;
        }
        ConnectionVo connection = new ConnectionVo();
        BeanUtils.copyProperties(databaseConnection, connection);
        return connection;
    }

    @Override
    public void deleteConnection(String name) {
        DatabaseConnection databaseConnection = getByName(name);
        if (databaseConnectionMapper.deleteById(databaseConnection) == 0) {
            throw new AppException(DatabaseException.DELETE_CONNECTION);
        }
    }

    @Override
    public void addConnection(ConnectionVo connection) {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        BeanUtils.copyProperties(connection, databaseConnection);

        if (databaseConnectionMapper.insert(databaseConnection) == 0) {
            throw new AppException(DatabaseException.ADD_CONNECTION);
        }

        connection.setUid(databaseConnection.getUid());
    }

    @Override
    public void updateConnection(ConnectionVo connection) {

        DatabaseConnection databaseConnection = new DatabaseConnection();
        BeanUtils.copyProperties(connection, databaseConnection);

        boolean result = new LambdaUpdateChainWrapper<>(databaseConnectionMapper).eq(DatabaseConnection::getName,
            databaseConnection.getName()).update(databaseConnection);

        if (!result) {
            throw new AppException(DatabaseException.UPDATE_CONNECTION);
        }
    }

    private DatabaseConnection getByName(String name) {
        return new LambdaQueryChainWrapper<>(databaseConnectionMapper).eq(DatabaseConnection::getName, name).one();
    }
}
