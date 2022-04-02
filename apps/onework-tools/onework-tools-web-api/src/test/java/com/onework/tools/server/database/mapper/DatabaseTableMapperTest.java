package com.onework.tools.server.database.mapper;

import com.baomidou.mybatisplus.core.toolkit.IdWorker;
import com.onework.tools.server.database.entity.DatabaseTable;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.time.LocalDateTime;
import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.database.mapper
 * @Description: 描述
 * @date Date : 2022年04月02日 16:14
 */
@SpringBootTest
class DatabaseTableMapperTest {

    @Autowired
    private DatabaseTableMapper databaseTableMapper;

    @Test
    void insertOrUpdateBatch() {

        ArrayList<DatabaseTable> tables = new ArrayList<>();

        DatabaseTable data1 = new DatabaseTable();
        data1.setUid("1510076321000181762");
        data1.setName("BE_ColdStorageProperty");
        data1.setCode("BE_ColdStorageProperty");
        data1.setCnUid("1510076152238174210");
        data1.setDbUid("1510076320333287426");
        data1.setDbName("CTS");
        data1.setCreatedAt(LocalDateTime.now());
        data1.setUpdatedAt(LocalDateTime.now());
        tables.add(data1);

        databaseTableMapper.insertBatch(tables);

    }
}