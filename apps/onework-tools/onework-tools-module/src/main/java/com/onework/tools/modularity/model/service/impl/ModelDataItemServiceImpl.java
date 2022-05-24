package com.onework.tools.modularity.model.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.modularity.model.entity.ModelDataItem;
import com.onework.tools.modularity.model.mapper.ModelDataItemMapper;
import com.onework.tools.modularity.model.service.IModelDataItemService;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-04-27
 */
@Service
public class ModelDataItemServiceImpl extends ServiceImpl<ModelDataItemMapper, ModelDataItem> implements
    IModelDataItemService {

}
