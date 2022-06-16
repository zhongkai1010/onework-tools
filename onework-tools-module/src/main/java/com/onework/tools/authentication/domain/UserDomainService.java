package com.onework.tools.authentication.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.authentication.domain.vo.UserVo;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain
 * @Description: 描述
 * @date Date : 2022年05月27日 17:15
 */
@Component
public interface UserDomainService {

    /**
     * 添加用户
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> addUser(UserVo user);

    /**
     * 修改用户
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> updateUser(UserVo user);

    /**
     * 删除用户
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> deleteUser(UserVo user);

    /**
     * 设置用户角色
     *
     * @param userId
     * @param roleIds
     * @return
     */
    ExecuteResult<Boolean> setUserRoles(String userId, List<String> roleIds);

    /**
     * 设置用户组织
     *
     * @param userid
     * @param organizationId
     * @param personnelId
     * @return
     */
    ExecuteResult<Boolean> setUserOrganization(String userid, String organizationId, String personnelId);
}
