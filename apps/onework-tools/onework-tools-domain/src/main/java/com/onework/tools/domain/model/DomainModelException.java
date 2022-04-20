package com.onework.tools.domain.model;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model
 * @Description: 描述
 * @date Date : 2022年04月18日 15:34
 */
public class DomainModelException extends BaseException {

    public DomainModelException(String code) {
        super(code);
    }

    public DomainModelException(String code, String formatParam) {
        super(code, new String[] {formatParam});
    }

    public DomainModelException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return DomainModelModule.MODULE_CODE;
    }
}
