package com.onework.tools.organization;

import com.onework.tools.core.module.BaseModule;
import com.onework.tools.core.module.ModuleInfo;
import org.springframework.stereotype.Component;

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
public class OrganizationModule implements BaseModule {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "B011";

    @Override
    public ModuleInfo getModuleInfo() {
        return new ModuleInfo(MODULE_CODE, "机构组织模块");
    }

    @Override
    public Map<String, String> getExceptionEnum() {

        OrganizationException[] databaseExceptions = OrganizationException.values();
        Map<String, String> messageMap = new HashMap<>(databaseExceptions.length);

        for (OrganizationException databaseException : databaseExceptions) {
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
