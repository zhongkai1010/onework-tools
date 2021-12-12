package com.onework.tools.database;

import com.onework.tools.ToolsWebApiApplication;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest(classes = ToolsWebApiApplication.class)
class DatabaseManagerImplTest {

//    @Autowired
//    private DatabaseMetadataManager databaseManager;

    @Test void connectionExist() {
//        Connection connection =  Connection.builder().databaseHost("127.0.0.1").port(3306).dbType(DatabaseType.MsSql).build();
//        databaseManager.connectionExist(connection);
    }

    @Test void addConnection() {
//        Connection connection =  Connection.builder()
//            .databaseHost("127.0.0.1")
//            .port(3306)
//            .dbType(DatabaseType.MsSql)
//            .dataBaseUserName("sa")
//            .databasePassword("123456")
//            .build();
//        databaseManager.addConnection(connection);
    }

    @Test void updateConnection() {

    }

    @Test void deleteConnection() {
    }

    @Test void getAllConnections() {
    }

    @Test void authenticateConnection() {
    }

    @Test void getAllDatabase() {
    }

    @Test void getOnlineDatabase() {
    }

    @Test void getOfflineDatabase() {
    }

    @Test void getOnlineTables() {
    }

    @Test void getOfflineTables() {
    }

    @Test void getOnlineColumns() {
    }

    @Test void getOfflineColumns() {
    }

    @Test void getAllColumns() {
    }
}