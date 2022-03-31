package com.onework.tools.server.database.repository;

import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.domain.database.dao.Database;
import com.onework.tools.domain.database.repository.DatabaseRepository;
import com.onework.tools.server.database.DatabaseServerException;
import com.onework.tools.server.database.ServerDatabaseModule;
import com.onework.tools.server.database.entity.DatabaseDb;
import com.onework.tools.server.database.mapper.DatabaseDbMapper;
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
public class DatabaseRepositoryImpl implements DatabaseRepository {

    private final DatabaseDbMapper databaseDbMapper;

    public DatabaseRepositoryImpl(DatabaseDbMapper databaseDbMapper) {
        this.databaseDbMapper = databaseDbMapper;
    }

    @Override
    public void addOrUpdateDatabase(Database database) throws DatabaseServerException {

        int result;

        DatabaseDb databaseDb = new LambdaQueryChainWrapper<>(databaseDbMapper).eq(DatabaseDb::getUid,
            database.getCnUid()).eq(DatabaseDb::getName, database.getName()).one();

        if (databaseDb == null) {
            databaseDb = new DatabaseDb();
            BeanUtils.copyProperties(database, databaseDb);
            databaseDb.setCode(database.getName());
            databaseDb.setCnUid(database.getCnUid());
            result = databaseDbMapper.insert(databaseDb);

        } else {
            BeanUtils.copyProperties(database, databaseDb);
            result = databaseDbMapper.updateById(databaseDb);
        }

        if (result == 0) {
            throw new DatabaseServerException(ServerDatabaseModule.SAVE_DATABASE_ERROR);
        }
        database.setUid(databaseDb.getUid());
    }
}
