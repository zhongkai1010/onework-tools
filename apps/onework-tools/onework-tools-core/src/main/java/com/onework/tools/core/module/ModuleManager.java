package com.onework.tools.core.module;

import lombok.NonNull;
import lombok.extern.slf4j.Slf4j;
import org.springframework.context.ApplicationContext;
import org.springframework.stereotype.Component;

import java.util.HashMap;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.module
 * @Description: 描述
 * @date Date : 2022年04月06日 15:43
 */
@Component
@Slf4j
public class ModuleManager {

    private ApplicationContext applicationContext;

    public static Map<String, BaseModule> Modules;

    public static Map<String, String> ErrorMessages;

    public ModuleManager(ApplicationContext applicationContext) {

        this.applicationContext = applicationContext;
        Modules = getInternalModules();
        ErrorMessages = getInternalErrorMessages();
    }

    private static @NonNull Map<String, String> getInternalErrorMessages() {

        Map<String, String> errorMessages = new HashMap<>(16);


        if (Modules != null) {
            Modules.values().forEach((module -> {
                String moduleCode = module.getModuleInfo().getCode();
                Map<String, String> moduleErrorMessages = module.getExceptionEnum();

                moduleErrorMessages.forEach((k, v) -> {
                    String code = String.format("%s.%s", moduleCode, k);
                    errorMessages.put(code, v);
                });
            }));
        }
        return errorMessages;
    }

    private Map<String, BaseModule> getInternalModules() {

        Map<String, BaseModule> modules = new HashMap<>(16);
        Map<String, BaseModule> beans = applicationContext.getBeansOfType(BaseModule.class);
        for (Map.Entry<String, BaseModule> entry : beans.entrySet()) {
            BaseModule module = entry.getValue();
            ModuleInfo moduleInfo = module.getModuleInfo();
            String moduleCode = moduleInfo.getCode();
            modules.put(moduleCode, module);
        }

        return modules;
    }

    private void logModule(BaseModule module) {
        log.info("--------------load {}-----------------", module.getModuleInfo().getName());
    }
}
