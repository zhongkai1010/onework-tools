package com.onework.tools.domain.database;

import com.onework.tools.core.error.BaseErrorTemplate;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author zhongkai
 */
public class DatabaseDomainErrorTemplate extends BaseErrorTemplate {

    public final static String DbTypeNotNull = "0001";
    public final static String DbNameNotNull = "0002";
    public final static String DbHostNotNull = "0003";
    public final static String DbUserNotNull = "0004";
    public final static String DbPwdNotNull = "0005";
    public final static String DbConnectionError = "0006";
    public final static String DbSchemaServerError = "0007";

    @Override
    protected Map<String, String> getMessageMap() {
        return new Hashtable<String, String>() {{
            put(DbTypeNotNull, "数据库类型不能为空");
            put(DbNameNotNull, "数据库连接名称不能为空");
            put(DbHostNotNull, "数据库连接地址不能为空");
            put(DbUserNotNull, "数据库连接用户不能为空");
            put(DbPwdNotNull, "数据库连接密码不能为空");
            put(DbConnectionError, "数据库连接失败");
            put(DbSchemaServerError, "获取数据库结构服务异常");
        }};
    }

    @Override
    public String getBaseCode() {
        return null;
    }
}
