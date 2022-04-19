package com.onework.tools.domain.model;

import com.onework.tools.core.module.Module;
import org.springframework.stereotype.Component;

import java.util.Hashtable;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model
 * @Description: 描述
 * @date Date : 2022年04月18日 15:32
 */
@Component
public class DomainModelModule implements Module {

    /**
     * 模块异常编号
     */
    public final static String MODULE_CODE = "3001";

    @Override
    public String getModuleName() {
        return "数据模型领域模块";
    }

    @Override
    public String getModuleCode() {
        return MODULE_CODE;
    }

    @Override
    public Map<String, String> getErrorMessageMaps() {
        return new Hashtable<String, String>() {{

        }};
    }
}
