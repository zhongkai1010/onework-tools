package com.onework.tools.server.database.repository;

import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.domain.database.dao.Column;
import com.onework.tools.domain.database.repository.ColumnRepository;
import com.onework.tools.server.database.DatabaseServerException;
import com.onework.tools.server.database.ServerDatabaseModule;
import com.onework.tools.server.database.entity.DatabaseColumn;
import com.onework.tools.server.database.mapper.DatabaseColumnMapper;
import org.springframework.beans.BeanUtils;
import org.springframework.stereotype.Repository;

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

        int result;

        DatabaseColumn databaseColumn = new LambdaQueryChainWrapper<>(databaseColumnMapper).eq(DatabaseColumn::getTbUid,
            column.getTbUid()).eq(DatabaseColumn::getCode, column.getName()).one();

        if (databaseColumn == null) {
            databaseColumn = new DatabaseColumn();
            BeanUtils.copyProperties(column, databaseColumn);
            databaseColumn.setCnUid(column.getCnUid());
            databaseColumn.setDbUid(column.getDbUid());
            databaseColumn.setTbUid(column.getUid());
            result = databaseColumnMapper.insert(databaseColumn);
        } else {
            BeanUtils.copyProperties(column, databaseColumn);
            result = databaseColumnMapper.updateById(databaseColumn);
        }

        if (result == 0) {
            throw new DatabaseServerException(ServerDatabaseModule.SAVE_COLUMN_ERROR);
        }

        column.setUid(databaseColumn.getUid());
    }
}
