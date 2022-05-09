package com.onework.tools.identity;

import com.onework.tools.core.error.ErrorMessage;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:37
 */

public enum IdentityException implements ErrorMessage {
    /**
     *
     */
    QUERY_USER_EXIST("1001", "该“{0}”已经存在，操作失败"),
    ;

    /**
     * 错误码
     */
    private final String code;

    /**
     * 错误描述
     */
    private final String message;

    IdentityException(String code, String message) {
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

    /**
     * 返回模块斌吗
     */
    @Override
    public String getModuleCode() {
        return IdentityModule.MODULE_CODE;
    }

}