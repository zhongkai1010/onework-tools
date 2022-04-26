package com.onework.tools.core.module;

import lombok.Data;
import lombok.experimental.Accessors;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.module.entity
 * @Description: 描述
 * @date Date : 2022年04月25日 14:15
 */

@Data
@Accessors(chain = true)
public class Feature {
    private String code;
    private String name;
    private String extData;
    private List<Feature> subFeatures;
    private List<FeatureOperate> operates;

    public Feature(String code, String name) {
        this.code = code;
        this.name = name;
        subFeatures = new ArrayList<>();
        operates = new ArrayList<>();
    }
}
