package com.onework.tools.application.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain
 * @Description: 应用信息
 * @date Date : 2022年05月23日 14:32
 */
@Data
public class ApplicationVo implements Entity {

    /**
     * 应用标识
     */
    private String uid;

    /**
     * 应用名称
     */
    private String name;

    /**
     *  应用编码，唯一
     */
    private String code;
}
