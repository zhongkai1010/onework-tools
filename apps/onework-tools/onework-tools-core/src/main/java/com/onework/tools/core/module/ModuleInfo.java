package com.onework.tools.core.module;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.module
 * @Description: 描述
 * @date Date : 2022年04月24日 10:49
 */
@Data
public class ModuleInfo {

    private String code;

    private String name;

    private String version;

    public ModuleInfo(String code, String name) {
        this.code = code;
        this.name = name;
    }
}


