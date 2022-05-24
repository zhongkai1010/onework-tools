package com.onework.tools.modularity.database.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.modularity.database.entity.DatabaseTable;
import com.onework.tools.modularity.database.mapper.DatabaseTableMapper;
import com.onework.tools.modularity.database.service.IDatabaseTableService;
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
public class DatabaseTableServiceImpl extends ServiceImpl<DatabaseTableMapper, DatabaseTable> implements
    IDatabaseTableService {

}
