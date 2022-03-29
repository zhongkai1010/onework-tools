package com.onework.tools.domain.database;

import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.dao.Table;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.schema
 * @Description: 描述
 * @date Date : 2022年03月29日 17:29
 */
public interface TableRepository {

    /**
     * 添加数据库表
     *
     * @param database
     * @param table
     */
    void addOrUpdateTable(Database database, Table table);
}
