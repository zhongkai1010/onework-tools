package com.onework.tools.domain.database;

import com.onework.tools.domain.database.dao.Column;
import com.onework.tools.domain.database.dao.Table;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 17:29
 */
public interface ColumnRepository {

    /**
     * 添加数据库字段
     *
     * @param column
     * @param table
     */
    void addOrUpdateColumn(Table table, Column column);
}
