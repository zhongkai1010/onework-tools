package com.onework.tools;

import com.onework.tools.domain.database.DatabaseDomainException;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest()
class OneworkToolsWebApiApplicationTests {

    @Test
    void contextLoads() throws DatabaseDomainException {

        int max = 200;
        int size = 201;
        int processCount = 1;
        if (size > max) {
            processCount = (size / max) + ((size % max == 0 ? 0 : 1));
        }
        System.out.println(processCount);
    }
}
