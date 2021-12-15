package com.onework.tools.database;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class MssqlDatabaseMetadataManagerTest {

    @Test
    void getDatabase() {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        databaseConnection.setDbType(DatabaseType.MSSQL);
        databaseConnection.setHost("127.0.0.1");
        databaseConnection.setPort(1433);
        databaseConnection.setUser("sa");
        databaseConnection.setPassword("123qwe!@#");
        databaseConnection.setDatabase("DlhDb");
        DatabaseMetadataManager databaseMetadataManager =
            DatabaseMetadataManagerFactory.createDatabaseMetadataManager(databaseConnection);
        databaseMetadataManager.getDatabase().forEach((v) -> System.out.println(v));
    }

    @Test
    void getTables() {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        databaseConnection.setDbType(DatabaseType.MSSQL);
        databaseConnection.setHost("127.0.0.1");
        databaseConnection.setPort(1433);
        databaseConnection.setUser("sa");
        databaseConnection.setPassword("123qwe!@#");
        databaseConnection.setDatabase("DlhDb");
        DatabaseMetadataManager databaseMetadataManager =
            DatabaseMetadataManagerFactory.createDatabaseMetadataManager(databaseConnection);
        databaseMetadataManager.getTables("DlhDb").forEach((v) -> System.out.println(v));
    }

    @Test
    void getColumns() {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        databaseConnection.setDbType(DatabaseType.MSSQL);
        databaseConnection.setHost("127.0.0.1");
        databaseConnection.setPort(1433);
        databaseConnection.setUser("sa");
        databaseConnection.setPassword("123qwe!@#");
        databaseConnection.setDatabase("ESMS002");
        DatabaseMetadataManager databaseMetadataManager =
            DatabaseMetadataManagerFactory.createDatabaseMetadataManager(databaseConnection);
        databaseMetadataManager.getColumns("ESMS002", "main_sensor").forEach((v) -> System.out.println(v));;
    }
}