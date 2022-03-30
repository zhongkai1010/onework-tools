package com.onework.tools.server.model.service.impl;

import com.onework.tools.server.model.entity.ModelItem;
import com.onework.tools.server.model.mapper.ModelItemMapper;
import com.onework.tools.server.model.service.IModelItemService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-03-30
 */
@Service
public class ModelItemServiceImpl extends ServiceImpl<ModelItemMapper, ModelItem> implements IModelItemService {

}
