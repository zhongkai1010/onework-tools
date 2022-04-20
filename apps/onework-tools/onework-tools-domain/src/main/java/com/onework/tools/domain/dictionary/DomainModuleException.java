package com.onework.tools.domain.dictionary;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 15:11
 */

public class DomainModuleException extends BaseException {

    private static final long serialVersionUID = -5492911598268839979L;

    public DomainModuleException(String code) {
        this(code, null);
    }

    public DomainModuleException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return DomainDictionaryModule.MODULE_CODE;
    }
}


