package com.onework.tools.database.domain;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.database.domain.entity.Connection;
import com.sun.istack.internal.NotNull;
import lombok.NonNull;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 10:11
 */
@Component
public interface DatabaseService {

    /**
     * 新增或修改数据库连接
     *
     * @param connection
     * @param sync
     * @return
     */
    ExecuteResult saveConnection(@NotNull Connection connection, Boolean sync);

    /**
     * 测试数据库连接
     *
     * @param connection
     * @return
     */
    ExecuteResult testConnection(@NotNull Connection connection);

    /**
     * 删除连接
     *
     * @param connection:
     * @return ExecuteResult
     */
    ExecuteResult deleteConnection(@NotNull Connection connection);

    /**
     * 同步数据库连接下所有数据库和表
     *
     * @param connection
     * @return
     */
    ExecuteResult syscConnection(@NotNull Connection connection);

    /**
     * 同步数据库
     *
     * @param connName
     * @param dbName
     * @return
     */
    ExecuteResult syscDatabase(@NotNull String connName, @NonNull String dbName);
}
