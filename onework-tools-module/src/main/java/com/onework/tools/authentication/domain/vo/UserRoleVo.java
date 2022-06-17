package com.onework.tools.authentication.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain.vo
 * @Description: 描述
 * @date Date : 2022年06月16日 16:07
 */
@Data
public class UserRoleVo implements Entity {

    /**
     * id
     */
    private String uid;

    /**
     * 用户id
     */
    private String userId;

    /**
     * 角色id
     */
    private String roleId;

    /**
     * 角色名称
     */
    private String roleName;
}
