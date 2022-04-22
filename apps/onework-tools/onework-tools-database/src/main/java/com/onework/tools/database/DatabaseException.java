package com.onework.tools.database;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:37
 */

public class DatabaseException extends BaseException {

    public DatabaseException(String code) {
        super(code);
    }

    public DatabaseException(String code, String formatParam) {
        super(code, formatParam);
    }

    public DatabaseException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return DatabaseModule.MODULE_CODE;
    }
}
