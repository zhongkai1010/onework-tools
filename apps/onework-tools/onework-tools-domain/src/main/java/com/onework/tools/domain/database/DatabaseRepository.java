package com.onework.tools.domain.database;

import com.onework.tools.domain.database.dao.Connection;
import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.schema.DataDatabase;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 17:05
 */
public interface DatabaseRepository {

    /**
     * 添加数据库
     *
     * @param connectionName
     * @param database
     * @return
     */
    void addOrUpdateDatabase(String connectionName, Database database);

}
