package com.onework.tools.model.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.model.entity.ModelItem;
import com.onework.tools.model.mapper.ModelItemMapper;
import com.onework.tools.model.service.IModelItemService;
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
public class ModelItemServiceImpl extends ServiceImpl<ModelItemMapper, ModelItem> implements IModelItemService {

}
