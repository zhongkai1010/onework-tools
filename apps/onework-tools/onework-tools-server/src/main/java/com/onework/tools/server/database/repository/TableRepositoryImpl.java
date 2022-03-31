package com.onework.tools.server.database.repository;

import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.domain.database.dao.Table;
import com.onework.tools.domain.database.repository.TableRepository;
import com.onework.tools.server.database.DatabaseServerException;
import com.onework.tools.server.database.ServerDatabaseModule;
import com.onework.tools.server.database.entity.DatabaseTable;
import com.onework.tools.server.database.mapper.DatabaseTableMapper;
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
public class TableRepositoryImpl implements TableRepository {

    private final DatabaseTableMapper databaseTableMapper;

    public TableRepositoryImpl(DatabaseTableMapper databaseTableMapper) {
        this.databaseTableMapper = databaseTableMapper;
    }

    @Override
    public void addOrUpdateTable(Table table) throws DatabaseServerException {

        int result;
        DatabaseTable databaseTable = new LambdaQueryChainWrapper<>(databaseTableMapper).eq(DatabaseTable::getDbUid,
            table.getDbUid()).eq(DatabaseTable::getCode, table.getName()).one();

        if (databaseTable == null) {
            databaseTable = new DatabaseTable();
            BeanUtils.copyProperties(table, databaseTable);
            databaseTable.setCnUid(table.getCnUid());
            databaseTable.setDbUid(table.getDbUid());
            databaseTable.setCode(table.getName());
            result = databaseTableMapper.insert(databaseTable);
        } else {
            BeanUtils.copyProperties(table, databaseTable);
            result = databaseTableMapper.updateById(databaseTable);
        }

        if (result == 0) {
            throw new DatabaseServerException(ServerDatabaseModule.SAVE_TABLE_ERROR);
        }

        table.setUid(databaseTable.getUid());
    }
}
