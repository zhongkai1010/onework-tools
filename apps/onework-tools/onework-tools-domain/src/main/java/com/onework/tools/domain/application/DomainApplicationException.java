package com.onework.tools.domain.application;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 15:11
 */

public class DomainApplicationException extends BaseException {

    private static final long serialVersionUID = 21303685179387364L;

    public DomainApplicationException(String code) {
        this(code, null);
    }

    public DomainApplicationException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return DomainApplicationModule.MODULE_CODE;
    }
}


