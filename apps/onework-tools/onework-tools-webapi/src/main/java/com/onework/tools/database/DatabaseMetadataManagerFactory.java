package com.onework.tools.database;

import org.springframework.stereotype.Component;

/**
 * @ClassName: MetadataManagerAbstractFactory
 * @Description: 工厂
 * @Author: 钟凯
 * @Date: 2021/12/14 21:27
 **/
@Component
public class DatabaseMetadataManagerFactory {

    /**
     * 描述
     * 
     * @return DatabaseMetadataManager
     */
    public static DatabaseMetadataManager createDatabaseMetadataManager(DatabaseConnection databaseConnection) {
        switch (databaseConnection.getDbType()) {
            case MSSQL:
                return new MssqlDatabaseMetadataManager(databaseConnection);
            case MYSQL:
                return new MysqlDatabaseMetadataManager(databaseConnection);
            case ORACLE:

            case DB2:

            case INFORMIX:

            case SYBASE:

            case POSTGRESQL:

            case TERADATA:

            case NETEZZA:

            default:
                return null;
        }
    }
}
