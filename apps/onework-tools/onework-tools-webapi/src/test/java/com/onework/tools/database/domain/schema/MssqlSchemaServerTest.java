package com.onework.tools.database.domain.schema;

import com.onework.tools.modularity.database.domain.schema.DatabaseType;
import com.onework.tools.modularity.database.domain.schema.DbSchemaFactory;
import com.onework.tools.modularity.database.domain.schema.DbSchemaServer;
import com.onework.tools.modularity.database.domain.schema.entity.DataColumn;
import com.onework.tools.modularity.database.domain.schema.entity.DataDatabase;
import com.onework.tools.modularity.database.domain.schema.entity.DataTable;
import com.onework.tools.modularity.database.domain.schema.entity.DbConnection;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import javax.sql.DataSource;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.schema
 * @Description: 描述
 * @date Date : 2022年04月01日 14:01
 */
class MssqlSchemaServerTest {

    private static DbSchemaServer getDbSchemaServer() {
        // @formatter:off
        DataSource dataSource =
            DbConnection.create(DatabaseType.MSSQL).host("172.16.19.32")
                .port(1433)
                .database("CTS")
                .user("sa")
                .password("Abcd1234")
                .build();

        // @formatter:on
        DbSchemaServer dbSchemaServer = DbSchemaFactory.getMsSqlSchemaServer(dataSource);
        return dbSchemaServer;
    }

    @Test
    void testConnection() {
        DbSchemaServer dbSchemaServer = getDbSchemaServer();
        Assertions.assertTrue(dbSchemaServer.testConnection());
    }

    @Test
    void getDatabases() {
        DbSchemaServer dbSchemaServer = getDbSchemaServer();
        List<DataDatabase> dataDatabases = dbSchemaServer.getDatabases();
        dataDatabases.forEach(s -> System.out.println(s.getDbName()));
        Assertions.assertTrue(true);
    }

    @Test
    void getDataTables() {
        DbSchemaServer dbSchemaServer = getDbSchemaServer();
        List<DataTable> dataTables = dbSchemaServer.getDataTables("CTS");
        dataTables.forEach(s -> System.out.println(s.getTbName()));
        Assertions.assertTrue(true);
    }

    @Test
    void getDataColumns() {
        DbSchemaServer dbSchemaServer = getDbSchemaServer();
        List<DataColumn> dataColumns = dbSchemaServer.getDataColumns("CTS", "sms_Project");
        dataColumns.forEach(s -> System.out.println(s.getName()));
        Assertions.assertTrue(true);
    }

    @Test
    void getDatabaseAndTables() {
        DbSchemaServer dbSchemaServer = getDbSchemaServer();
        List<DataDatabase> dataDatabases = dbSchemaServer.getDatabaseAndTables();
        for (DataDatabase db : dataDatabases) {
            System.out.println(db.getDbName());
            List<DataTable> dataTables = db.getTables();
            for (DataTable tb : dataTables) {
                System.out.println(String.format("%s.%s", db.getDbName(), tb.getTbName()));
            }
        }
        Assertions.assertTrue(true);
    }
}