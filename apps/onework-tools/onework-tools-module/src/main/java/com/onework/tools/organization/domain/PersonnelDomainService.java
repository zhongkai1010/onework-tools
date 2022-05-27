package com.onework.tools.organization.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.organization.domain.vo.PersonnelVo;

import java.util.List;
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
     * 添加组织人员
     *
     * @param organizationId
     * @param personnel
     * @return
     */
    ExecuteResult<Boolean> addOrganizationPersonnel(String organizationId, PersonnelVo personnel);

    /**
     * 添加组织人员
     *
     * @param organizationId
     * @param personnels
     * @return
     */
    ExecuteResult<Boolean> addOrganizationPersonnel(String organizationId, List<PersonnelVo> personnels);

    /**
     * 分配人员部门
     *
     * @param departmentId
     * @param personnel
     * @return
     */
    ExecuteResult<Boolean> assignPersonnelDepartment(PersonnelVo personnel, String departmentId);

    /**
     * 分配人员岗位
     *
     * @param postId
     * @param personnel
     * @return
     */
    ExecuteResult<Boolean> assignPersonnelPost(PersonnelVo personnel, String postId);

    /**
     * 撤销部门
     *
     * @param personnel
     * @param departmentId
     * @return
     */
    ExecuteResult<Boolean> revokePersonnelDepartment(PersonnelVo personnel, String departmentId);

    /**
     * 撤销岗位
     *
     * @param personnel
     * @param postId
     * @return
     */
    ExecuteResult<Boolean> revokePersonnelPost(PersonnelVo personnel, String postId);

    /**
     * 移除组织人员
     *
     * @param personnel
     * @param organizationId
     * @return
     */
    ExecuteResult<Boolean> removePersonnel(PersonnelVo personnel, String organizationId);
}
