package com.onework.tools.server.database;

import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.domain.database.DatabaseRepository;
import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.server.database.entity.DatabaseDb;
import com.onework.tools.server.database.service.IDatabaseDbService;
import org.springframework.beans.BeanUtils;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.database
 * @Description: 描述
 * @date Date : 2022年03月31日 9:09
 */
@Repository
public class DatabasRepositoryImpl implements DatabaseRepository {

    private final IDatabaseDbService databaseDbService;

    public DatabasRepositoryImpl(IDatabaseDbService databaseDbService) {
        this.databaseDbService = databaseDbService;
    }

    @Override
    public void addOrUpdateDatabase(Database database) {
        LambdaQueryChainWrapper<DatabaseDb> queryWrapper = databaseDbService.lambdaQuery();
        DatabaseDb databaseDb =
            queryWrapper.eq(DatabaseDb::getUid, database.getConnUid()).eq(DatabaseDb::getName, database.getName())
                .one();
        if (databaseDb == null) {
            databaseDb = new DatabaseDb();
            databaseDb.setCnUid(database.getConnUid());
        }
        BeanUtils.copyProperties(database, databaseDb);
        databaseDbService.save(databaseDb);
    }
}
