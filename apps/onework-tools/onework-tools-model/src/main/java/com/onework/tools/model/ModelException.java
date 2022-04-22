package com.onework.tools.model;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model
 * @Description: 描述
 * @date Date : 2022年04月22日 10:32
 */
public class ModelException extends BaseException {
    
    public ModelException(String code) {
        super(code);
    }

    public ModelException(String code, String formatParam) {
        super(code, formatParam);
    }

    public ModelException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return null;
    }
}
