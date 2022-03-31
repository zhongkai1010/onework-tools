package com.onework.tools.core.error;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.error
 * @Description: 描述
 * @date Date : 2022年03月29日 13:41
 */

public abstract class BaseException extends RuntimeException {

    private static final long serialVersionUID = 7969689764816292922L;
    private final String code;
    private Boolean doFormat = false;
    private Object[] formatParams = new Object[] {};

    protected BaseException(String code) {
        this.code = code;
    }

    /**
     * 获取模块编码，便于区分不同模块异常
     *
     * @return
     */
    protected abstract String getModuleCode();

    /**
     * 设置异常编码
     *
     * @param params
     * @return
     */
    public void format(Object... params) {
        doFormat = true;
        formatParams = params;
    }

    @Override
    public String getMessage() {

        String message = "unknown unknown";
        String moduleCode = getModuleCode();
        String key = String.format("%s.%s", moduleCode, code);

        if (ErrorMessageManger.ErrorMessageCodeMap.containsKey(key)) {
            message = ErrorMessageManger.ErrorMessageCodeMap.get(key);
        }

        if (doFormat) {
            message = String.format(message, formatParams);
        }

        return message;
    }
}

