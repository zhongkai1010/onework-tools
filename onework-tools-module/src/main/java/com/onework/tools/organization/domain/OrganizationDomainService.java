package com.onework.tools.organization.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.organization.domain.vo.DepartmentVo;
import com.onework.tools.organization.domain.vo.OrganizationVo;
import com.onework.tools.organization.domain.vo.PostVo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月25日 11:02
 */
public interface OrganizationDomainService {

    /**
     * 添加组织
     *
     * @param organization
     * @return
     */
    ExecuteResult<Boolean> addOrganization(OrganizationVo organization);

    /**
     * 组织变更
     *
     * @param organization
     * @return
     */
    ExecuteResult<Boolean> changeOrganization(OrganizationVo organization);

    /**
     * 删除组织
     *
     * @param organizationId
     * @return
     */
    ExecuteResult<Boolean> deleteOrganization(String organizationId);

    /**
     * 添加部门
     *
     * @param department
     * @return
     */
    ExecuteResult<Boolean> addDepartment(DepartmentVo department);

    /**
     * 修改部门
     *
     * @param department
     * @return
     */
    ExecuteResult<Boolean> updateDepartment(DepartmentVo department);

    /**
     * 删除部门
     *
     * @param departmentId
     * @return
     */
    ExecuteResult<Boolean> deleteDepartment(String departmentId);

    /**
     * 添加岗位
     *
     * @param post
     * @return
     */
    ExecuteResult<Boolean> addPost(PostVo post);

    /**
     * 修改岗位
     *
     * @param post
     * @return
     */
    ExecuteResult<Boolean> updatePost(PostVo post);

    /**
     * 删除岗位
     *
     * @param postId
     * @return
     */
    ExecuteResult<Boolean> deletePost(String postId);
}
