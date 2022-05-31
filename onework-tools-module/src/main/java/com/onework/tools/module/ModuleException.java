package com.onework.tools.module;

import com.onework.tools.error.ErrorMessage;
import lombok.Getter;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:37
 */

public enum ModuleException implements ErrorMessage {
    /**
     *
     */
    ADD_MODULE_ERROR("1001", "添加%s模块失败"),
    ADD_MODULE_ERROR_MESSAGE_ERROR("1002", "批量添加模块异常信息失败");
    /**
     * 错误码
     */
    @Getter
    private final String code;

    /**
     * 错误描述
     */
    @Getter
    private final String message;

    /**
     * @param code
     * @param message
     */
    ModuleException(String code, String message) {
        this.code = code;
        this.message = message;
    }

}