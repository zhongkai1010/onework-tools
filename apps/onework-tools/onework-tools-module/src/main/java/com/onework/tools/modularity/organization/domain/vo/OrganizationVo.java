package com.onework.tools.modularity.organization.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.vo
 * @Description: 描述
 * @date Date : 2022年05月25日 10:50
 */
@Data
public class OrganizationVo implements Entity {

    private String uid;
    private String name;
    private String parentId;
    private String parentName;
    private String parentIds;
    private long personnelCount;
}
