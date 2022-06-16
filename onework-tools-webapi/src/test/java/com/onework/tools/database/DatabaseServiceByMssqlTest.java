package com.onework.tools.database;

import com.onework.tools.ExecuteResult;
import com.onework.tools.database.domain.DatabaseDomainService;
import com.onework.tools.database.domain.vo.ConnectionVo;
import com.onework.tools.webapi.OneworkToolsWebapiApplication;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest(classes = {OneworkToolsWebapiApplication.class})
class DatabaseServiceByMssqlTest {

    @Autowired
    private DatabaseDomainService databaseService;

    private static ConnectionVo getConnection() {
        ConnectionVo connection = new ConnectionVo();
        connection.setName("添加mssql测试连接");
        connection.setDbType("mssql");
        connection.setHost("192.168.111.109");
        connection.setPort(1433);
        connection.setDatabase("CTS");
        connection.setUsername("sa");
        connection.setPassword("Abcd1234");
        return connection;
    }

    @Test
    void saveConnection() {

        ConnectionVo connection = getConnection();
        ExecuteResult executeResult = databaseService.saveConnection(connection, false);
        Assertions.assertTrue(executeResult.isResult());
    }

    @Test
    void testConnection() {

        ConnectionVo connection = getConnection();
        ExecuteResult executeResult = databaseService.testConnection(connection);
        Assertions.assertTrue(executeResult.isResult());
    }

    @Test
    void syscConnection() {

        ConnectionVo connection = getConnection();
        ExecuteResult executeResult = databaseService.syscConnection(connection.getName());
        Assertions.assertTrue(executeResult.isResult());
    }

    @Test
    void syscDatabase() {

        ConnectionVo connection = getConnection();
        ExecuteResult saveResult = databaseService.saveConnection(connection, true);
        ExecuteResult syscResult = databaseService.syscDatabase(connection.getName(), connection.getDatabase());
        Assertions.assertTrue(saveResult.isResult() && syscResult.isResult());
    }

    @Test
    void deleteConnection() {

        ConnectionVo connection = getConnection();
        ExecuteResult executeResult = databaseService.deleteConnection(connection.getName());
        Assertions.assertTrue(executeResult.isResult());
    }
}