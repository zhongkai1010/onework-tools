package com.onework.tools.organization;

import com.onework.tools.core.error.ErrorMessage;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:37
 */

public enum OrganizationException implements ErrorMessage {
    /**
     *
     */
    ;

    /**
     * 错误码
     */
    private final String code;

    /**
     * 错误描述
     */
    private final String message;

    OrganizationException(String code, String message) {
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
        return OrganizationModule.MODULE_CODE;
    }

}