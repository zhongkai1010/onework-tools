package com.onework.tools.database;

import com.onework.tools.generator.entity.DatabaseColumn;
import org.apache.ibatis.annotations.Param;
import org.springframework.stereotype.Component;

import java.util.ArrayList;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: DatabaseManager
 * @author: 钟凯
 * @description: 数据库管理器，包括数据库所有功能实现
 * @date: 2021/12/8 0:00
 * @version: 1.0
 */
@Component
public interface DatabaseManager {

    /**
    * 判断连接是否存在
    * @param connection
    * @return boolean
    */
   boolean connectionExist(@Param("connection") Connection connection);

    /**
     * 添加数据库连接
     * 
     * @param connection
     *
     */
    void addConnection(@Param("connection") Connection connection);

    /**
     * 修改数据库连接
     * 
     * @param connection
     *
     */
    void updateConnection(@Param("connection") Connection connection);

    /**
     * 删除数据库连接
     * 
     * @param connection
     *
     */
    void deleteConnection(@Param("connection") Connection connection);

    /**
     * 获取所有数据库连接
     * 
     * @return ArrayList<DataBaseConnection>
     */
    ArrayList<Connection> getAllConnections();

    /**
     * 检查数据库连接是否正常
     * 
     * @param connection
     *
     * @return boolean true：正常，false：无法连接
     */
    boolean authenticateConnection(@Param("connection") Connection connection);

    /**
     * 获取离线和在线数据库
     * 
     * @param connection
     *
     * @return ArrayList<Database> 数据库表
     */
    ArrayList<Database> getAllDatabase(Connection connection);

    /**
     * 获取在线数据库
     *
     * @param connection
     *
     * @return ArrayList<Database> 数据库表
     */
    ArrayList<Database> getOnlineDatabase(Connection connection);

    /**
     * 获取离线数据库
     *
     * @param connection
     *
     * @return ArrayList<Database> 数据库表
     */
    ArrayList<Database> getOfflineDatabase(Connection connection);

    /**
     * 获取在线数据库表字段
     * 
     * @param database
     *
     * @return ArrayList<DataBaseTable> 表
     */
    ArrayList<Table> getOnlineTables(Database database);

    /**
     * 获取离线表表字段
     * 
     * @param database
     *
     * @return ArrayList<DataBaseTable> 表
     */
    ArrayList<Table> getOfflineTables(Database database);

    /**
     * 获取在线表字段
     * 
     * @param table
     *
     * @return ArrayList<DatabaseColumn> 字段
     */
    ArrayList<DatabaseColumn> getOnlineColumns(Table table);

    /**
     * 获取离线表字段
     * 
     * @param table
     *
     * @return ArrayList<DatabaseColumn> 字段
     */
    ArrayList<DatabaseColumn> getOfflineColumns(Table table);

    /**
     * 获取所有字段
     * 
     * @return ArrayList<DatabaseColumn>
     */
    ArrayList<DatabaseColumn> getAllColumns();
}
