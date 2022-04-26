package com.onework.tools.core.module;

import com.onework.tools.core.ApplicationBoot;
import lombok.extern.slf4j.Slf4j;
import org.springframework.context.ApplicationContext;
import org.springframework.stereotype.Component;

import java.util.List;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.module
 * @Description: 描述
 * @date Date : 2022年04月06日 15:43
 */
@Slf4j
@Component
public class ModuleManager implements ApplicationBoot {

    private final ApplicationContext applicationContext;

    public static Map<String, BaseModule> Modules = null;

    public static Map<String, String> ErrorMessage = null;

    private final ModuleStore moduleStore;

    public ModuleManager(ApplicationContext applicationContext, ModuleStore moduleStore) {
        this.applicationContext = applicationContext;
        this.moduleStore = moduleStore;
    }

    @Override
    public void init() {
        initModule();
        initFeature();
        initErrorMessage();
    }

    private void initErrorMessage() {
        Map<String, BaseModule> moduleMap = applicationContext.getBeansOfType(BaseModule.class);
        moduleMap.values().forEach((module -> {
            ModuleInfo moduleInfo = module.getModuleInfo();
            Map<String, String> messages = module.getExceptionEnum();
            moduleStore.saveErrorMessage(moduleInfo, messages);
            ErrorMessage.putAll(moduleStore.getModuleErrorMessage(moduleInfo));
        }));
    }



    private void initFeature() {
        Map<String, FeatureProvider> featureProviderMap = applicationContext.getBeansOfType(FeatureProvider.class);
        featureProviderMap.values().forEach(featureProvider -> {
            ModuleInfo moduleInfo = featureProvider.getModuleInfo();
            Feature moduleFeature = featureProvider.getModuleFeature();
            loadFeatureLog(moduleFeature);
            moduleStore.saveModuleFeature(moduleInfo, moduleFeature);
        });
    }

    private void initModule() {
        Map<String, BaseModule> moduleMap = applicationContext.getBeansOfType(BaseModule.class);
        moduleMap.values().forEach(module -> {
            ModuleInfo moduleInfo = module.getModuleInfo();
            loadModuleLog(moduleInfo);
            moduleStore.registerModule(moduleInfo);

        });
        Modules = moduleMap;
    }

    private void loadModuleLog(ModuleInfo moduleInfo) {
        log.info("--------------load module {}:{}-----------------", moduleInfo.getName(), moduleInfo.getCode());
    }

    private void loadFeatureLog(Feature moduleFeature) {
        log.info("--------------load feature {}:{}-----------------", moduleFeature.getName(), moduleFeature.getCode());
        List<Feature> subFeatures = moduleFeature.getSubFeatures();
        subFeatures.forEach(this::loadFeatureLog);
    }
}
