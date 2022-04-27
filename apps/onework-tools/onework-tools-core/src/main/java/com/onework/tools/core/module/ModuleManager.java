package com.onework.tools.core.module;

import com.onework.tools.core.ApplicationBoot;
import com.onework.tools.core.Check;
import lombok.extern.slf4j.Slf4j;
import org.springframework.context.ApplicationContext;
import org.springframework.stereotype.Component;

import java.util.HashMap;
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

    public static Map<String, BaseModule> Modules = new HashMap<>();

    public static Map<String, String> ErrorMessage = new HashMap<>();

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

            messages.forEach((k, s) -> {
                Check.nullString(k, new RuntimeException(
                    String.format("load module %s init error message,message key is empty", moduleInfo.getCode())));

                Check.nullString(k, new RuntimeException(
                    String.format("load module %s init error message,message value is empty", moduleInfo.getCode())));
                Check.nullString(s, new RuntimeException());
            });

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

            String featureCode = moduleFeature.getCode();
            Check.nullString(featureCode, new RuntimeException("load module feature code is empty"));

            String featureName = moduleFeature.getName();
            Check.nullString(featureName, new RuntimeException("load module feature name is empty"));

            moduleStore.saveModuleFeature(moduleInfo, moduleFeature);
        });
    }

    private void initModule() {
        Map<String, BaseModule> moduleMap = applicationContext.getBeansOfType(BaseModule.class);
        Modules = new HashMap<>(moduleMap.size());
        moduleMap.values().forEach(module -> {

            ModuleInfo moduleInfo = module.getModuleInfo();
            String moduleCode = moduleInfo.getCode();
            String moduleName = moduleInfo.getName();

            loadModuleLog(moduleInfo);

            if (Modules.containsKey(moduleCode)) {
                throw new RuntimeException(String.format("load module %s is code repeat", moduleCode));
            } else {
                Check.nullString(moduleCode, new RuntimeException("load module code is empty"));
                Check.nullString(moduleName, new RuntimeException("load module name is empty"));

                moduleStore.registerModule(moduleInfo);
                Modules.put(moduleInfo.getCode(), module);
            }
        });
        Modules = moduleMap;
    }

    private static void loadModuleLog(ModuleInfo moduleInfo) {
        log.info("--------------load module {}:{}-----------------", moduleInfo.getName(), moduleInfo.getCode());
    }

    private void loadFeatureLog(Feature moduleFeature) {
        log.info("--------------load feature {}:{}-----------------", moduleFeature.getName(), moduleFeature.getCode());
        List<Feature> subFeatures = moduleFeature.getSubFeatures();
        subFeatures.forEach(this::loadFeatureLog);
    }
}
