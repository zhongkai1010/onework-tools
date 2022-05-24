package com.onework.tools.modularity.database.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.modularity.database.entity.DatabaseColumn;
import com.onework.tools.modularity.database.mapper.DatabaseColumnMapper;
import com.onework.tools.modularity.database.service.IDatabaseColumnService;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-05-09
 */
@Service
public class DatabaseColumnServiceImpl extends ServiceImpl<DatabaseColumnMapper, DatabaseColumn> implements
    IDatabaseColumnService {

}
