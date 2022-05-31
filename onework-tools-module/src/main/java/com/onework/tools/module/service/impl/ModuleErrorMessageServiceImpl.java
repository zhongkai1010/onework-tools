package com.onework.tools.module.service.impl;

import com.onework.tools.module.entity.ModuleErrorMessage;
import com.onework.tools.module.mapper.ModuleErrorMessageMapper;
import com.onework.tools.module.service.IModuleErrorMessageService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-05-24
 */
@Service
public class ModuleErrorMessageServiceImpl extends ServiceImpl<ModuleErrorMessageMapper, ModuleErrorMessage> implements
    IModuleErrorMessageService {

}
