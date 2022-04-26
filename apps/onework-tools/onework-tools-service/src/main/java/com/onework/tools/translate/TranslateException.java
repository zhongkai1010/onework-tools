package com.onework.tools.translate;

import com.onework.tools.core.error.ErrorMessage;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月14日 15:38
 */
public enum TranslateException implements ErrorMessage {

    /**
     *
     */
    THREE_API_NOT_DATA("1000", "调用第三方翻译Api，无响应结果"),
    LANGUAGE_TYPE_ERROR("1000", "翻译语种错误"),
    THREE_API_RESULT_ERROR("1000", "调用第三方翻译Api，响应结果异常，异常编码:%s"),
    NOT_SUCCESS_INSERT_RECORD("1000", "未成功插入翻译文本记录");

    /**
     * 错误码
     */
    private final String code;

    /**
     * 错误描述
     */
    private final String message;

    TranslateException(String code, String message) {
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
        return TranslationModule.MODULE_CODE;
    }
}
