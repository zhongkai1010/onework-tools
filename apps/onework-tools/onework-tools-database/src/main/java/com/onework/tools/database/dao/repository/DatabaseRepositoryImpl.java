package com.onework.tools.database.dao.repository;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.database.DatabaseException;
import com.onework.tools.database.DatabaseModule;
import com.onework.tools.database.dao.entity.DatabaseDb;
import com.onework.tools.database.dao.mapper.DatabaseDbMapper;
import com.onework.tools.database.domain.entity.Database;
import com.onework.tools.database.domain.repository.DatabaseRepository;
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
    public void saveDatabase(Database database) {

        int result;

        DatabaseDb databaseDb =
            new LambdaQueryChainWrapper<>(databaseDbMapper).eq(DatabaseDb::getCnUid, database.getCnUid())
                .eq(DatabaseDb::getName, database.getName()).one();

        if (databaseDb == null) {
            insertDatabase(database);

        } else {
            updateDatabase(database);
        }
    }

    @Override
    public void insertDatabase(Database database) {

        int result;
        DatabaseDb databaseDb = new DatabaseDb();
        BeanUtil.copyProperties(database, databaseDb);
        databaseDb.setCode(database.getName());
        databaseDb.setCnUid(database.getCnUid());

        result = databaseDbMapper.insert(databaseDb);
        if (result == 0) {
            throw new DatabaseException(DatabaseModule.SAVE_DATABASE_ERROR);
        }
        database.setUid(databaseDb.getUid());
    }

    @Override
    public void updateDatabase(Database database) {

        int result;

        DatabaseDb databaseDb =
            new LambdaQueryChainWrapper<>(databaseDbMapper).eq(DatabaseDb::getCnUid, database.getCnUid())
                .eq(DatabaseDb::getName, database.getName()).one();

        BeanUtil.copyProperties(database, databaseDb, new CopyOptions().ignoreNullValue());
        result = databaseDbMapper.updateById(databaseDb);

        if (result == 0) {
            throw new DatabaseException(DatabaseModule.SAVE_DATABASE_ERROR);
        }
        database.setUid(databaseDb.getUid());
    }

    @Override
    public Database getDatabaseByName(String connId, String dbName) {

        DatabaseDb databaseDb = new LambdaQueryChainWrapper<>(databaseDbMapper).eq(DatabaseDb::getCnUid, connId)
            .eq(DatabaseDb::getName, dbName).one();
        return BeanUtil.copyProperties(databaseDb, Database.class);
    }
}
