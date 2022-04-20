package com.onework.tools.domain.template;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 15:11
 */

public class DomainTemplateException extends BaseException {

    private static final long serialVersionUID = 32984349771854564L;

    public DomainTemplateException(String code) {
        this(code, null);
    }

    public DomainTemplateException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return DomainTemplateModule.MODULE_CODE;
    }
}


