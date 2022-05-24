package com.onework.tools.domain.module;

import com.onework.tools.ErrorMessage;
import org.springframework.stereotype.Component;

import java.util.List;

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
     * 修改模块
     *
     * @param module
     */
    void addModule(AppModule module);

    /**
     * 获取已注册的模块
     *
     * @return
     */
    List<AppModule> getAllModules();

    /**
     * 获取模块异常信息
     *
     * @param moduleCode
     * @return
     */
    List<ErrorMessage> getModuleErrorMessages(String moduleCode);

    /**
     * 添加模块异常信息
     *
     * @param module
     * @param errorMessages
     */
    void addModuleErrorMessage(AppModule module, List<ErrorMessage> errorMessages);

    /**
     * 删除模块所有功能
     *
     * @param module
     */
    void deleteModuleFeatures(AppModule module);

    /**
     * 添加模块所有功能
     *
     * @param module
     * @param features
     */
    void addModuleFeatures(AppModule module, List<AppFeature> features);
}
