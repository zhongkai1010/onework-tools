package com.onework.tools.database.domain.repository;

import com.onework.tools.database.domain.vo.DatabaseVo;
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
     */
    void saveDatabase(DatabaseVo database);

    /**
     * 插入数据库
     *
     * @param database: 数据库
     */
    void insertDatabase(DatabaseVo database);

    /**
     * 修改数据库
     *
     * @param database: 数据库
     * @return void
     */
    void updateDatabase(DatabaseVo database);

    /**
     * 根据名称获取数据库
     *
     * @param connId
     * @param dbName
     * @return
     */
    DatabaseVo getDatabaseByName(String connId, String dbName);
}
