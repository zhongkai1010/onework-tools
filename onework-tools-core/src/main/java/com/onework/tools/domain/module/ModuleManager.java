package com.onework.tools.domain.module;

import cn.hutool.core.collection.CollectionUtil;
import com.onework.tools.ApplicationBoot;
import com.onework.tools.error.ErrorMessage;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Component;

import java.util.*;
import java.util.stream.Collectors;

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

    private final ModuleLoader moduleLoader;

    public static Map<String, ModuleDescriptor> Modules = new HashMap<>();

    public static Map<String, String> ErrorMessageMap = new HashMap<>();

    private final ModuleStore moduleStore;

    public ModuleManager(ModuleLoader moduleLoader, ModuleStore moduleStore) {

        this.moduleLoader = moduleLoader;
        this.moduleStore = moduleStore;
    }

    @Override
    public void init() {
        initModule();
    }

    private void initModule() {

        ErrorMessageMap = new HashMap<>(16);
        Collection<ModuleDescriptor> moduleDescriptors = moduleLoader.getModuleDescriptors();
        List<AppModule> modules = moduleStore.getAllModules();

        moduleDescriptors.forEach(moduleDescriptor -> {

            AppModule module = moduleDescriptor.getModule();
            if (Modules.containsKey(module.getCode())) {
                throw new RuntimeException(String.format("load module %s is code repeat", module.getCode()));
            }

            List<ErrorMessage> initErrorMessages = moduleDescriptor.getModuleErrorMessages();

            // 同步模块
            boolean isExist =
                CollectionUtil.contains(modules, current -> Objects.equals(current.getCode(), module.getCode()));
            if (isExist) {
                log.info("--------------update module {}:{}-----------------", module.getName(), module.getCode());

                // 数据库中读取异常信息
                List<ErrorMessage> moduleErrorMessages = moduleStore.getModuleErrorMessages(module.getCode());
                Map<String, String> moduleErrorMessageMap = moduleErrorMessages.stream()
                    .collect(Collectors.toMap(ErrorMessage::getCode, ErrorMessage::getMessage));

                //判断是否多出配置异常信息，进行添加
                List<ErrorMessage> addErrorMessage = new ArrayList<>();
                initErrorMessages.forEach(errorMessage -> {
                    if (!moduleErrorMessageMap.containsKey(errorMessage.getCode())) {
                        addErrorMessage.add(errorMessage);
                        moduleErrorMessageMap.put(errorMessage.getCode(), errorMessage.getMessage());
                    } else {
                        log.info(
                            "--------------update module error message is repeat model code is {}，error message code is {}-----------------",
                            module.getCode(), errorMessage.getCode());
                    }
                });
                moduleStore.addModuleErrorMessage(module, addErrorMessage);

                //保存全局异常信息
                ErrorMessageMap.putAll(moduleErrorMessageMap);

            } else {
                log.info("--------------add module {}:{}-----------------", module.getName(), module.getCode());
                moduleStore.addModule(module);
                moduleStore.addModuleErrorMessage(module, initErrorMessages);
                // 异常信息全局
                Map<String, String> moduleErrorMessageMap = initErrorMessages.stream()
                    .collect(Collectors.toMap(ErrorMessage::getCode, ErrorMessage::getMessage));
                ErrorMessageMap.putAll(moduleErrorMessageMap);
            }

            // 模块功能,不需要外部进行维护，直接全量添加
            List<AppFeature> initModuleFeatures = moduleDescriptor.getModuleFeatures();
            moduleStore.deleteModuleFeatures(module);
            moduleStore.addModuleFeatures(module, initModuleFeatures);

            //加入全局模块
            Modules.put(module.getCode(), moduleDescriptor);
        });
    }
}
