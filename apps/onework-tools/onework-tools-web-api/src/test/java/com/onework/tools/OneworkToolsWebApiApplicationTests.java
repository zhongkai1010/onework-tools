package com.onework.tools;

import com.onework.tools.domain.database.DatabaseDomainException;
import com.onework.tools.server.database.mapper.DatabaseTableMapper;
import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@Slf4j
@SpringBootTest
class OneworkToolsWebApiApplicationTests {

    @Autowired
    private DatabaseTableMapper databaseTableMapper;

    @Test
    void contextLoads() throws DatabaseDomainException {
        System.out.println(log.getClass());
    }
}
