package com.onework.tools.core.module;

import lombok.NonNull;
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
public class ModuleManager {

    private final ApplicationContext applicationContext;

    public static Map<String, Module> Modules;

    public static Map<String, String> ErrorMessages;

    public ModuleManager(final ApplicationContext applicationContext) {

        this.applicationContext = applicationContext;
        Modules = getInternalModules();
        ErrorMessages = getInternalErrorMessages();
    }

    private static @NonNull Map<String, String> getInternalErrorMessages() {

        final Map<String, String> errorMessages = new HashMap<>(16);

        if (Modules != null) {
            Modules.values().forEach((module -> {
                final String moduleCode = module.getModuleCode();
                final Map<String, String> moduleErrorMessages = module.getErrorMessageMaps();

                moduleErrorMessages.forEach((k, v) -> {
                    final String code = String.format("%s.%s", moduleCode, k);
                    errorMessages.put(code, v);
                });
            }));
        }
        return errorMessages;
    }

    private Map<String, Module> getInternalModules() {

        final Map<String, Module> modules = new HashMap<>(16);
        final Map<String, Module> beans = applicationContext.getBeansOfType(Module.class);
        for (final Map.Entry<String, Module> entry : beans.entrySet()) {
            final String key = entry.getKey();
            final Module module = entry.getValue();
            final String moduleCode = module.getModuleCode();
            modules.put(moduleCode, module);
        }

        return modules;
    }
}
