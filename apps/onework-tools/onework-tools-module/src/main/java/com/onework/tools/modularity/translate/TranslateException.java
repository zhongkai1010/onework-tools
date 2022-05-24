package com.onework.tools.modularity.translate;

import com.onework.tools.ErrorMessage;
import lombok.Getter;

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
    THREE_API_NOT_DATA("1001", "调用第三方翻译Api，无响应结果"),
    LANGUAGE_TYPE_ERROR("1002", "翻译语种错误"),
    THREE_API_RESULT_ERROR("1003", "调用第三方翻译Api，响应结果异常，异常编码:%s"),
    NOT_SUCCESS_INSERT_RECORD("1004", "未成功插入翻译文本记录");

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
     *
     * @param code
     * @param message
     */
    TranslateException(String code, String message) {
        this.code = code;
        this.message = message;
    }
}
