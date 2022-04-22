package com.onework.tools.database.domain.repository;

import com.onework.tools.database.domain.entity.Column;
import com.onework.tools.database.domain.entity.Table;
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
     */
    void batchAddColumn(@NonNull List<Column> columns);

    /**
     * 根据数据库批量删除字段
     *
     * @param table
     */
    void batchDeleteColumn(@NonNull Table table);

}
