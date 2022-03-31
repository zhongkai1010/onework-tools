package com.onework.tools.core.error;

import com.onework.tools.core.module.ModuleInfo;
import org.springframework.context.ApplicationContext;
import org.springframework.stereotype.Component;

import java.util.HashMap;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.error
 * @Description: 描述
 * @date Date : 2022年03月31日 14:47
 */

@Component
public class ErrorMessageManger {

    public static Map<String, String> ErrorMessageCodeMap;

    private final ApplicationContext applicationContext;

    public ErrorMessageManger(ApplicationContext applicationContext) {

        this.applicationContext = applicationContext;

        ErrorMessageCodeMap = getModules();
    }

    private Map<String, String> getModules() {

        Map<String, String> data = new HashMap<>(16);

        Map<String, ModuleInfo> templates = applicationContext.getBeansOfType(ModuleInfo.class);

        templates.forEach((key, exception) -> {

            String moduleCode = exception.getModuleCode();

            Map<String, String> codeMap = exception.getErrorCodeMap();

            codeMap.forEach((k, v) -> {
                String code = String.format("%s.%s", moduleCode, k);
                data.put(code, v);
            });
        });

        return data;
    }
}
