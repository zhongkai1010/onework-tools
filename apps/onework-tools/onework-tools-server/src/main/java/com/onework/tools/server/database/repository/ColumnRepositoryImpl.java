package com.onework.tools.server.database.repository;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.core.toolkit.IdWorker;
import com.onework.tools.domain.database.dao.Column;
import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.repository.ColumnRepository;
import com.onework.tools.domain.database.schema.entity.DataColumn;
import com.onework.tools.server.database.DatabaseServerException;
import com.onework.tools.server.database.entity.DatabaseColumn;
import com.onework.tools.server.database.entity.DatabaseTable;
import com.onework.tools.server.database.mapper.DatabaseColumnMapper;
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
    public void addOrUpdateColumn(Column column) throws DatabaseServerException {

        //        int result;
        //
        //        DatabaseColumn databaseColumn =
        //            new LambdaQueryChainWrapper<>(databaseColumnMapper).eq(DatabaseColumn::getTbUid, column.getTbUid())
        //                .eq(DatabaseColumn::getCode, column.getName()).one();
        //
        //        if (databaseColumn == null) {
        //            databaseColumn = new DatabaseColumn();
        //            BeanUtil.copyProperties(column, databaseColumn);
        //            databaseColumn.setCnUid(column.getCnUid());
        //            databaseColumn.setDbUid(column.getDbUid());
        //            databaseColumn.setTbUid(column.getTbUid());
        //            databaseColumn.setCode(column.getName());
        //            databaseColumn.setIsNull(column.getAllowNull());
        //            databaseColumn.setIsUnique(column.getPrimarykey());
        //
        //            result = databaseColumnMapper.insert(databaseColumn);
        //        } else {
        //            BeanUtil.copyProperties(column, databaseColumn, new CopyOptions().ignoreNullValue());
        //            result = databaseColumnMapper.updateById(databaseColumn);
        //        }
        //
        //        if (result == 0) {
        //            throw new DatabaseServerException(ServerDatabaseModule.SAVE_COLUMN_ERROR);
        //        }
        //
        //        column.setUid(databaseColumn.getUid());
    }

    @Override
    public <T extends Throwable> void batchAddColumn(@NonNull List<Column> columns) throws T {
        ArrayList<DatabaseColumn> databaseColumns = new ArrayList<>();
        columns.forEach(column -> {
            column.setUid(IdWorker.getIdStr());
            DatabaseColumn databaseColumn = BeanUtil.copyProperties(column, DatabaseColumn.class);
            databaseColumn.setCreatedAt(LocalDateTime.now());
            databaseColumn.setCreatedAt(LocalDateTime.now());
            databaseColumns.add(databaseColumn);
        });
        databaseColumnMapper.insertBatch(databaseTables);
    }

    @Override
    public <T extends Throwable> void batchDeleteColumn(@NonNull Database database) throws T {
        databaseColumnMapper.deleteColumnByDatabase(database.getUid());
    }
}
