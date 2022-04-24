package com.onework.tools.core.error;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.error
 * @Description: 描述
 * @date Date : 2022年04月24日 14:32
 */
public enum ExceptionEnum implements ErrorMessage {

    // region 异常常量

    UNKNOWN("0000", "未知异常");

    // endregion

    /**
     * 错误码
     */
    private final String code;

    /**
     * 错误描述
     */
    private final String message;

    ExceptionEnum(String code, String message) {
        this.code = code;
        this.message = message;
    }

    @Override
    public String getCode() {
        return code;
    }

    @Override
    public String getMessage() {
        return message;
    }

    @Override
    public String getModuleCode() {
        return "0000";
    }
}
