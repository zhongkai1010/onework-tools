package com.onework.tools.database.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.database.entity.DatabaseColumn;
import com.onework.tools.database.mapper.DatabaseColumnMapper;
import com.onework.tools.database.service.IDatabaseColumnService;
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
