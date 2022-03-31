package com.onework.tools.core;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.domain
 * @Description: 描述
 * @date Date : 2022年03月29日 11:30
 */
public class Check {

    public static <T, E extends Throwable> void notNull(T value, E exception) throws E {
        if (value == null) {
            throw exception;
        }
    }
}
