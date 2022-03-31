package com.onework.tools.domain.database.dao;

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
public class Database {

    private String uid;
    private String name;
    private String cnUid;
    private Boolean isSync;
    private LocalDateTime lastSyncDate;
}
