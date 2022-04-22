package com.onework.tools.database.dao.repository;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.core.toolkit.IdWorker;
import com.onework.tools.database.dao.entity.DatabaseColumn;
import com.onework.tools.database.dao.mapper.DatabaseColumnMapper;
import com.onework.tools.database.domain.entity.Column;
import com.onework.tools.database.domain.entity.Table;
import com.onework.tools.database.domain.repository.ColumnRepository;
import lombok.NonNull;
import org.springframework.stereotype.Repository;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.database
 * @Description: 描述
 * @date Date : 2022年03月31日 10:48
 */
@Repository
public class ColumnRepositoryImpl implements ColumnRepository {

    private final DatabaseColumnMapper databaseColumnMapper;

    public ColumnRepositoryImpl(DatabaseColumnMapper databaseColumnMapper) {
        this.databaseColumnMapper = databaseColumnMapper;
    }

    @Override
    public void batchAddColumn(@NonNull List<Column> columns) {
        ArrayList<DatabaseColumn> databaseColumns = new ArrayList<>();
        columns.forEach(column -> {
            column.setUid(IdWorker.getIdStr());
            DatabaseColumn databaseColumn = BeanUtil.copyProperties(column, DatabaseColumn.class);
            databaseColumn.setCode(column.getDbName());
            databaseColumn.setCreatedAt(LocalDateTime.now());
            databaseColumn.setUpdatedAt(LocalDateTime.now());
            databaseColumns.add(databaseColumn);
        });
        databaseColumnMapper.insertBatch(databaseColumns);
    }

    @Override
    public void batchDeleteColumn(@NonNull Table table) {
        databaseColumnMapper.deleteTableColumn(table.getUid());
    }
}