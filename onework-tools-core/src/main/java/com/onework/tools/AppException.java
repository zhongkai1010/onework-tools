package com.onework.tools;

import com.onework.tools.domain.module.ModuleManager;
import com.onework.tools.error.ErrorMessage;
import com.onework.tools.error.ErrorMessageImlp;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.error
 * @Description: 描述
 * @date Date : 2022年03月29日 13:41
 */

public class AppException extends RuntimeException {

    private static final long serialVersionUID = 3504239473299483235L;

    private final ErrorMessage message;
    private final Object[] formatParams;

    public AppException(String message) {
        this.message = new ErrorMessageImlp(message, message);
        this.formatParams = new Object[] {};
    }

    /**
     * @param message
     */
    public AppException(ErrorMessage message) {
        this(message, new String[] {});
    }

    /**
     * @param message
     * @param formatParam
     */
    public AppException(ErrorMessage message, String formatParam) {
        this(message, new String[] {formatParam});
    }

    /**
     * @param message
     * @param formatParams
     */
    public AppException(ErrorMessage message, String[] formatParams) {
        this.message = message;
        this.formatParams = formatParams;
    }

    @Override
    public String getMessage() {

        String code = this.message.getCode();
        String message = this.message.getMessage();

        if (ModuleManager.ErrorMessageMap.containsKey(code)) {
            message = ModuleManager.ErrorMessageMap.get(code);
            if (formatParams.length > 0) {
                message = String.format(message, formatParams);
            }
        } else {
            if (message != null) {
                return message;
            }
            return "unknown unknown";
        }

        return message;
    }
}

