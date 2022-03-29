package com.onework.tools.domain.database;

import com.onework.tools.domain.database.dao.Connection;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.datamodel
 * @Description: 描述
 * @date Date : 2022年03月29日 11:22
 */
@Component
public interface ConnectionRepository {

    /**
     * 根据名称获取数据库连接
     *
     * @param name 名称
     * @return
     */
    Connection getConnectionByName(String name);

    /**
     * 根据名称删除数据库连接
     *
     * @param name
     */
    void deleteConnection(String name);

    /**
     * 新增数据库连接
     *
     * @param connection
     */
    void addOrUpdateConnection(Connection connection);

}
