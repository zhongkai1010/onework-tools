package com.onework.tools.database.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.database.domain.vo.ConnectionVo;
import com.onework.tools.webapi.OneworkToolsWebapiApplication;
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

@SpringBootTest(classes = {OneworkToolsWebapiApplication.class})
class DatabaseServiceByMysqlTest {

    @Autowired
    private DatabaseDomainService databaseService;

    private static ConnectionVo getConnection() {
        ConnectionVo connection = new ConnectionVo();
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

        ConnectionVo connection = getConnection();
        ExecuteResult executeResult = databaseService.saveConnection(connection, false);
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }

    @Test
    void testConnection() {

        ConnectionVo connection = getConnection();
        ExecuteResult executeResult = databaseService.testConnection(connection);
        Assertions.assertTrue(executeResult.compare(ExecuteResult.SUCCESS));
    }

    @Test
    void syscConnection() {

        ConnectionVo connection = getConnection();
        ExecuteResult saveResult = databaseService.saveConnection(connection, false);
        ExecuteResult syscResult = databaseService.syscConnection(connection.getName());
        Assertions.assertTrue(saveResult.equals(ExecuteResult.SUCCESS) && syscResult.equals(ExecuteResult.SUCCESS));
    }

    @Test
    void syscDatabase() {

        ConnectionVo connection = getConnection();
        ExecuteResult saveResult = databaseService.saveConnection(connection, true);
        ExecuteResult syscResult = databaseService.syscDatabase(connection.getName(), connection.getDatabase());
        Assertions.assertTrue(saveResult.equals(ExecuteResult.SUCCESS) && syscResult.equals(ExecuteResult.SUCCESS));
    }

    @Test
    void deleteConnection() {

        ConnectionVo connection = getConnection();
        ExecuteResult executeResult = databaseService.deleteConnection(connection.getName());
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }
}