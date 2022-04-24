package com.onework.tools.core.module;

import com.onework.tools.core.error.ErrorMessage;
import org.springframework.stereotype.Component;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.module
 * @Description: 描述
 * @date Date : 2022年04月06日 15:24
 */
@Component
public interface BaseModule {

    /**
     * 获取模块基础信息
     *
     * @return
     */
    ModuleInfo getModuleInfo();

    /**
     * 获取模块异常枚举
     *
     * @return
     */
    Map<String, String> getExceptionEnum();


}
