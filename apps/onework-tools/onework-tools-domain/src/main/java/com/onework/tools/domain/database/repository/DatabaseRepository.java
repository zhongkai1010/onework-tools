package com.onework.tools.domain.database.repository;

import com.onework.tools.domain.database.dao.Database;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 17:05
 */
@Component
public interface DatabaseRepository {

    /**
     * 添加或修改数据库
     *
     * @param database: 数据库
     * @return void
     * @throws T
     */
    <T extends Throwable> void saveDatabase(Database database) throws T;

    /**
     * 插入数据库
     *
     * @param database: 数据库
     * @return void
     * @throws T
     */
    <T extends Throwable> void insertDatabase(Database database) throws T;

    /**
     * 修改数据库
     *
     * @param database: 数据库
     * @return void
     * @throws T
     */
    <T extends Throwable> void updateDatabase(Database database) throws T;

    /**
     * 根据名称获取数据库
     * @param connId
     * @param dbName
     * @return
     */
    Database getDatabaseByName(String connId, String dbName);
}
