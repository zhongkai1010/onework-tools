package com.onework.tools.modularity.organization.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月26日 16:27
 */
@Data
public class OrganizationPersonnelVo implements Entity {

    private String uid;
    private String personnelId;
    private String personnelName;
    private String departmentId;
    private String departmentName;
    private String postId;
    private String postName;
}
