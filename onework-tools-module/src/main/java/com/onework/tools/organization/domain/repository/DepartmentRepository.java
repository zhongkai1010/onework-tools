package com.onework.tools.organization.domain.repository;

import com.onework.tools.organization.domain.vo.DepartmentVo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月26日 17:34
 */
public interface DepartmentRepository {
    void deleteDepartmentByOrganization(String organizationId);

    DepartmentVo getDepartment(String organizationId, String name);

    void addDepartment(DepartmentVo department);

    DepartmentVo getDepartment(String uid);

    void updateDepartment(DepartmentVo department);

    void deleteDepartment(String departmentId);

}
