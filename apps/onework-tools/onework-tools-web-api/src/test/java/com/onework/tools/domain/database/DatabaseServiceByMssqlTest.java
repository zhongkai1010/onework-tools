package com.onework.tools.domain.database;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.database.dao.Connection;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest()
class DatabaseServiceByMssqlTest {

    @Autowired
    private DatabaseService databaseService;

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
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }

    @Test
    void testConnection() {

        Connection connection = getConnection();
        ExecuteResult executeResult = databaseService.testConnection(connection);
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }

    @Test
    void syscConnection() {

        Connection connection = getConnection();
        ExecuteResult executeResult = databaseService.syscConnection(connection);
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }

    @Test
    void syscDatabase() {

        Connection connection = getConnection();
        ExecuteResult executeResult;
        executeResult = databaseService.syscDatabase(connection.getName(), "CTS");
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }

    @Test
    void deleteConnection() {

        Connection connection = getConnection();
        ExecuteResult executeResult = databaseService.deleteConnection(connection);
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }
}