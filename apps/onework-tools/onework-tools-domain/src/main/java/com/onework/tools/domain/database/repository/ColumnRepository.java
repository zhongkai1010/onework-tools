package com.onework.tools.domain.database.repository;

import com.onework.tools.domain.database.dao.Column;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 17:29
 */
@Component
public interface ColumnRepository {

    /**
     * 添加数据库字段
     *
     * @param column: 数据库
     * @return void
     * @throws T
     */
    <T extends Throwable> void addOrUpdateColumn(Column column) throws T;
}
