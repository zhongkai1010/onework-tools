package com.onework.tools.domain.user;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 15:11
 */

public class DomainUserException extends BaseException {

    public DomainUserException(String code) {
        this(code, null);
    }

    public DomainUserException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return DomainUserModule.MODULE_CODE;
    }
}


