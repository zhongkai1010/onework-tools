package com.onework.tools.authorize;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:37
 */

public class AuthorizeException extends BaseException {

    private static final long serialVersionUID = -4430858380871196624L;

    public AuthorizeException(String code) {
        super(code);
    }

    public AuthorizeException(String code, String formatParam) {
        super(code, formatParam);
    }

    public AuthorizeException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return AuthorizeModule.MODULE_CODE;
    }
}
