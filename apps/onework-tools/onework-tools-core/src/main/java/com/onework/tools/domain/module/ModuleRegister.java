package com.onework.tools.domain.module;

import com.onework.tools.ErrorMessage;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain
 * @Description: 模块登记
 * @date Date : 2022年05月23日 15:13
 */
@Component
public abstract class ModuleRegister {

    /**
     * 获取模块编码
     *
     * @return
     */
    protected abstract String getModuleCode();

    /**
     * 获取模块名称
     *
     * @return
     */
    protected abstract String getModuleName();

    /**
     * @return
     */
    protected List<AppFeature> getFeatures() {
        return new ArrayList<>();
    }

    /**
     * @return
     */
    protected List<ErrorMessage> getErrorMessages() {
        return new ArrayList<>();
    }

    /**
     * 获取模块信息
     *
     * @return
     */
    public AppModule getModule() {

        String code = getModuleCode();
        String name = getModuleName();
        List<AppFeature> features = getFeatures();
        List<ErrorMessage> errorMessages = getErrorMessages();

        AppModule module = new AppModule(code, name);
        module.setFeatures(features);
        module.setErrorMessages(errorMessages);

        return module;
    }
}
