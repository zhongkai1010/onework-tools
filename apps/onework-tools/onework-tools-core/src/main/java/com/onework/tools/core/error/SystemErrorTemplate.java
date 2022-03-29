package com.onework.tools.core.error;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.error
 * @Description: 描述
 * @date Date : 2022年03月29日 14:02
 */
public class SystemErrorTemplate extends BaseErrorTemplate {


    public final static String Unknown = "0000.0000";

    public final static String IsNotNull = "0000.0001";

    @Override
    protected Map<String, String> getMessageMap() {
        return new Hashtable<String, String>() {{
            put(Unknown, "未知异常");
            put(IsNotNull, "%s,参数不能为空");
        }};
    }

    @Override
    public String getBaseCode() {
        return "0000";
    }
}
