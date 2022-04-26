package com.onework.tools.domain.database;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.database.entity.Connection;
import org.springframework.stereotype.Component;

import javax.validation.constraints.NotNull;

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
    ExecuteResult<Boolean> saveConnection(@NotNull Connection connection, Boolean sync);

    /**
     * 测试数据库连接
     *
     * @param connection
     * @return
     */
    ExecuteResult<Boolean> testConnection(@NotNull Connection connection);

    /**
     * 删除连接
     *
     * @param connection:
     * @return ExecuteResult
     */
    ExecuteResult<Boolean> deleteConnection(@NotNull Connection connection);

    /**
     * 同步数据库连接下所有数据库和表
     *
     * @param connection
     * @return
     */
    ExecuteResult<Boolean> syscConnection(@NotNull Connection connection);

    /**
     * 同步数据库
     *
     * @param connName
     * @param dbName
     * @return
     */
    ExecuteResult<Boolean> syscDatabase(@NotNull String connName, @NotNull String dbName);
}