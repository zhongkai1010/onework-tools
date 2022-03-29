package com.onework.tools.core;

import com.onework.tools.core.error.SystemErrorTemplate;
import com.onework.tools.core.error.SystemExcption;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.domain
 * @Description: 描述
 * @date Date : 2022年03月29日 11:30
 */
public class Check {

    public static <T,E extends Exception> void notNull(T value, String paramName) throws Exception {
        if (value == null) {
            throw new SystemExcption(SystemErrorTemplate.IsNotNull).format(paramName);
        }
    }
}
