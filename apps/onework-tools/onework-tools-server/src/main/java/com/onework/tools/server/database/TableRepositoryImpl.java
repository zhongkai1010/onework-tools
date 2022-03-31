package com.onework.tools.server.database;

import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.domain.database.TableRepository;
import com.onework.tools.domain.database.dao.Table;
import com.onework.tools.server.database.entity.DatabaseTable;
import com.onework.tools.server.database.service.IDatabaseTableService;
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

    private final IDatabaseTableService databaseTableService;

    public TableRepositoryImpl(IDatabaseTableService databaseTableService) {
        this.databaseTableService = databaseTableService;
    }

    @Override
    public void addOrUpdateTable(Table table) {
        LambdaQueryChainWrapper<DatabaseTable> queryWrapper = databaseTableService.lambdaQuery();
        DatabaseTable databaseTable =
            queryWrapper.eq(DatabaseTable::getDbUid, table.getDbUid()).eq(DatabaseTable::getName, table.getName())
                .one();
        if (databaseTable == null) {
            databaseTable = new DatabaseTable();
            databaseTable.setCnUid(table.getConnUid());
            databaseTable.setDbUid(table.getDbUid());
        }
        BeanUtils.copyProperties(table, databaseTable);
        databaseTableService.save(databaseTable);
    }
}
