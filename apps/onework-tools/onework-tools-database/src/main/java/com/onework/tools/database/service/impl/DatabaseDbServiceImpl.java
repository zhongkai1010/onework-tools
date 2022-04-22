package com.onework.tools.database.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.database.dao.entity.DatabaseDb;
import com.onework.tools.database.dao.mapper.DatabaseDbMapper;
import com.onework.tools.database.service.IDatabaseDbService;
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
