package com.onework.tools.module;

import com.onework.tools.core.module.BaseModule;
import com.onework.tools.core.module.Feature;
import com.onework.tools.core.module.FeatureProvider;
import com.onework.tools.core.module.ModuleInfo;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:41
 */
@Component
public class ModuleModule implements BaseModule, FeatureProvider {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "2001";

    @Override
    public ModuleInfo getModuleInfo() {

        return new ModuleInfo(MODULE_CODE, "数据库模块");
    }

    @Override
    public Feature getModuleFeature() {
        return new Feature("", "").setSubFeatures(new ArrayList<Feature>() {
            private static final long serialVersionUID = -6910055370793869447L;

            {
            add(new Feature("", ""));
        }});
    }

    @Override
    public Map<String, String> getExceptionEnum() {

        ModuleException[] databaseExceptions = ModuleException.values();
        Map<String, String> messageMap = new HashMap<>(databaseExceptions.length);

        for (ModuleException databaseException : databaseExceptions) {
            String code = databaseException.getCode();
            String key = String.format("%s.%s", MODULE_CODE, code);
            if (messageMap.containsKey(key)) {
                throw new RuntimeException(String.format("load module exception enum error key is repeat，key:%s", key));
            }
            messageMap.put(key, databaseException.getMessage());
        }
        return messageMap;
    }

}
