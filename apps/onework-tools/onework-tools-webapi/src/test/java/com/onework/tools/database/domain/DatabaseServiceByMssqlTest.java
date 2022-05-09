package com.onework.tools.database.domain;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.database.domain.vo.Connection;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest()
class DatabaseServiceByMssqlTest {

    @Autowired
    private DatabaseDomainService databaseService;

    private static Connection getConnection() {
        Connection connection = new Connection();
        connection.setName("添加mssql测试连接");
        connection.setDbType("mssql");
        connection.setHost("172.16.19.32");
        connection.setPort(1433);
        connection.setDatabase("CTS");
        connection.setUsername("sa");
        connection.setPassword("Abcd1234");
        return connection;
    }

    @Test
    void saveConnection() {

        Connection connection = getConnection();
        ExecuteResult executeResult = databaseService.saveConnection(connection, false);
        Assertions.assertEquals(ExecuteResult.SUCCESS, executeResult);
    }

    @Test
    void testConnection() {

        Connection connection = getConnection();
        ExecuteResult executeResult = databaseService.testConnection(connection);
        Assertions.assertEquals(ExecuteResult.SUCCESS, executeResult);
    }

    @Test
    void syscConnection() {

        Connection connection = getConnection();
        ExecuteResult executeResult = databaseService.syscConnection(connection.getName());
        Assertions.assertEquals(ExecuteResult.SUCCESS, executeResult);
    }

    @Test
    void syscDatabase() {

        Connection connection = getConnection();
        ExecuteResult saveResult = databaseService.saveConnection(connection, true);
        ExecuteResult syscResult = databaseService.syscDatabase(connection.getName(), connection.getDatabase());
        Assertions.assertTrue(saveResult.equals(ExecuteResult.SUCCESS) && syscResult.equals(ExecuteResult.SUCCESS));
    }

    @Test
    void deleteConnection() {

        Connection connection = getConnection();
        ExecuteResult executeResult = databaseService.deleteConnection(connection.getName());
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }
}