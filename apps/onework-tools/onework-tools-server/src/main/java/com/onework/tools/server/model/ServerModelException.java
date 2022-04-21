package com.onework.tools.server.model;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.translate
 * @Description: 描述
 * @date Date : 2022年04月14日 17:34
 */
public class ServerModelException extends BaseException {

    public ServerModelException(String code) {
        super(code);
    }

    public ServerModelException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return ServerModelModule.MODULE_CODE;
    }
}
