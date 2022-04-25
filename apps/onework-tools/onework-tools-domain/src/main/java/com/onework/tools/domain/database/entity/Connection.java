package com.onework.tools.domain.database.entity;

import com.onework.tools.core.domain.Entity;
import com.onework.tools.domain.database.schema.DatabaseType;
import com.onework.tools.domain.database.schema.entity.DbConnection;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.dao
 * @Description: 描述
 * @date Date : 2022年03月29日 10:10
 */
@Data
public class Connection implements Entity {

    private static final long serialVersionUID = -6956882140336559657L;
    private String uid;
    private String name;
    private String dbType;
    private String host;
    private Integer port;
    private String database;
    private String username;
    private String password;

    public DbConnection getDbConnection() {
        DatabaseType databaseType = DatabaseType.Map.get(dbType);
        return DbConnection.create(databaseType).host(host).port(port).database(database).user(username)
            .password(password);
    }
}
