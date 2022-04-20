package com.onework.tools.domain.template;

import com.onework.tools.core.module.Module;
import org.springframework.stereotype.Component;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.database
 * @Description: 描述
 * @date Date : 2022年03月31日 16:55
 */
@Component
public class DomainTemplateModule implements Module {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "2001";

    // region 异常常量

    public final static String DB_TYPE_IS_NULL = "0001";

    public final static String CONNECTION_NAME_IS_NULL = "0002";

    public final static String DB_HOST_IS_NULL = "0003";

    public final static String DB_USER_IS_NULL = "0004";

    public final static String DB_PASSWORD_IS_NULL = "0005";

    public final static String DB_CONNECTION_ERROR = "0006";

    public final static String DB_SCHEMA_SERVER_ERROR = "0007";

    public final static String SYSC_CONNECTION_ERROR = "0008";
    public final static String SYSC_CONNECTION_DATABASE_ERROR = "0009";
    public final static String SYSC_DATABASE_CONNECTION_ERROR = "0010";
    public final static String SYSC_TABLE_ERROR = "0011";

    //endregion

    @Override
    public String getModuleName() {
        return "数据库领域模块";
    }

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorMessageMaps() {
        return new Hashtable<String, String>() {
            private static final long serialVersionUID = 8927077945515871483L;

            {

                put(DomainTemplateModule.DB_TYPE_IS_NULL, "数据库类型不能为空");
                put(DomainTemplateModule.CONNECTION_NAME_IS_NULL, "数据库连接名称不能为空");
                put(DomainTemplateModule.DB_HOST_IS_NULL, "数据库连接地址不能为空");
                put(DomainTemplateModule.DB_USER_IS_NULL, "数据库连接用户不能为空");
                put(DomainTemplateModule.DB_PASSWORD_IS_NULL, "数据库连接密码不能为空");
                put(DomainTemplateModule.DB_CONNECTION_ERROR, "数据库连接失败");
                put(DomainTemplateModule.DB_SCHEMA_SERVER_ERROR, "获取数据库结构服务异常");

                put(DomainTemplateModule.SYSC_CONNECTION_ERROR, "同步数据数库，数据库连接异常，连接名称：%s");
                put(DomainTemplateModule.SYSC_CONNECTION_DATABASE_ERROR, "同步数据库，数据库异常，数据库名称：%s");
                put(DomainTemplateModule.SYSC_DATABASE_CONNECTION_ERROR, "同步数据库,数据连接异常，数据库名称：%s");
                put(DomainTemplateModule.SYSC_TABLE_ERROR, "同步数据库%表异常");
            }
        };
    }
}
