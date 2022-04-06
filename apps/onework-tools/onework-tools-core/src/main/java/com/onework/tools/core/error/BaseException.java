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

public abstract class BaseException extends RuntimeException {

    private static final long serialVersionUID = 7969689764816292922L;
    private final String code;
    private final Object[] formatParams;

    protected BaseException(String code) {
        this(code, null);
    }

    protected BaseException(String code, String[] formatParams) {

        this.code = code;
        this.formatParams = formatParams;
    }

    /**
     * 获取模块编码，便于区分不同模块异常
     *
     * @return
     */
    protected abstract String getModuleCode();

    @Override
    public String getMessage() {

        String message = "unknown unknown";
        String moduleCode = getModuleCode();
        String key = String.format("%s.%s", moduleCode, code);

        if (ModuleManager.ErrorMessages.containsKey(key)) {
            message = ModuleManager.ErrorMessages.get(key);
        }

        if (formatParams != null) {
            message = String.format(message, formatParams);
        }

        return message;
    }
}

