package com.onework.tools.modularity.application;

import com.onework.tools.domain.entity.NameCodeValue;
import com.onework.tools.ModuleCode;
import com.onework.tools.domain.module.AppFeature;
import com.onework.tools.domain.module.AppFeatureOperate;
import com.onework.tools.domain.module.ModuleRegister;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.application
 * @Description: 描述
 * @date Date : 2022年05月24日 14:45
 */
@Component
public class ApplicationModule extends ModuleRegister {

    @Override
    protected NameCodeValue getModuleNameCode() {
        return ModuleCode.APPLICATION;
    }

    @Override
    protected List<AppFeature> getFeatures() {

        AppFeature feature = new AppFeature("application", "应用管理");

        // @formatter:off
        feature.addFeature(
            new AppFeature("module_list", "应用维护")
                .addOperate(new AppFeatureOperate("select", "查询")
                ),

            new AppFeature("module_error", "应用配置")
                .addOperate(
                    new AppFeatureOperate("select", "查询"),
                    new AppFeatureOperate("update", "修改")
                )
        );
        // @formatter:on
        return new ArrayList<AppFeature>() {{
            add(feature);
        }};
    }
}
