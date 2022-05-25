package com.onework.tools.modularity.application.domain.vo;

import com.onework.tools.domain.entity.Entity;
import com.onework.tools.domain.entity.NameCodeValue;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain
 * @Description: 描述
 * @date Date : 2022年05月23日 15:13
 */
@Data
public class SystemVo implements Entity, NameCodeValue {

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
}
