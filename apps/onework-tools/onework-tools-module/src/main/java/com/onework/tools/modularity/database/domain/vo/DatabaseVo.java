package com.onework.tools.modularity.database.domain.vo;

import com.onework.tools.modularity.database.domain.schema.entity.DataDatabase;
import lombok.Data;

import java.time.LocalDateTime;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database.dao
 * @Description: 描述
 * @date Date : 2022年03月29日 16:30
 */
@Data
public class DatabaseVo {

    private String uid;
    private String name;
    private String cnUid;
    private Boolean isSync;
    private LocalDateTime lastSyncDate;

    public static DatabaseVo getDatabase(ConnectionVo connection, DataDatabase dataDatabase) {
        DatabaseVo database = new DatabaseVo();
        database.setCnUid(connection.getUid());
        database.setName(dataDatabase.getDbName());
        return database;
    }
}
