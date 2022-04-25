package com.onework.tools.domain.module.service;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.module.entity.Module;
import org.springframework.stereotype.Service;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.module
 * @Description: 描述
 * @date Date : 2022年04月25日 14:16
 */
@Service
public interface ModuleService {

    /**
     * 注册模块
     *
     * @param module
     * @return
     */
    ExecuteResult<Boolean> registerModule(Module module);

    /**
     * 同步模块异常消息
     *
     * @param module
     * @param messages
     * @return
     */
    ExecuteResult<Boolean> syncModuleErrorMessage(Module module, Map<String, String> messages);
}
