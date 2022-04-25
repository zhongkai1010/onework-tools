package com.onework.tools.service.database.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.service.database.IDatabaseColumnService;
import com.onework.tools.service.database.entity.DatabaseColumn;
import com.onework.tools.service.database.mapper.DatabaseColumnMapper;
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
