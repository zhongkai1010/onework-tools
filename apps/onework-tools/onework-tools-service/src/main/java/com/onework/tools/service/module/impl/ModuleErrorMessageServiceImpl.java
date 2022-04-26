package com.onework.tools.service.module.impl;

import com.onework.tools.service.module.entity.ModuleErrorMessage;
import com.onework.tools.service.module.mapper.ModuleErrorMessageMapper;
import com.onework.tools.service.module.service.IModuleErrorMessageService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-04-26
 */
@Service
public class ModuleErrorMessageServiceImpl extends ServiceImpl<ModuleErrorMessageMapper, ModuleErrorMessage> implements IModuleErrorMessageService {

}
