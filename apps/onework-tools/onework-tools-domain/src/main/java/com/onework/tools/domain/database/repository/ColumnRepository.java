package com.onework.tools.domain.database.repository;

import com.onework.tools.domain.database.dao.Column;
import com.onework.tools.domain.database.dao.Database;
import lombok.NonNull;
import org.springframework.stereotype.Component;

import java.util.List;

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
     * 批量添加字段
     *
     * @param columns: 字段集合
     * @return void
     * @throws T
     */
    <T extends Throwable> void batchAddColumn(@NonNull List<Column> columns) throws T;

    /**
     * 根据数据库批量删除字段
     *
     * @param database
     * @param <T>
     * @throws T
     */
    <T extends Throwable> void batchDeleteColumn(@NonNull Database database) throws T;
}
