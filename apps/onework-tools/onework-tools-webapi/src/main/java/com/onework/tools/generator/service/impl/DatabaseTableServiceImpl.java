package com.onework.tools.generator.service.impl;

import com.onework.tools.generator.entity.DatabaseTable;
import com.onework.tools.generator.mapper.DatabaseTableMapper;
import com.onework.tools.generator.service.IDatabaseTableService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author 钟凯
 * @since 2021-12-16
 */
@Service
public class DatabaseTableServiceImpl extends ServiceImpl<DatabaseTableMapper, DatabaseTable> implements IDatabaseTableService {

}
