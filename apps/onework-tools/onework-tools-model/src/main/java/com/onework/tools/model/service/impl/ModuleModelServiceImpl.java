package com.onework.tools.model.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.onework.tools.model.dao.entity.ModuleModel;
import com.onework.tools.model.dao.mapper.ModuleModelMapper;
import com.onework.tools.model.service.IModuleModelService;
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
public class ModuleModelServiceImpl extends ServiceImpl<ModuleModelMapper, ModuleModel> implements IModuleModelService {

}
