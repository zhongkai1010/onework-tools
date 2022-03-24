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
// * @date Date : 2022年03月23日 16:50
// */
//class MySqlDbSchemaServerTest {
//
//    private DbSchemaServer dbSchemaServer;
//
//    public MySqlDbSchemaServerTest() {
//        DbConnection dbConnection = DbConnection.create(DatabaseType.MYSQL);
//        dbConnection.host("101.37.81.183").port(8033).database("onework").user("root").password("123qwe!@#mysql_root")
//            .build();
//        this.dbSchemaServer = DbSchemaFactory.getMysqlSchemaServer(dbConnection);
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