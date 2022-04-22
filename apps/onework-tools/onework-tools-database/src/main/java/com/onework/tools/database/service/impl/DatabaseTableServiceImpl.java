package com.onework.tools.database.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.database.dao.entity.DatabaseTable;
import com.onework.tools.database.dao.mapper.DatabaseTableMapper;
import com.onework.tools.database.service.IDatabaseTableService;
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
