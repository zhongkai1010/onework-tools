package com.onework.tools.domain.database;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.database.dao.Connection;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月31日 13:47
 */

@SpringBootTest()
class DatabaseServiceByMysqlTest {

    @Autowired
    private DatabaseService databaseService;

    private static Connection getConnection() {
        Connection connection = new Connection();
        connection.setName("添加mysql测试连接");
        connection.setDbType("mysql");
        connection.setHost("101.37.81.183");
        connection.setPort(8033);
        connection.setDatabase("onework");
        connection.setUsername("root");
        connection.setPassword("123qwe!@#mysql_root");
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
        ExecuteResult saveResult = databaseService.saveConnection(connection, false);
        ExecuteResult syscResult = databaseService.syscConnection(connection);
        Assertions.assertTrue(saveResult.equals(ExecuteResult.SUCCESS) && syscResult.equals(ExecuteResult.SUCCESS));
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