package com.onework.tools.service.database.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.service.database.IDatabaseConnectionService;
import com.onework.tools.service.database.entity.DatabaseConnection;
import com.onework.tools.service.database.mapper.DatabaseConnectionMapper;
import org.springframework.stereotype.Service;

/**
 * <p>
 * 服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-03-31
 */
@Service
public class DatabaseConnectionServiceImpl extends ServiceImpl<DatabaseConnectionMapper, DatabaseConnection>
    implements IDatabaseConnectionService {

}
