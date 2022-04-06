package com.onework.tools.core.error;

import com.onework.tools.core.CoreModule;

/**
 * 系统异常类
 * 默认异常编码：1000
 *
 * @author zhongkai
 */
public class SystemExcption extends BaseException {

    public SystemExcption(final String code) {
        super(code);
    }

    @Override
    protected String getModuleCode() {
        return CoreModule.MODULE_CODE;
    }

}
