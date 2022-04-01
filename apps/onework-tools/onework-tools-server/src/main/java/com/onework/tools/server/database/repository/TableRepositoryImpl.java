package com.onework.tools.server.database.repository;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.dao.Table;
import com.onework.tools.domain.database.repository.TableRepository;
import com.onework.tools.server.database.DatabaseServerException;
import com.onework.tools.server.database.ServerDatabaseModule;
import com.onework.tools.server.database.entity.DatabaseDb;
import com.onework.tools.server.database.entity.DatabaseTable;
import com.onework.tools.server.database.mapper.DatabaseDbMapper;
import com.onework.tools.server.database.mapper.DatabaseTableMapper;

import org.springframework.stereotype.Repository;

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
public class TableRepositoryImpl implements TableRepository {

    private final DatabaseTableMapper databaseTableMapper;

    private final DatabaseDbMapper databaseDbMapper;

    public TableRepositoryImpl(DatabaseTableMapper databaseTableMapper, DatabaseDbMapper databaseDbMapper) {
        this.databaseTableMapper = databaseTableMapper;
        this.databaseDbMapper = databaseDbMapper;
    }

    @Override
    public void addOrUpdateTable(Table table) throws DatabaseServerException {

        int result;
        DatabaseTable databaseTable =
            new LambdaQueryChainWrapper<>(databaseTableMapper).eq(DatabaseTable::getDbUid, table.getDbUid())
                .eq(DatabaseTable::getCode, table.getName()).one();

        if (databaseTable == null) {
            databaseTable = new DatabaseTable();
            BeanUtil.copyProperties(table, databaseTable);
            databaseTable.setCnUid(table.getCnUid());
            databaseTable.setDbUid(table.getDbUid());
            databaseTable.setCode(table.getName());
            result = databaseTableMapper.insert(databaseTable);
        } else {
            BeanUtil.copyProperties(table, databaseTable, new CopyOptions().ignoreNullValue());
            result = databaseTableMapper.updateById(databaseTable);
        }

        if (result == 0) {
            throw new DatabaseServerException(ServerDatabaseModule.SAVE_TABLE_ERROR);
        }

        table.setUid(databaseTable.getUid());
    }

    @Override
    public <T extends Throwable> void batchAddOrUpdateTable(Database database, List<Table> tables) throws T {

        //TODO 考虑批量插入数据库表

        DatabaseDb databaseDb =
            new LambdaQueryChainWrapper<>(databaseDbMapper).eq(DatabaseDb::getUid, database.getUid()).one();
        if (databaseDb == null) {
            throw new DatabaseServerException(ServerDatabaseModule.SAVE_TABLE_ERROR);
        }

        // 获取数据库中表
        List<DatabaseTable> oldTables =
            new LambdaQueryChainWrapper<>(databaseTableMapper).eq(DatabaseTable::getDbUid, databaseDb.getUid()).list();
        List<String> oldTableNames = new ArrayList<>();
        oldTables.forEach(s -> oldTableNames.add(s.getName()));

        // 区分新增与修改
        List<Table> newTbs = new ArrayList<>();
        List<Table> updateTbs = new ArrayList<>();
        tables.forEach((table) -> {
            if (oldTableNames.contains(table.getName())) {
                updateTbs.add(table);
            } else {
                newTbs.add(table);
            }
        });

       // databaseDbMapper.in

    }
}
