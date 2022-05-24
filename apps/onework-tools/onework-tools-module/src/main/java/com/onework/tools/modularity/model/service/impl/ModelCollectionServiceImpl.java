package com.onework.tools.modularity.model.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.modularity.model.entity.ModelCollection;
import com.onework.tools.modularity.model.mapper.ModelCollectionMapper;
import com.onework.tools.modularity.model.service.IModelCollectionService;
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
public class ModelCollectionServiceImpl extends ServiceImpl<ModelCollectionMapper, ModelCollection> implements
    IModelCollectionService {

}
