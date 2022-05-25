package com.onework.tools.modularity.dictionary.domain.vo;

import com.onework.tools.domain.entity.Entity;
import com.onework.tools.domain.entity.NameCodeValue;
import lombok.Data;

import javax.validation.constraints.NotNull;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月25日 15:44
 */
@Data
public class DictionaryGroupVo implements Entity, NameCodeValue {

    private String uid;

    @NotNull
    private String name;

    @NotNull
    private String code;

    private String defaultValue;
    /**
     * one、many
     */
    @NotNull
    private DictionaryGroupType type;
}
