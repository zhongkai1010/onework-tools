package com.onework.tools.domain.translate;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月14日 15:38
 */
public class DomainTranslateException extends BaseException {

    public DomainTranslateException(String code) {
        super(code);
    }

    public DomainTranslateException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return DomainTranslationModule.MODULE_CODE;
    }
}
