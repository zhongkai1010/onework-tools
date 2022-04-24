package com.onework.tools.core.error;

import com.onework.tools.core.module.ModuleManager;

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

    public AppException(ErrorMessage message) {
        this(message, new String[] {});
    }

    public AppException(ErrorMessage message, String formatParam) {
        this(message, new String[] {formatParam});
    }

    public AppException(ErrorMessage message, String[] formatParams) {

        this.message = message;
        this.formatParams = formatParams;
    }

    @Override
    public String getMessage() {

        String message = "unknown unknown";
        String moduleCode = this.message.getModuleCode();
        String code = this.message.getCode();
        String key = String.format("%s.%s", moduleCode, code);

        if (ModuleManager.ErrorMessage.containsKey(key)) {
            message = ModuleManager.ErrorMessage.get(key);
        }

        if (formatParams.length > 0) {
            message = String.format(message, formatParams);
        }

        return message;
    }
}

