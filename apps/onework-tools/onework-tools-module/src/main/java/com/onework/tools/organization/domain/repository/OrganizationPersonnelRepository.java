package com.onework.tools.organization.domain.repository;

import com.onework.tools.organization.domain.vo.OrganizationPersonnelVo;
import com.onework.tools.organization.domain.vo.PersonnelChangeRecordVo;

import java.util.List;

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

    List<OrganizationPersonnelVo> getOrganizationPersonnel(String organizationId, String personnelId);

    void addOrganizationPersonnel(OrganizationPersonnelVo organizationPersonnel);

    void addPersonnelChangeRecord(PersonnelChangeRecordVo personnelChangeRecord);

    void updateOrganizationPersonnel(OrganizationPersonnelVo organizationPersonnel);

    void deleteOrganizationPersonnel(String uid);
}
