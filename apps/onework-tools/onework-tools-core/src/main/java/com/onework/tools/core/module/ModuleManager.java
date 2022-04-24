package com.onework.tools.core.module;

import com.onework.tools.core.ApplicationBoot;
import com.onework.tools.core.error.ErrorMessageStore;
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
@Slf4j
@Component
public class ModuleManager implements ApplicationBoot {

    private final ApplicationContext applicationContext;

    public static Map<String, BaseModule> Modules = null;

    public static Map<String, String> ErrorMessage = null;

    private final ErrorMessageStore errorMessageStore;

    public ModuleManager(ApplicationContext applicationContext, ErrorMessageStore errorMessageStore) {
        this.applicationContext = applicationContext;
        this.errorMessageStore = errorMessageStore;
    }

    @Override
    public void init() {
        initModule();
        initErrorMessage();
    }

    private void initErrorMessage() {
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
        ErrorMessage = errorMessageStore.getOrAddErrorMessage(errorMessages);
    }

    private void initModule() {

        Map<String, BaseModule> beans = applicationContext.getBeansOfType(BaseModule.class);
        if (Modules == null) {
            Modules = new HashMap<>(beans.size());
            for (Map.Entry<String, BaseModule> entry : beans.entrySet()) {

                BaseModule module = entry.getValue();
                ModuleInfo moduleInfo = module.getModuleInfo();
                log.info("--------------load Module {}:{}-----------------", moduleInfo.getName(),
                    moduleInfo.getCode());

                String moduleCode = moduleInfo.getCode();
                Modules.put(moduleCode, module);
            }
        }
    }
}
