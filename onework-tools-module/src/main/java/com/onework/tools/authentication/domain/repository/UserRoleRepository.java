package com.onework.tools.authentication.domain.repository;

import com.onework.tools.authentication.domain.vo.UserRoleVo;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain.repository
 * @Description: 描述
 * @date Date : 2022年06月17日 10:18
 */
@Component
public interface UserRoleRepository {

    /**
     * 获取用户角色
     *
     * @param userId
     * @return
     */
    List<UserRoleVo> getUserRoles(String userId);

    /**
     * 删除用户角色
     *
     * @param uid
     * @param roleId
     */
    void deleteUserRole(String uid, String roleId);

    /**
     * 添加用户角色
     *
     * @param userRole
     */
    void insertUserRole(UserRoleVo userRole);
}
