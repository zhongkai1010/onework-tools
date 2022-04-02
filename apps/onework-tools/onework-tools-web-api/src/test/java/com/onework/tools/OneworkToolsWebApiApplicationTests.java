package com.onework.tools;

import com.onework.tools.domain.database.DatabaseDomainException;
import com.onework.tools.server.database.entity.DatabaseTable;
import com.onework.tools.server.database.mapper.DatabaseTableMapper;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.ArrayList;

@SpringBootTest()
class OneworkToolsWebApiApplicationTests {

    @Autowired
    private DatabaseTableMapper databaseTableMapper;

    @Test
    void contextLoads() throws DatabaseDomainException {


    }
}
