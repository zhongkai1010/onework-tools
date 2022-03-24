//package com.onework.tools.common.database.schema;
//
//import com.onework.tools.database.DatabaseType;
//import com.onework.tools.database.DbConnection;
//import com.onework.tools.database.DbSchemaFactory;
//import com.onework.tools.database.DbSchemaServer;
//import org.junit.jupiter.api.Test;
//
///**
// * @author : zhongkai1010@163.com
// * @version V1.0
// * @Project: onework-tools
// * @Package com.onework.tools.common.database.schema
// * @Description: 描述
// * @date Date : 2022年03月23日 17:30
// */
//class MsSqlSchemaServerTest {
//
//    private DbSchemaServer dbSchemaServer;
//
//    public MsSqlSchemaServerTest() {
//        DbConnection dbConnection = DbConnection.create(DatabaseType.MSSQL);
//        dbConnection.host("172.16.19.32").port(1433).database("CTS").user("sa").password("Abcd1234")
//            .build();
//        this.dbSchemaServer = DbSchemaFactory.getMsSqlSchemaServer(dbConnection);
//    }
//
//    @Test
//    void getDatabase() {
//
//        this.dbSchemaServer.getDatabases().forEach(s -> System.out.println(s));
//    }
//
//    @Test
//    void getTables() {
//
//        String database = this.dbSchemaServer.getDatabases().get(0);
//        this.dbSchemaServer.getTables(database).forEach(s -> System.out.println(s));
//    }
//
//    @Test
//    void getColumns() {
//
//        String database = this.dbSchemaServer.getDatabases().get(0);
//        String table = this.dbSchemaServer.getTables(database).get(0);
//        this.dbSchemaServer.getColumns(database, table).forEach(s -> System.out.println(s.toString()));
//    }
//}