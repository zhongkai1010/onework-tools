package com.onework.tools.dictionary;

import com.onework.tools.domain.entity.NameCodeValue;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary
 * @Description: 描述
 * @date Date : 2022年05月26日 9:23
 */
public interface DictionaryGroupValue extends NameCodeValue {

    /**
     * 获取字典选项
     * @return
     */
    Map<String, String> getItems();
}
