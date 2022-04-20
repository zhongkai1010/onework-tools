package com.onework.tools.domain.authenticate;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 15:11
 */

public class DomainAuthenticateException extends BaseException {

    private static final long serialVersionUID = -3937133175723171509L;

    public DomainAuthenticateException(String code) {
        this(code, null);
    }

    public DomainAuthenticateException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return DomainAuthenticateModule.MODULE_CODE;
    }
}


