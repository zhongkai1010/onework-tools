package com.onework.tools.modularity.module;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.onework.tools.*;
import com.onework.tools.domain.module.AppFeature;
import com.onework.tools.domain.module.AppModule;
import com.onework.tools.domain.module.ModuleStore;
import com.onework.tools.modularity.module.domain.FeatureState;
import com.onework.tools.modularity.module.entity.ModuleErrorMessage;
import com.onework.tools.modularity.module.entity.ModuleFeature;
import com.onework.tools.modularity.module.service.IModuleErrorMessageService;
import com.onework.tools.modularity.module.service.IModuleFeatureService;
import com.onework.tools.modularity.module.service.IModuleService;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.service.module
 * @Description: 描述
 * @date Date : 2022年04月26日 13:57
 */
@Service
public class ModuleStoreImpl implements ModuleStore {

    private final IModuleFeatureService moduleFeatureService;

    private final IModuleErrorMessageService moduleErrorMessageService;

    private final IModuleService moduleService;

    public ModuleStoreImpl(IModuleService moduleService, IModuleFeatureService moduleFeatureService,
        IModuleErrorMessageService moduleErrorMessageService) {
        this.moduleService = moduleService;
        this.moduleFeatureService = moduleFeatureService;
        this.moduleErrorMessageService = moduleErrorMessageService;
    }

    @Override
    public void addModule(AppModule module) {
        com.onework.tools.modularity.module.entity.Module dbModule =
            BeanUtil.copyProperties(module, com.onework.tools.modularity.module.entity.Module.class);
        Check.isFalse(moduleService.save(dbModule),
            new AppException(ModuleException.ADD_MODULE_ERROR, module.getCode()));
    }

    @Override
    public List<AppModule> getAllModules() {
        List<AppModule> modules = new ArrayList<>();
        moduleService.lambdaQuery().list()
            .forEach(module -> modules.add(BeanUtil.copyProperties(module, AppModule.class)));
        return modules;
    }

    @Override
    @Cacheable(cacheNames = CacheKeys.MODULE_ERROR_MESSAGE, key = "#moduleCode")

    public List<ErrorMessage> getModuleErrorMessages(String moduleCode) {
        List<ErrorMessage> errorMessages = new ArrayList<>();
        List<ModuleErrorMessage> moduleErrorMessages =
            moduleErrorMessageService.lambdaQuery().eq(ModuleErrorMessage::getModuleCode, moduleCode).list();
        moduleErrorMessages.forEach(moduleErrorMessage -> errorMessages.add(
            new ErrorMessageImlp(moduleErrorMessage.getCode(), moduleErrorMessage.getName())));
        return errorMessages;
    }

    @Override
    public void addModuleErrorMessage(AppModule module, List<ErrorMessage> errorMessages) {
        List<ModuleErrorMessage> moduleErrorMessages = new ArrayList<>();
        errorMessages.forEach(errorMessage -> {
            ModuleErrorMessage moduleErrorMessage = new ModuleErrorMessage();
            moduleErrorMessage.setCode(errorMessage.getCode());
            moduleErrorMessage.setName(errorMessage.getMessage());
            moduleErrorMessage.setModuleCode(module.getCode());
            moduleErrorMessage.setModuleName(module.getName());
            moduleErrorMessages.add(moduleErrorMessage);
        });
        if (moduleErrorMessages.size() > 0) {
            Check.isFalse(moduleErrorMessageService.saveBatch(moduleErrorMessages),
                new AppException(ModuleException.ADD_MODULE_ERROR_MESSAGE_ERROR));
        }
    }

    @Override
    public void deleteModuleFeatures(AppModule module) {
        LambdaQueryWrapper<ModuleFeature> wrapper = new LambdaQueryWrapper<>();
        wrapper.eq(ModuleFeature::getModuleCode, module.getCode());

        /**
         * Check.isFalse(moduleFeatureService.remove(wrapper)
         * new AppException(ModuleException.ADD_MODULE_ERROR_MESSAGE_ERROR));
         * 没有数据可删也是返回false
         */
        moduleFeatureService.remove(wrapper);
    }

    @Override
    public void addModuleFeatures(AppModule module, List<AppFeature> features) {

        List<ModuleFeature> moduleFeatures = new ArrayList<>();
        features.forEach(feature -> {
            ModuleFeature moduleFeature = BeanUtil.copyProperties(feature, ModuleFeature.class);
            moduleFeature.setModuleName(module.getName());
            moduleFeature.setModuleCode(module.getCode());
            moduleFeature.setState(FeatureState.enable.toString());
            moduleFeatures.add(moduleFeature);
        });
        if (moduleFeatures.size() > 0) {
            moduleFeatureService.saveBatch(moduleFeatures);
        }
    }
}
