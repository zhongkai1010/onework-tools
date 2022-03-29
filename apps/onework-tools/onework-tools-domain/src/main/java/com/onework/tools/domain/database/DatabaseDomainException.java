package com.onework.tools.domain.database;

import com.onework.tools.core.error.BaseException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月29日 15:11
 */
public class DatabaseDomainException extends BaseException {

    public DatabaseDomainException(String code) {

        super(new DatabaseDomainErrorTemplate(), code);
    }
}


