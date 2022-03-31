package com.onework.tools.domain.database;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.database.dao.Connection;
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
     * 同步数据库
     *
     * @param connectionName:
     * @return ExecuteResult
     */
    ExecuteResult syscDatabase(@NotNull String connectionName);
}
