package com.onework.tools.database;

import org.springframework.stereotype.Component;

import java.util.ArrayList;

/**
 * @ClassName: MssqlDataProvider
 * @Description: mssql数据提供者
 * @Author: 钟凯
 * @Date: 2021/12/8 22:03
 **/
@Component
public class MssqlDataProvider implements DataProvider {
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
