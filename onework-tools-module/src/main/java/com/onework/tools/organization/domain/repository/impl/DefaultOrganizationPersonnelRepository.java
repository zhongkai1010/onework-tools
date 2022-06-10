package com.onework.tools.organization.domain.repository.impl;

import com.onework.tools.organization.domain.repository.OrganizationPersonnelRepository;
import com.onework.tools.organization.domain.vo.OrganizationPersonnelVo;
import com.onework.tools.organization.domain.vo.PersonnelChangeRecordVo;
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
public class DefaultOrganizationPersonnelRepository implements OrganizationPersonnelRepository {

    @Override
    public void deletePersonnelByOrganization(String organizationId) {

    }

    @Override
    public List<OrganizationPersonnelVo> getOrganizationPersonnel(String organizationId, String personnelId) {
        return null;
    }

    @Override
    public void addOrganizationPersonnel(OrganizationPersonnelVo organizationPersonnel) {

    }

    @Override
    public void addPersonnelChangeRecord(PersonnelChangeRecordVo personnelChangeRecord) {

    }

    @Override
    public void updateOrganizationPersonnel(OrganizationPersonnelVo organizationPersonnel) {

    }

    @Override
    public void deleteOrganizationPersonnel(String uid) {

    }
}
