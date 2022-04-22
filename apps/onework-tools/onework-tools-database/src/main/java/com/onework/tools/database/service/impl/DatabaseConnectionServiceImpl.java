package com.onework.tools.database.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.database.dao.entity.DatabaseConnection;
import com.onework.tools.database.dao.mapper.DatabaseConnectionMapper;
import com.onework.tools.database.service.IDatabaseConnectionService;
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
