package com.onework.tools.core.error;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.error
 * @Description: 描述
 * @date Date : 2022年03月29日 13:41
 */
public abstract class BaseException extends Exception {

    private final ErrorTemplate errorTemplate;

    private final String code;

    private Boolean doFormat;

    private Object[] formatParams;

    public BaseException(ErrorTemplate errorTemplate, String code) {

        this.errorTemplate = errorTemplate;
        this.code = code;
        this.doFormat = false;
    }


    /**
     * 格式化参数
     *
     * @param params
     */
    public Exception format(Object... params) {
        this.doFormat = true;
        this.formatParams = params;
        return this;
    }

    @Override
    public String getMessage() {
        String baseCode = errorTemplate.getBaseCode();
        String errorCode = String.format("%s.%s", baseCode, this.code);
        String message = errorTemplate.getMessage(errorCode);
        if (this.doFormat) {
            return String.format(message, formatParams);
        }
        return message;
    }
}

