package com.onework.tools.server.database;

import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.domain.database.ColumnRepository;
import com.onework.tools.domain.database.dao.Column;
import com.onework.tools.server.database.entity.DatabaseColumn;
import com.onework.tools.server.database.service.IDatabaseColumnService;
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

    private final IDatabaseColumnService databaseColumnService;

    public ColumnRepositoryImpl(IDatabaseColumnService databaseColumnService) {
        this.databaseColumnService = databaseColumnService;
    }

    @Override
    public void addOrUpdateColumn(Column column) {
        LambdaQueryChainWrapper<DatabaseColumn> queryWrapper = databaseColumnService.lambdaQuery();
        DatabaseColumn databaseColumn =
            queryWrapper.eq(DatabaseColumn::getDbUid, column.getDbUid()).eq(DatabaseColumn::getName, column.getName())
                .one();
        if (databaseColumn == null) {
            databaseColumn = new DatabaseColumn();
            databaseColumn.setCnUid(column.getConnUid());
            databaseColumn.setDbUid(column.getDbUid());
            databaseColumn.setTbUid(column.getTbUid());
        }
        BeanUtils.copyProperties(column, databaseColumn);
        databaseColumnService.save(databaseColumn);
    }
}
