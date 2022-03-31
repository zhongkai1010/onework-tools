package com.onework.tools.server.database.error;

import com.onework.tools.core.error.BaseException;
import com.onework.tools.server.database.ServerDatabaseModule;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.database
 * @Description: 描述
 * @date Date : 2022年03月31日 9:53
 */
@Component
@Scope("prototype")
public class DatabaseServerException extends BaseException {

    public DatabaseServerException(String code) {
        super(code);
    }

    @Override
    protected String getModuleCode() {
        return ServerDatabaseModule.MODULE_CODE;
    }
}
