package com.onework.tools.database;

import org.springframework.stereotype.Component;

import java.util.ArrayList;

/**
 * @ClassName: MysqlDataProvider
 * @Description: Mysql数据库提供者
 * @Author: 钟凯
 * @Date: 2021/12/8 22:02
 **/
@Component
public class MysqlDataProvider implements DataProvider {
    /**
     * 描述
     *
     * @param connection
     * @return boolean
     */
    @Override public boolean authenticateConnection(Connection connection) {
        return false;
    }

    /**
     * 描述
     *
     * @param connection
     * @return ArrayList<Database>
     */
    @Override public ArrayList<Database> getDatabase(Connection connection) {
        return null;
    }
}
