package com.onework.tools.domain.database.repository;

import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.dao.Table;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.schema
 * @Description: 描述
 * @date Date : 2022年03月29日 17:29
 */
@Component
public interface TableRepository {

    /**
     * 添加或修改数据表
     *
     * @param table: 数据库
     * @return void
     * @throws T
     */
    <T extends Throwable> void addOrUpdateTable(Table table) throws T;

    /**
     * 批量处理数据库表
     * @param database
     * @param tables
     * @param <T>
     * @throws T
     */
    <T extends Throwable> void batchAddOrUpdateTable(Database database, List<Table> tables) throws T;
}
