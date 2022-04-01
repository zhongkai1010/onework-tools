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

    public final static String SAVE_DATABASE_ERROR = "0004";

    public final static String SAVE_TABLE_ERROR = "0005";

    public final static String SAVE_COLUMN_ERROR = "0005";

    public final static String NOT_FIND_CONNECTION = "0006";

    // endregion

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorCodeMap() {

        return new Hashtable<String, String>() {
            private static final long serialVersionUID = -7207722230552763780L;

            {
                put(ServerDatabaseModule.DELETE_CONNECTION, "删除数据库连接失败");
                put(ServerDatabaseModule.ADD_CONNECTION, "添加数据库连接失败");
                put(ServerDatabaseModule.UPDATE_CONNECTION, "修改数据库连接失败");
                put(ServerDatabaseModule.SAVE_DATABASE_ERROR, "添加或修改数据库失败");
                put(ServerDatabaseModule.SAVE_TABLE_ERROR, "添加或修改数据库表失败");
                put(ServerDatabaseModule.SAVE_COLUMN_ERROR, "添加或修改表字段失败");
                put(ServerDatabaseModule.NOT_FIND_CONNECTION, "数据库连接不存在");
            }
        };
    }
}
