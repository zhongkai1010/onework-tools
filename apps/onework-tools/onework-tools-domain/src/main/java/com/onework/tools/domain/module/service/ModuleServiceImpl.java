package com.onework.tools.domain.module.service;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.module.entity.Module;
import org.springframework.stereotype.Service;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.module.service
 * @Description: 描述
 * @date Date : 2022年04月25日 15:31
 */
@Service
public class ModuleServiceImpl implements ModuleService {

    @Override
    public ExecuteResult<Boolean> registerModule(Module module) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> syncModuleErrorMessage(Module module, Map<String, String> messages) {
        return null;
    }
}
