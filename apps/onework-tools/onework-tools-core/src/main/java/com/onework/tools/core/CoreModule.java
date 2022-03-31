package com.onework.tools.core;

import com.onework.tools.core.module.ModuleInfo;
import org.springframework.stereotype.Component;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core
 * @Description: 描述
 * @date Date : 2022年03月31日 16:58
 */
@Component
public class CoreModule implements ModuleInfo {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "1000";

    // region 异常编码常量

    public final static String PARAM_IS_NULL = "0001";

    //endregion

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorCodeMap() {

        return new Hashtable<String, String>() {{
            put(PARAM_IS_NULL, "%s,参数不能为空");
        }};
    }
}
