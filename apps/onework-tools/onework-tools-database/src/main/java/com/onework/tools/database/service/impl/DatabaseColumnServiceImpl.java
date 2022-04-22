package com.onework.tools.database.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.database.dao.entity.DatabaseColumn;
import com.onework.tools.database.dao.mapper.DatabaseColumnMapper;
import com.onework.tools.database.service.IDatabaseColumnService;
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
public class DatabaseColumnServiceImpl extends ServiceImpl<DatabaseColumnMapper, DatabaseColumn>
    implements IDatabaseColumnService {

}
