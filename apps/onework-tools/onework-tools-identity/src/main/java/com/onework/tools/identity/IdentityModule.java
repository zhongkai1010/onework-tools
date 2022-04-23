package com.onework.tools.identity;

import com.onework.tools.core.module.Module;
import org.springframework.stereotype.Component;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.database
 * @Description: 描述
 * @date Date : 2022年04月22日 9:41
 */
@Component
public class IdentityModule implements Module {

    /**
     * 模块异常编号
     */
    public static final String MODULE_CODE = "2001";

    @Override
    public String getModuleName() {
        return "数据库模块";
    }

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorMessageMaps() {

        return new Hashtable<String, String>() {
            private static final long serialVersionUID = -9044594595120588294L;

            {

            }
        };
    }
}
