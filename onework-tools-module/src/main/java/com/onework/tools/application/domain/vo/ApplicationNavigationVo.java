package com.onework.tools.application.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

import javax.validation.constraints.NotNull;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.application.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月25日 11:21
 */
@Data
public class ApplicationNavigationVo implements Entity {

    /**
     * 导航id
     */
    private String uid;

    /**
     * 系统id
     */
    @NotNull
    private String systemId;

    /**
     * 系统名称
     */
    private String systemName;

    /**
     * 路径
     */
    @NotNull
    private String path;

    /**
     * 导航编码，唯一
     */
    @NotNull
    private String code;

    /**
     * 导航名称，可以同名
     */
    @NotNull
    private String name;

    /**
     * 上级导航
     */
    private String parentId;

    /**
     * 上级导航名称
     */
    private String parentName;

    /**
     * 导航元数据
     */

    private String meta;
}