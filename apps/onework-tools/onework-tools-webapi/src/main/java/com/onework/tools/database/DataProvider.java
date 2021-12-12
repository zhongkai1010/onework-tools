package com.onework.tools.database;

import java.util.ArrayList;

/**
 * @ClassName: DataProvider
 * @Description: 数据提供者
 * @Author: 钟凯
 * @Date: 2021/12/8 21:51
 **/
public interface DataProvider {

    /**
    * 描述
    * @param connection
    * @return boolean
    */
    boolean authenticateConnection(Connection connection);

    /**
    * 描述
    * @param connection
    * @return ArrayList<Database>
    */
    ArrayList<Database> getDatabase(Connection connection);
}
