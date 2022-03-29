package com.onework.tools.domain.database;

import com.onework.tools.domain.database.dao.Connection;
import org.springframework.stereotype.Service;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 10:11
 */
@Service
public interface DatabaseService {

    /**
     * 新增或修改数据库连接
     *
     * @param connection
     * @param sync
     * @throws DatabaseDomainException
     */
    void saveConnection(Connection connection, Boolean sync) throws DatabaseDomainException;

    /**
     * 测试数据库连接
     *
     * @param connection
     * @return
     */
    Boolean testConnection(Connection connection) throws DatabaseDomainException;

    /**
     * 删除连接
     *
     * @param connection
     */
    void deleteConnection(Connection connection);

    /**
     * 同步数据库
     *
     * @param connection
     * @throws DatabaseDomainException
     */
    void syscDatabase(Connection connection) throws DatabaseDomainException;
}
