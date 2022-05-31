package com.onework.tools.domain.module;

import cn.hutool.core.collection.ListUtil;
import com.onework.tools.error.ErrorMessage;
import org.springframework.context.ApplicationContext;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain
 * @Description: 描述
 * @date Date : 2022年05月23日 15:26
 */
@Component
public class ModuleLoader {

    private final ApplicationContext applicationContext;

    public ModuleLoader(ApplicationContext applicationContext) {
        this.applicationContext = applicationContext;
    }

    public ArrayList<ModuleRegister> getModuleRegisters() {
        Map<String, ModuleRegister> moduleMap = applicationContext.getBeansOfType(ModuleRegister.class);
        return ListUtil.toList(moduleMap.values());
    }

    public ArrayList<ModuleDescriptor> getModuleDescriptors() {

        List<ModuleRegister> moduleRegisters = getModuleRegisters();
        ArrayList<ModuleDescriptor> moduleDescriptors = new ArrayList<>(moduleRegisters.size());

        moduleRegisters.forEach(moduleRegister -> {
            AppModule module = moduleRegister.getModule();

            ModuleDescriptor moduleDescriptor = new ModuleDescriptor(module);
            moduleDescriptors.add(moduleDescriptor);
        });
        return moduleDescriptors;
    }

    public ArrayList<ErrorMessage> getAllModuleErrorMessages() {

        Collection<ModuleDescriptor> moduleRegisters = getModuleDescriptors();
        ArrayList<ErrorMessage> errorMessages = new ArrayList<>();

        moduleRegisters.forEach(moduleDescriptor -> {
            List<ErrorMessage> moduleErrorMessage = moduleDescriptor.getModuleErrorMessages();
            errorMessages.addAll(moduleErrorMessage);
        });
        return errorMessages;
    }
}
