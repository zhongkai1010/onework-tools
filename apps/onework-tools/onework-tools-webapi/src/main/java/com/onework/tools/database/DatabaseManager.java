package com.onework.tools.database;

import org.apache.ibatis.annotations.Param;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: DatabaseManager
 * @author: 钟凯
 * @description: 数据库管理器，包括数据库所有功能实现
 * @date: 2021/12/8 0:00
 * @version: 1.0
 */
public interface DatabaseManager {

    /**
    * 添加数据库连接
    * @param connection 数据库连接
    */
    void addDatabaseConnection(@Param("connection") DataBaseConnection connection);


}
