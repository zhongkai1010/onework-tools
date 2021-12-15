package com.onework.tools.database;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class MysqlDatabaseMetadataManagerTest {

    @Test
    void getDatabase() {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        databaseConnection.setDbType(DatabaseType.MYSQL);
        databaseConnection.setHost("127.0.0.1");
        databaseConnection.setPort(3306);
        databaseConnection.setUser("root");
        databaseConnection.setPassword("123456");
        databaseConnection.setDatabase("onework");
        DatabaseMetadataManager databaseMetadataManager =
            DatabaseMetadataManagerFactory.createDatabaseMetadataManager(databaseConnection);
        databaseMetadataManager.getDatabase().forEach((v) -> System.out.println(v));
    }

    @Test
    void getTables() {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        databaseConnection.setDbType(DatabaseType.MYSQL);
        databaseConnection.setHost("127.0.0.1");
        databaseConnection.setPort(3306);
        databaseConnection.setUser("root");
        databaseConnection.setPassword("123456");
        databaseConnection.setDatabase("onework");
        DatabaseMetadataManager databaseMetadataManager =
            DatabaseMetadataManagerFactory.createDatabaseMetadataManager(databaseConnection);
        databaseMetadataManager.getTables("onework").forEach((v) -> System.out.println(v));
    }

    @Test
    void getColumns() {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        databaseConnection.setDbType(DatabaseType.MYSQL);
        databaseConnection.setHost("127.0.0.1");
        databaseConnection.setPort(3306);
        databaseConnection.setUser("root");
        databaseConnection.setPassword("123456");
        databaseConnection.setDatabase("onework");
        DatabaseMetadataManager databaseMetadataManager =
            DatabaseMetadataManagerFactory.createDatabaseMetadataManager(databaseConnection);
        databaseMetadataManager.getColumns("onework", "ow_database_columns").forEach((v) -> System.out.println(v));;
    }
}