package com.onework.tools.server.translate;

import com.onework.tools.core.module.Module;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.translate
 * @Description: 描述
 * @date Date : 2022年04月14日 17:33
 */
public class ServerTranslateModule implements Module {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "3002";

    public final static String NOT_SUCCESS_INSERT_RECORD = "0001";

    @Override
    public String getModuleName() {
        return "翻译模块";
    }

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorMessageMaps() {
        return new Hashtable<String, String>() {
            {
                put(ServerTranslateModule.NOT_SUCCESS_INSERT_RECORD, "未成功插入翻译文本记录");
            }
        };
    }
}
