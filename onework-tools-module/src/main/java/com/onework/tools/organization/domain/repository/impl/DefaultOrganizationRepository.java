package com.onework.tools.organization.domain.repository.impl;

import com.onework.tools.organization.domain.repository.OrganizationRepository;
import com.onework.tools.organization.domain.vo.OrganizationVo;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.organization.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:42
 */
@Repository
public class DefaultOrganizationRepository implements OrganizationRepository {

    @Override
    public OrganizationVo getNotParentOrganization(String name) {
        return null;
    }

    @Override
    public void addOrganization(OrganizationVo organization) {

    }

    @Override
    public OrganizationVo getOrganization(String parentId, String name) {
        return null;
    }

    @Override
    public OrganizationVo getOrganization(String organizationId) {
        return null;
    }

    @Override
    public void updateOrganization(OrganizationVo organization) {

    }

    @Override
    public List<OrganizationVo> getAllChildrenOrganization(String uid) {
        return null;
    }

    @Override
    public void deleteOrganization(String organizationId) {

    }
}
