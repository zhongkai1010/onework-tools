package com.onework.tools.modularity.organization.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.organization.domain.vo.OrganizationPersonnelVo;
import com.onework.tools.modularity.organization.domain.vo.PersonnelVo;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain
 * @Description: 描述
 * @date Date : 2022年05月26日 16:39
 */
public interface PersonnelDomainService {

    /**
     * 添加人员
     *
     * @param personnel
     * @param extData
     * @return
     */
    ExecuteResult<Boolean> addPersonnel(PersonnelVo personnel, Map<String, String> extData);

    /**
     * 更新人员信息
     *
     * @param personnel
     * @return
     */
    ExecuteResult<Boolean> updatePersonnel(PersonnelVo personnel);

    /**
     * 更新人员扩展信息
     *
     * @param personnelId
     * @param extKey
     * @param extValue
     * @return
     */
    ExecuteResult<Boolean> updatePersonnel(String personnelId, String extKey, String extValue);

    /**
     * 更新人员扩展信息
     *
     * @param personnelId
     * @param extData
     * @return
     */
    ExecuteResult<Boolean> updatePersonnel(String personnelId, Map<String, String> extData);

    /**
     * 设置人员组织关系
     *
     * @param organizationPersonnel
     * @return
     */
    ExecuteResult<Boolean> setOrganizationPersonnel(OrganizationPersonnelVo organizationPersonnel);

    /**
     * 变更人员组织关系
     *
     * @param organizationPersonnel
     * @return
     */
    ExecuteResult<Boolean> changeOrganizationPersonnel(OrganizationPersonnelVo organizationPersonnel);

    /**
     * 移除人员组织关系
     *
     * @param organizationPersonnelId
     * @return
     */
    ExecuteResult<Boolean> removeOrganizationPersonnel(String organizationPersonnelId);
}
