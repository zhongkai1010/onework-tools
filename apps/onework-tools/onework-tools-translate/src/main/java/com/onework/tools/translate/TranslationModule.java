package com.onework.tools.translate;

import com.onework.tools.core.module.Module;
import org.springframework.stereotype.Component;

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
@Component
public class TranslationModule implements Module {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "2002";

    public static final String THREE_API_NOT_DATA = "0001";

    public static final String LANGUAGE_TYPE_ERROR = "0002";

    public static final String THREE_API_RESULT_ERROR = "0003";

    public final static String NOT_SUCCESS_INSERT_RECORD = "0001";

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
            put(THREE_API_NOT_DATA, "调用第三方翻译Api，无响应结果");
            put(LANGUAGE_TYPE_ERROR, "翻译语种错误");
            put(THREE_API_RESULT_ERROR, "调用第三方翻译Api，响应结果异常，异常编码:%s");
            put(NOT_SUCCESS_INSERT_RECORD, "未成功插入翻译文本记录");
        }};
    }
}
