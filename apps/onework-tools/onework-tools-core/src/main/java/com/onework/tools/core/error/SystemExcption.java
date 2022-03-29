package com.onework.tools.core.error;

/**
 * 系统异常类
 * 默认异常编码：0000
 *
 * @author zhongkai
 */
public class SystemExcption extends BaseException {

    public SystemExcption(String code) {
        super(new SystemErrorTemplate(), code);
    }
}
