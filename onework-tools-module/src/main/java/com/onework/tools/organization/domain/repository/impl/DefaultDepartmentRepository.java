package com.onework.tools.organization.domain.repository.impl;

import com.onework.tools.organization.domain.repository.DepartmentRepository;
import com.onework.tools.organization.domain.vo.DepartmentVo;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.organization.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:42
 */
@Repository
public class DefaultDepartmentRepository implements DepartmentRepository {

    @Override
    public void deleteDepartmentByOrganization(String organizationId) {

    }

    @Override
    public DepartmentVo getDepartment(String organizationId, String name) {
        return null;
    }

    @Override
    public void addDepartment(DepartmentVo department) {

    }

    @Override
    public DepartmentVo getDepartment(String uid) {
        return null;
    }

    @Override
    public void updateDepartment(DepartmentVo department) {

    }

    @Override
    public void deleteDepartment(String departmentId) {

    }
}
