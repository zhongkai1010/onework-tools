package com.onework.tools;

import com.onework.tools.domain.entity.NameCodeValue;
import lombok.Getter;

import java.util.HashMap;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain
 * @Description: 描述
 * @date Date : 2022年05月25日 16:02
 */
public enum DictionaryGroupData implements NameCodeValue {

    /**
     *
     */
    SEX("sex", "性别", new HashMap<String, String>() {{
        put("男", "man");
        put("女", "female");
    }});

    @Getter
    private String name;

    @Getter
    private String code;

    private Map<String, String> items;

    DictionaryGroupData(String name, String code) {
        this.name = name;
        this.code = code;
    }

    DictionaryGroupData(String name, String code, Map<String, String> items) {
        this.name = name;
        this.code = code;
        this.items = items;
    }
}
