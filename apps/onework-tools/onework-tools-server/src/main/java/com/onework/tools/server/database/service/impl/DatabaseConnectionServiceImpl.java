package com.onework.tools.server.database.service.impl;

import com.onework.tools.server.database.entity.DatabaseConnection;
import com.onework.tools.server.database.mapper.DatabaseConnectionMapper;
import com.onework.tools.server.database.service.IDatabaseConnectionService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-03-31
 */
@Service
public class DatabaseConnectionServiceImpl extends ServiceImpl<DatabaseConnectionMapper, DatabaseConnection> implements IDatabaseConnectionService {

}
