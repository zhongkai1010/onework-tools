package com.onework.tools.model.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.model.dao.entity.ModelDataItem;
import com.onework.tools.model.dao.mapper.ModelDataItemMapper;
import com.onework.tools.model.service.IModelDataItemService;
import org.springframework.stereotype.Service;

/**
 * <p>
 * 服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-04-21
 */
@Service
public class ModelDataItemServiceImpl extends ServiceImpl<ModelDataItemMapper, ModelDataItem>
    implements IModelDataItemService {

}
