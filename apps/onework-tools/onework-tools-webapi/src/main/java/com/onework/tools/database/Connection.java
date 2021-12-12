package com.onework.tools.database;

import lombok.Builder;
import lombok.Data;
import lombok.NonNull;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.database
 * @className: DataBaseConnection
 * @author: 钟凯
 * @description: 数据库连接
 * @date: 2021/12/7 23:35
 * @version: 1.0
 */
@Data
@Builder
public class Connection {

    /**
     * 数据库连接字符串
     */
    @NonNull
    private String databaseHost;

    /**
     * 数据库类型
     */
    @NonNull
    private DatabaseType dbType;

    /**
     * 数据库用户名
     */
    private String dataBaseUserName;

    /**
     * 数据库密码
     */
    private String databasePassword;

    /**
     * 端口
     */
    @NonNull
    private Integer port;

    /**
     * 获取连接名称
     * 
     * @return String
     */
    public String getName() {
        return String.format("%s:%d:@%s", databaseHost, port, dataBaseUserName == null ? "" : dataBaseUserName);
    }

    /**
     * 描述
     *
     * @return boolean true 相同，false 不同
     */
    public boolean toCompare(Connection connection) {
        return connection.getDatabaseHost().equals(databaseHost) && connection.port.equals(connection.getPort());
    }
}
