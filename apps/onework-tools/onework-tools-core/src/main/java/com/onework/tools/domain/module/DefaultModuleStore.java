package com.onework.tools.domain.module;

import com.onework.tools.ErrorMessage;
import lombok.Getter;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.module
 * @Description: 描述
 * @date Date : 2022年05月24日 17:40
 */
public class DefaultModuleStore implements ModuleStore {

    @Getter
    private List<AppModule> modules;

    @Getter
    private Map<String, List<ErrorMessage>> errorMessageMap;

    @Getter
    private Map<String, List<AppFeature>> featureMap;

    public DefaultModuleStore() {
        modules = new ArrayList<>();
        errorMessageMap = new HashMap<>(0);
        featureMap = new HashMap<>(0);
    }

    @Override
    public void addModule(AppModule module) {
        modules.add(module);
    }

    @Override
    public List<AppModule> getAllModules() {
        return modules;
    }

    @Override
    public List<ErrorMessage> getModuleErrorMessages(String moduleCode) {
        if (errorMessageMap.containsKey(moduleCode)) {
            return errorMessageMap.get(moduleCode);
        }
        return new ArrayList<>();
    }

    @Override
    public void addModuleErrorMessage(AppModule module, List<ErrorMessage> errorMessages) {
        String code = module.getCode();
        errorMessageMap.put(code, errorMessages);
    }

    @Override
    public void deleteModuleFeatures(AppModule module) {
        String code = module.getCode();
        if (featureMap.containsKey(code)) {
            featureMap.remove(code);
        }
    }

    @Override
    public void addModuleFeatures(AppModule module, List<AppFeature> features) {
        String code = module.getCode();
        featureMap.put(code, features);
    }
}
