package com.onework.tools.server.database.service.impl;

import com.onework.tools.server.database.entity.DatabaseTable;
import com.onework.tools.server.database.mapper.DatabaseTableMapper;
import com.onework.tools.server.database.service.IDatabaseTableService;
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
public class DatabaseTableServiceImpl extends ServiceImpl<DatabaseTableMapper, DatabaseTable> implements IDatabaseTableService {

}
