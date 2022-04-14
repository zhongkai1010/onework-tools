package com.onework.tools.domain.translate;

import com.onework.tools.core.module.Module;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月14日 15:41
 */
public class DomainTranslationModule implements Module {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "2002";

    private final String THREE_API_ERROR = "0001";

    @Override
    public String getModuleName() {
        return "翻译领域模块";
    }

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorMessageMaps() {
        return new Hashtable<String, String>() {{
            put(THREE_API_ERROR, "调用第三方翻译Api异常");
        }};
    }
}
