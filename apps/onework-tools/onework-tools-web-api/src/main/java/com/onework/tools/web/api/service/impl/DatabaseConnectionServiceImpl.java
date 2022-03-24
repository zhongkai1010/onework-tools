package com.onework.tools.web.api.service.impl;

import com.onework.tools.web.api.entity.DatabaseConnection;
import com.onework.tools.web.api.mapper.DatabaseConnectionMapper;
import com.onework.tools.web.api.service.IDatabaseConnectionService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author 钟凯
 * @since 2022-03-24
 */
@Service
public class DatabaseConnectionServiceImpl extends ServiceImpl<DatabaseConnectionMapper, DatabaseConnection> implements IDatabaseConnectionService {

}
