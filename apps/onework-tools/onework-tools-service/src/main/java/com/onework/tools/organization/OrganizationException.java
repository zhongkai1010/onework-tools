package com.onework.tools.organization;

import com.onework.tools.core.error.ErrorMessage;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:37
 */

public enum OrganizationException implements ErrorMessage {
    /**
     *
     */
    DB_TYPE_IS_NULL("1001", "数据库类型不能为空"),
    CONNECTION_NAME_IS_NULL("1002", "数据库连接名称不能为空"),
    DB_HOST_IS_NULL("1003", "数据库连接地址不能为空"),
    DB_USER_IS_NULL("1004", "数据库连接用户不能为空"),
    DB_PASSWORD_IS_NULL("1005", "数据库连接密码不能为空"),
    DB_CONNECTION_ERROR("1006", "数据库连接失败"),
    DB_SCHEMA_SERVER_ERROR("1007", "获取数据库结构服务异常"),

    SYSC_CONNECTION_ERROR("1008", "同步数据数库，数据库连接异常，连接名称：%s"),
    SYSC_CONNECTION_DATABASE_ERROR("1009", "同步数据库，数据库异常，数据库名称：%s"),
    SYSC_DATABASE_CONNECTION_ERROR("1010", "同步数据库,数据连接异常，数据库名称：%s"),
    SYSC_TABLE_ERROR("1011", "同步数据库%表异常"),

    DELETE_CONNECTION("1012", "删除数据库连接失败"),
    ADD_CONNECTION("1013", "添加数据库连接失败"),
    UPDATE_CONNECTION("1014", "修改数据库连接失败"),
    SAVE_DATABASE_ERROR("1015", "添加或修改数据库失败"),
    SAVE_TABLE_ERROR("1016", "添加或修改数据库表失败"),
    SAVE_COLUMN_ERROR("1017", "添加或修改表字段失败"),
    NOT_FIND_CONNECTION("1018", "数据库连接不存在");

    /**
     * 错误码
     */
    private final String code;

    /**
     * 错误描述
     */
    private final String message;

    OrganizationException(String code, String message) {
        this.code = code;
        this.message = message;
    }

    @Override
    public String getCode() {
        return code;
    }

    @Override
    public String getMessage() {
        return message;
    }

    /**
     * 返回模块斌吗
     */
    @Override
    public String getModuleCode() {
        return OrganizationModule.MODULE_CODE;
    }

}