package com.onework.tools.domain.database;

import com.onework.tools.core.error.BaseException;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 15:11
 */
@Component
@Scope("prototype")
public class DatabaseDomainException extends BaseException {

    public DatabaseDomainException(String code) {
        this(code, null);
    }

    public DatabaseDomainException(String code, String[] formatParams) {
        super(code, formatParams);
    }

    @Override
    protected String getModuleCode() {
        return DomainDatabaseModule.MODULE_CODE;
    }
}


