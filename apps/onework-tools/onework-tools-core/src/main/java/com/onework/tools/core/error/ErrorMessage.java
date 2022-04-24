package com.onework.tools.core.error;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.error
 * @Description: 描述
 * @date Date : 2022年04月24日 14:31
 */
public interface ErrorMessage  {

    /**
     * 获取错误代码
     *
     * @return
     */
    String getCode();

    /**
     * 获取错误消息
     *
     * @return
     */
    String getMessage();

    /**
     * 获取模块代码
     *
     * @return
     */
    String getModuleCode();
}
