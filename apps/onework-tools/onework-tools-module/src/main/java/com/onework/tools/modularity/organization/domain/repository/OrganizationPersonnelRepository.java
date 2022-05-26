package com.onework.tools.modularity.organization.domain.repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月26日 17:37
 */
public interface OrganizationPersonnelRepository {
    void deletePersonnelByOrganization(String organizationId);
}
