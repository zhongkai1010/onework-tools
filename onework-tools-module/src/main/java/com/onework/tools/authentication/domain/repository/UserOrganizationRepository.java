package com.onework.tools.authentication.domain.repository;

import com.onework.tools.authentication.domain.vo.UserOrganizationVo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain.repository
 * @Description: 描述
 * @date Date : 2022年06月17日 11:12
 */
public interface UserOrganizationRepository {

    UserOrganizationVo findUserOrganization(String userid);

    void addUserOrganization(UserOrganizationVo dbUserOrganization);
}
