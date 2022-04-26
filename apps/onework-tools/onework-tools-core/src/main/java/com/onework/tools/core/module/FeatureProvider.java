package com.onework.tools.core.module;

import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.module
 * @Description: 描述
 * @date Date : 2022年04月26日 9:56
 */
@Component
public interface FeatureProvider {

    /**
     * 获取模块信息
     *
     * @return 模型信息
     */
    ModuleInfo getModuleInfo();

    /**
     * 获取模块功能
     *
     * @return
     */
    Feature getModuleFeature();
}
