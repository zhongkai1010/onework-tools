package com.onework.tools.modularity.organization.domain.vo;

import com.onework.tools.domain.entity.Entity;
import com.onework.tools.domain.entity.NameCodeValue;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.vo
 * @Description: 描述
 * @date Date : 2022年05月25日 10:53
 */
@Data
public class PostVo implements Entity, NameCodeValue {

    private String uid;
    private String name;
    private String code;
}