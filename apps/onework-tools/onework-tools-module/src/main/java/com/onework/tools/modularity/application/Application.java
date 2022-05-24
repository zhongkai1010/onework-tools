package com.onework.tools.modularity.application;

import com.onework.tools.domain.module.AppFeature;
import com.onework.tools.entity.Entity;
import lombok.Data;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain
 * @Description: 应用信息
 * @date Date : 2022年05月23日 14:32
 */
@Data
public class Application implements Entity {

    /**
     * 应用标识
     */
    private String uid;

    /**
     * 应用编码，用于其它应用相关编码组合
     */
    private String code;

    /**
     * 应用名称
     */
    private String name;

    /**
     * 应用功能
     *
     * @return
     */
    private List<AppFeature> features;
}
