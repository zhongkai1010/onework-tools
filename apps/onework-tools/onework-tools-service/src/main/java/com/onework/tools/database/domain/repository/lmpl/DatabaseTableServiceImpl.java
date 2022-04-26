package com.onework.tools.database.domain.repository.lmpl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.database.entity.DatabaseTable;
import com.onework.tools.database.mapper.DatabaseTableMapper;
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
