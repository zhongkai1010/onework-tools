package com.onework.tools.common.database;

import com.onework.tools.common.database.schema.MsSqlSchemaServer;
import com.onework.tools.common.database.schema.MySqlDbSchemaServer;
import lombok.extern.slf4j.Slf4j;

import java.sql.Connection;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.database
 * @Description: 描述
 * @date Date : 2022年03月23日 15:21
 */
@Slf4j
public class DbSchemaFactory {

    public static DbSchemaServer getMysqlSchemaServer(DbConnection dbConnection) {

        if (dbConnection == null) {
            log.error("DbSchemaFactory getMysqlSchemaServer connection is null");
            return null;
        }

        return new MySqlDbSchemaServer(dbConnection);
    }

    public static DbSchemaServer getMsSqlSchemaServer(DbConnection dbConnection) {

        if (dbConnection == null) {
            log.error("DbSchemaFactory getMsSqlSchemaServer connection is null");
            return null;
        }
        return new MsSqlSchemaServer(dbConnection);
    }
}


