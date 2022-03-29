package com.onework.tools.core.error;

/**
 * 异常信息模板
 * 作用：封装错误消息，控制异常消息输出，便于后续异常信息的来源
 *
 * @author zhongkai
 */
public interface ErrorTemplate {

    /**
     * 根据 {code} 获取异常消息
     *
     * @param code 编码
     * @return 错误消息
     */
    String getMessage(String code);

    /**
     * 获取异常基础编码，四位字符串数字
     *
     * @return
     */
    String getBaseCode();
}


