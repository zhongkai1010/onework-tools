package com.onework.tools.core.error;

import com.onework.tools.core.CoreModule;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

/**
 * 系统异常类
 * 默认异常编码：1000
 *
 * @author zhongkai
 */
@Component
@Scope("prototype")
public class SystemExcption extends BaseException {

    public SystemExcption(String code) {
        super(code);
    }

    @Override
    protected String getModuleCode() {
        return CoreModule.MODULE_CODE;
    }

}
