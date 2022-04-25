package com.onework.tools.service.database.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.service.database.IDatabaseDbService;
import com.onework.tools.service.database.entity.DatabaseDb;
import com.onework.tools.service.database.mapper.DatabaseDbMapper;
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
public class DatabaseDbServiceImpl extends ServiceImpl<DatabaseDbMapper, DatabaseDb> implements IDatabaseDbService {

}
