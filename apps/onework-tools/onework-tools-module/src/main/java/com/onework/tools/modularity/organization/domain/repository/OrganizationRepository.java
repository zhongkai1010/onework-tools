package com.onework.tools.modularity.organization.domain.repository;

import com.onework.tools.modularity.organization.domain.vo.OrganizationVo;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月26日 17:09
 */
public interface OrganizationRepository {
    OrganizationVo getNotParentOrganization(String name);

    void addOrganization(OrganizationVo organization);

    OrganizationVo getOrganization(String parentId, String name);

    OrganizationVo getOrganization(String organizationId);

    void updateOrganization(OrganizationVo organization);

    List<OrganizationVo> getAllChildrenOrganization(String uid);

    void deleteOrganization(String organizationId);
}
