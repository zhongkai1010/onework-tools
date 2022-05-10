package com.onework.tools;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.core.Check;
import com.onework.tools.core.error.AppException;
import com.onework.tools.core.module.Feature;
import com.onework.tools.core.module.ModuleInfo;
import com.onework.tools.core.module.ModuleStore;
import com.onework.tools.module.ModuleException;
import com.onework.tools.module.domain.FeatureState;
import com.onework.tools.module.entity.Module;
import com.onework.tools.module.entity.ModuleErrorMessage;
import com.onework.tools.module.entity.ModuleFeature;
import com.onework.tools.module.service.IModuleErrorMessageService;
import com.onework.tools.module.service.IModuleFeatureService;
import com.onework.tools.module.service.IModuleService;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.stereotype.Service;

import java.util.*;
import java.util.stream.Collectors;

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

    private final IModuleService moduleService;

    private final IModuleFeatureService moduleFeatureService;

    private final IModuleErrorMessageService moduleErrorMessageService;

    public ModuleStoreImpl(IModuleService moduleService, IModuleFeatureService moduleFeatureService,
        IModuleErrorMessageService moduleErrorMessageService) {
        this.moduleService = moduleService;
        this.moduleFeatureService = moduleFeatureService;
        this.moduleErrorMessageService = moduleErrorMessageService;
    }

    @Override
    public void registerModule(ModuleInfo moduleInfo) {

        String moduleCode = moduleInfo.getCode();
        LambdaQueryChainWrapper<Module> wrapper = moduleService.lambdaQuery();
        Module module = wrapper.eq(Module::getCode, moduleCode).one();
        if (module == null) {
            module = BeanUtil.copyProperties(moduleInfo, Module.class);
            moduleService.save(module);
        }
    }

    @Override
    public void saveModuleFeature(ModuleInfo moduleInfo, Feature feature) {

        Module module = moduleService.lambdaQuery().eq(Module::getCode, moduleInfo.getCode()).one();
        Check.notNull(module, new AppException(ModuleException.SAVE_MODULE_FEATURE_ERROR, moduleInfo.getName()));

        List<ModuleFeature> moduleFeatures =
            moduleFeatureService.lambdaQuery().eq(ModuleFeature::getModuleCode, moduleInfo.getCode()).list();

        Map<String, Feature> featureMap = convertModuleFeature(feature);
        Map<String, ModuleFeature> moduleFeatureMap =
            moduleFeatures.stream().collect(Collectors.toMap(ModuleFeature::getCode, current -> current));

        Set<String> featureMapKeys = featureMap.keySet();
        Set<String> moduleFeatureMapKeys = moduleFeatureMap.keySet();

        // 比较已不存在功能，数据库中功能没有在代码定义
        moduleFeatures.forEach(current -> {
            if (featureMapKeys.contains(current.getCode())) {
                current.setState(FeatureState.enable.toString());
            } else {
                current.setState(FeatureState.disabled.toString());
            }
        });
        moduleFeatureService.saveOrUpdateBatch(moduleFeatures);

        // 比较是否新的定义功能，代码定义功能没有在数据库中
        List<ModuleFeature> newFeatures = new ArrayList<>();
        featureMapKeys.forEach(key -> {
            if (!moduleFeatureMapKeys.contains(key)) {
                ModuleFeature moduleFeature = BeanUtil.copyProperties(featureMap.get(key), ModuleFeature.class);
                moduleFeature.setModuleCode(moduleInfo.getCode());
                moduleFeature.setModuleName(moduleInfo.getName());
                moduleFeature.setState(FeatureState.enable.toString());
                newFeatures.add(moduleFeature);
            }
        });
        moduleFeatureService.saveOrUpdateBatch(newFeatures);
    }

    @Override
    public void saveErrorMessage(ModuleInfo moduleInfo, Map<String, String> errorMessage) {

        List<ModuleErrorMessage> moduleErrorMessages =
            moduleErrorMessageService.lambdaQuery().eq(ModuleErrorMessage::getModuleCode, moduleInfo.getCode()).list();
        Map<String, ModuleErrorMessage> messageMap =
            moduleErrorMessages.stream().collect(Collectors.toMap(ModuleErrorMessage::getCode, current -> current));
        List<ModuleErrorMessage> newMessages = new ArrayList<>();
        errorMessage.forEach((key, message) -> {
            if (!messageMap.containsKey(key)) {
                ModuleErrorMessage moduleErrorMessage = new ModuleErrorMessage();
                moduleErrorMessage.setCode(key);
                moduleErrorMessage.setName(message);
                moduleErrorMessage.setModuleCode(moduleInfo.getCode());
                moduleErrorMessage.setModuleName(moduleInfo.getName());
                newMessages.add(moduleErrorMessage);
            }
        });
        if (newMessages.size() > 0) {
            moduleErrorMessageService.saveOrUpdateBatch(newMessages);
        }
    }

    @Override
    @Cacheable(cacheNames = CacheKeys.MODULE_ERROR_MESSAGE, key = "#moduleInfo.code")
    public Map<String, String> getModuleErrorMessage(ModuleInfo moduleInfo) {
        List<ModuleErrorMessage> moduleErrorMessages =
            moduleErrorMessageService.lambdaQuery().eq(ModuleErrorMessage::getModuleCode, moduleInfo.getCode()).list();
        return moduleErrorMessages.stream()
            .collect(Collectors.toMap(ModuleErrorMessage::getCode, ModuleErrorMessage::getName));
    }

    private static Map<String, Feature> convertModuleFeature(Feature feature) {
        HashMap<String, Feature> featureMap = new HashMap<>(16);
        featureMap.put(feature.getCode(), feature);

        List<Feature> subs = feature.getSubFeatures();
        if (subs.size() > 0) {
            subs.forEach(subFeature -> {
                subFeature.setCode(String.format("%s.%s", feature.getCode(), subFeature.getCode()));
                featureMap.putAll(convertModuleFeature(subFeature));
            });
        }
        return featureMap;
    }
}
