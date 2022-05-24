package com.onework.tools.modularity.model.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.modularity.model.entity.ModelData;
import com.onework.tools.modularity.model.mapper.ModelDataMapper;
import com.onework.tools.modularity.model.service.IModelDataService;
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
public class ModelDataServiceImpl extends ServiceImpl<ModelDataMapper, ModelData> implements IModelDataService {

}
