package com.onework.tools.core.error;

import java.util.Map;

/**
 * @author zhongkai
 */
public abstract class BaseErrorTemplate implements ErrorTemplate {

    private final Map<String, String> messageMap;

    protected BaseErrorTemplate() {
        messageMap = getMessageMap();
    }

    /**
     * 获取异常消息集合
     *
     * @return
     */
    protected abstract Map<String, String> getMessageMap();

    /**
     * @param code 编码
     * @return
     */
    @Override
    public String getMessage(String code) {
        if (messageMap.containsKey(code)) {
            return messageMap.get(code);
        }
        return "unknown exception";
    }
}
