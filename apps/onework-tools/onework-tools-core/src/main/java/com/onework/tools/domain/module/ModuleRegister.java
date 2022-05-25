package com.onework.tools.domain.module;

import com.onework.tools.ApplicationBoot;
import com.onework.tools.domain.entity.NameCodeValue;
import com.onework.tools.error.ErrorMessage;
import lombok.extern.slf4j.Slf4j;
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
@Slf4j
@Component
public abstract class ModuleRegister implements ApplicationBoot {

    /**
     * 获取模块名称和编码
     *
     * @return
     */
    protected abstract NameCodeValue getModuleNameCode();

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

    @Override
    public void init() {
        NameCodeValue value = getModuleNameCode();
        log.info("------------------init module {}-----------------------", value.getName());
    }

    /**
     * 获取模块信息
     *
     * @return
     */
    public AppModule getModule() {

        NameCodeValue nameCodeValue = getModuleNameCode();
        List<AppFeature> features = getFeatures();
        List<ErrorMessage> errorMessages = getErrorMessages();

        AppModule module = new AppModule(nameCodeValue.getCode(), nameCodeValue.getName());
        module.setFeatures(features);
        module.setErrorMessages(errorMessages);

        return module;
    }
}
