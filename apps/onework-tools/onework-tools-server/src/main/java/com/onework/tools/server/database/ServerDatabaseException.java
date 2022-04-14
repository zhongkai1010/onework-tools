package com.onework.tools.server.database;

import com.onework.tools.core.error.BaseException;
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
public class ServerDatabaseException extends BaseException {

    private static final long serialVersionUID = -4920886708468158443L;

    public ServerDatabaseException(String code) {
        super(code);
    }

    @Override
    protected String getModuleCode() {
        return ServerDatabaseModule.MODULE_CODE;
    }
}
