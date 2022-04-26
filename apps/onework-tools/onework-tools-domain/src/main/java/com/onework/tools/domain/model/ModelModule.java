package com.onework.tools.domain.model;

import com.onework.tools.core.module.BaseModule;
import com.onework.tools.core.module.ModuleInfo;
import org.springframework.stereotype.Component;

import java.util.HashMap;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model
 * @Description: 描述
 * @date Date : 2022年04月22日 10:32
 */
@Component
public class ModelModule implements BaseModule {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "3001";

    @Override
    public ModuleInfo getModuleInfo() {
        return new ModuleInfo(MODULE_CODE, "数据模型模块");
    }

    @Override
    public Map<String, String> getExceptionEnum() {
        ModelException[] exceptions = ModelException.values();
        Map<String, String> messageMap = new HashMap<>(exceptions.length);

        for (ModelException exception : exceptions) {
            String code = exception.getCode();
            String key = String.format("%s.%s", MODULE_CODE, code);
            if (messageMap.containsKey(key)) {
                throw new RuntimeException(String.format("load module exception enum error key is repeat，key:%s", key));
            }
            messageMap.put(key, exception.getMessage());
        }
        return messageMap;
    }

}