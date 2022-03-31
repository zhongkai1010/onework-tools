package com.onework.tools.domain.database.dao;

import com.onework.tools.core.domain.Entity;
import com.onework.tools.domain.database.schema.DatabaseType;
import com.onework.tools.domain.database.schema.DbConnection;
import lombok.Data;

import javax.validation.constraints.NotNull;

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

    private static final long serialVersionUID = 1536253811858760370L;

    private String uid;

    @NotNull(message = "数据库连接名称不能为空")
    private String name;

    @NotNull
    private String dbType;

    @NotNull
    private String host;

    @NotNull
    private Integer port;

    @NotNull
    private String database;

    @NotNull
    private String user;

    @NotNull
    private String password;

    public DbConnection getDbConnection() {

        DatabaseType databaseType = DatabaseType.Map.get(dbType);
        return DbConnection.create(databaseType).host(host).port(port).database(database).user(user).password(password);
    }
}
