package com.onework.tools.modularity.file;

import lombok.Getter;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:37
 */

public enum FileException {

    ;

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
    FileException(String code, String message) {
        this.code = code;
        this.message = message;
    }
}