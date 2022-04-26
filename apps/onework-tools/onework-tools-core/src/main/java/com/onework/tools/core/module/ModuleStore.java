package com.onework.tools.core.module;

import org.springframework.stereotype.Component;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.module
 * @Description: 描述
 * @date Date : 2022年04月26日 10:40
 */
@Component
public interface ModuleStore {

    /**
     * 注册模块
     *
     * @param moduleInfo
     */
    void registerModule(ModuleInfo moduleInfo);

    /**
     * 保存模块功能
     *
     * @param moduleInfo
     * @param feature
     */
    void saveModuleFeature(ModuleInfo moduleInfo, Feature feature);

    /**
     * 保存模块异常信息
     *
     * @param moduleInfo
     * @param errorMessage
     */
    void saveErrorMessage(ModuleInfo moduleInfo, Map<String, String> errorMessage);

    /**
     * 获取模块异常信息
     *
     * @param moduleInfo
     * @return
     */
    Map<String, String> getModuleErrorMessage(ModuleInfo moduleInfo);

}
