package com.onework.tools.domain.module;

import cn.hutool.core.collection.CollectionUtil;
import com.onework.tools.domain.entity.Entity;
import lombok.Data;
import lombok.experimental.Accessors;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.module.entity
 * @Description: 功能
 * @date Date : 2022年04月25日 14:15
 */

@Data
@Accessors(chain = true)
public class AppFeature implements Entity {

    /**
     * 功能标识
     */
    private String uid;

    /**
     * 功能编码
     */
    private String code;

    /**
     * 功能名称
     */
    private String name;

    /**
     * 功能操作
     */
    private List<AppFeatureOperate> operates;

    /**
     * 子功能
     */
    private List<AppFeature> children;

    public AppFeature(String code, String name) {
        this.code = code;
        this.name = name;
    }

    public AppFeature addOperate(AppFeatureOperate... operates) {
        if (this.operates == null) {
            this.operates = new ArrayList<>();
        }
        CollectionUtil.addAll(this.operates, operates);
        return this;
    }

    public AppFeature addFeature(AppFeature... features) {
        if (this.children == null) {
            this.children = new ArrayList<>();
        }
        CollectionUtil.addAll(this.children, features);
        return this;
    }
}
