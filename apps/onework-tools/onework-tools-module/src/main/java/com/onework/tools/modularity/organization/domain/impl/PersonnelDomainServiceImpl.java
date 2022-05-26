package com.onework.tools.modularity.organization.domain.impl;

import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.organization.domain.PersonnelDomainService;
import com.onework.tools.modularity.organization.domain.vo.OrganizationPersonnelVo;
import com.onework.tools.modularity.organization.domain.vo.PersonnelVo;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月26日 18:01
 */
public class PersonnelDomainServiceImpl implements PersonnelDomainService {

    @Override
    public ExecuteResult<Boolean> addPersonnel(PersonnelVo personnel, Map<String, String> extData) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> updatePersonnel(PersonnelVo personnel) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> updatePersonnel(String personnelId, String extKey, String extValue) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> updatePersonnel(String personnelId, Map<String, String> extData) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> setOrganizationPersonnel(OrganizationPersonnelVo organizationPersonnel) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> changeOrganizationPersonnel(OrganizationPersonnelVo organizationPersonnel) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> removeOrganizationPersonnel(String organizationPersonnelId) {
        return null;
    }
}
