package com.onework.sample.mybaits.mapper;

import com.onework.sample.mybaits.entity.DatabaseConnection;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-mybatis-sample
 * @Package com.onework.sample.mybaits.mapper
 * @Description: 描述
 * @date Date : 2021年12月22日 9:31
 */
public interface DatabaseConnectionMapper {

    /**
     * 根据uid获取数据库连接
     *
     * @param uid 数据库连接Id
     * @return DatabaseConnection 数据库连接
     */
    DatabaseConnection getDatabaseConnection(String uid);
}
