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
        connection.setHost("127.0.0.1");
        connection.setPort(1433);
        connection.setDatabase("v3");
        connection.setUsername("sa");
        connection.setPassword("123qwe!@#");
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
        ExecuteResult saveResult = databaseService.saveConnection(connection, true);
        ExecuteResult syscResult = databaseService.syscDatabase(connection.getName(), connection.getDatabase());
        Assertions.assertTrue(saveResult.equals(ExecuteResult.SUCCESS) && syscResult.equals(ExecuteResult.SUCCESS));
    }

    @Test
    void deleteConnection() {

        Connection connection = getConnection();
        ExecuteResult executeResult = databaseService.deleteConnection(connection);
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }
}