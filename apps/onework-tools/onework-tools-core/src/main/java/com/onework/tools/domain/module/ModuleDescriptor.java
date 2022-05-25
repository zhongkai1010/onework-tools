package com.onework.tools.domain.module;

import com.onework.tools.error.ErrorMessage;
import com.onework.tools.error.ErrorMessageImlp;
import lombok.Getter;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain
 * @Description: 模块描述信息
 * @date Date : 2022年05月23日 15:30
 */

public class ModuleDescriptor {

    @Getter
    private final AppModule module;

    public ModuleDescriptor(AppModule module) {
        this.module = module;
    }

    public List<ErrorMessage> getModuleErrorMessages() {
        List<ErrorMessage> data = new ArrayList<>();
        List<ErrorMessage> errorMessages = module.getErrorMessages();
        errorMessages.forEach(errorMessage -> {
            String code = String.format("%s.%s", this.module.getCode(), errorMessage.getCode());
            String message = errorMessage.getMessage();
            data.add(new ErrorMessageImlp(code, message));
        });
        return data;
    }

    public List<AppFeature> getModuleFeatures() {
        List<AppFeature> data = new ArrayList<>();
        List<AppFeature> features = module.getFeatures();
        features.forEach(feature -> getSubFeature(feature, data));
        return data;
    }

    /**
     * 将上下级的模块功能转换集合，拼接code组成，{模块code}.{上级code}.{当前code}
     *
     * @param parentFeature
     * @param setFeature
     */
    private void getSubFeature(AppFeature parentFeature, List<AppFeature> setFeature) {

//        parentFeature.setCode(String.format("%s.%s", this.module.getCode(), parentFeature.getCode()));

        setFeature.add(parentFeature);
        if (parentFeature.getChildren() != null) {
            List<AppFeature> childrenFeature = parentFeature.getChildren();
            childrenFeature.forEach(feature -> {
                feature.setCode(String.format("%s.%s", parentFeature.getCode(), feature.getCode()));
                getSubFeature(feature, setFeature);
            });
        }
    }
}
