package com.onework.tools.domain;

import com.onework.tools.domain.database.DatabaseDomainException;
import com.onework.tools.domain.database.DatabaseService;
import com.onework.tools.domain.database.dao.Connection;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.context.ApplicationContext;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月31日 13:47
 */

@SpringBootTest()
class DatabaseServiceTest {

    @Autowired
    private DatabaseService databaseService;

    @Autowired
    private ApplicationContext applicationContext;

    private Connection connection;

    public DatabaseServiceTest() {
        this.connection = new Connection();
        connection.setName("测试添加连接");
        connection.setDbType("mysql");
        connection.setHost("101.37.81.183");
        connection.setPort(8033);
        connection.setDatabase("onework");
        connection.setUser("root");
        connection.setPassword("123qwe!@#mysql_root");
    }

    @Test
    void saveConnection() throws DatabaseDomainException {

        databaseService.saveConnection(connection, false);

        Assertions.assertTrue(true);
    }

    @Test
    void testConnection() throws DatabaseDomainException {

        Assertions.assertTrue(databaseService.testConnection(connection));

    }

    @Test
    void deleteConnection() {
    }

    @Test
    void syscDatabase() {
    }
}