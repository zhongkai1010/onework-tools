package com.onework.tools.server.database;

import com.onework.tools.core.module.ModuleInfo;
import org.springframework.stereotype.Component;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.database
 * @Description: 描述
 * @date Date : 2022年03月31日 17:16
 */
@Component
public class ServerDatabaseModule implements ModuleInfo {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "3001";

    // region 异常常量

    public final static String DELETE_CONNECTION = "0001";

    public final static String ADD_CONNECTION = "0002";

    public final static String UPDATE_CONNECTION = "0003";

    // endregion

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorCodeMap() {

        return new Hashtable<String, String>() {{
            put(DELETE_CONNECTION, "删除数据库连接失败");
            put(ADD_CONNECTION, "添加数据库连接失败");
            put(UPDATE_CONNECTION, "修改数据库连接失败");
        }};
    }
}
