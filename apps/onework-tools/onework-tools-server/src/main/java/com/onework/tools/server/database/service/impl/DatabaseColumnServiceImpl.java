package com.onework.tools.server.database.service.impl;

import com.onework.tools.server.database.entity.DatabaseColumn;
import com.onework.tools.server.database.mapper.DatabaseColumnMapper;
import com.onework.tools.server.database.service.IDatabaseColumnService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-03-30
 */
@Service
public class DatabaseColumnServiceImpl extends ServiceImpl<DatabaseColumnMapper, DatabaseColumn> implements IDatabaseColumnService {

}
