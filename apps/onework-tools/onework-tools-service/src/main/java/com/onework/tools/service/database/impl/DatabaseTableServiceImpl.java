package com.onework.tools.service.database.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.service.database.IDatabaseTableService;
import com.onework.tools.service.database.entity.DatabaseTable;
import com.onework.tools.service.database.mapper.DatabaseTableMapper;
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
public class DatabaseTableServiceImpl extends ServiceImpl<DatabaseTableMapper, DatabaseTable>
    implements IDatabaseTableService {

}
