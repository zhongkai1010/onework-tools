package com.onework.tools.identity;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:37
 */

public class IdentityException extends BaseException {

    private static final long serialVersionUID = -4430858380871196624L;

    public IdentityException(String code) {
        super(code);
    }

    public IdentityException(String code, String formatParam) {
        super(code, formatParam);
    }

    public IdentityException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return IdentityModule.MODULE_CODE;
    }
}
