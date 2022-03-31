package com.onework.tools.domain.database.repository;

import com.onework.tools.domain.database.dao.Table;
import org.springframework.stereotype.Component;

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
}
