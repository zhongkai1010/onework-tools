package com.onework.tools.database;

import lombok.Builder;
import lombok.Data;
import lombok.NonNull;

import java.util.ArrayList;
import java.util.Date;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: Database
 * @author: 钟凯
 * @description: 数据库
 * @date: 2021/12/7 23:39
 * @version: 1.0
 */
@Data
public class Database {

    /**
     * 数据库名称
     */
    @NonNull
    private String databaseName;

    /**
     * 数据库连接
     */
    @NonNull
    private Connection connection;

    /**
     * 数据库表
     */
    private ArrayList<Table> tables = new ArrayList<>();

    /**
     * 数据库表
     */
    private boolean syncStatus = false;

    /**
    * 最后同步时间
    */
    private Date lastSyncDate = null;
}
