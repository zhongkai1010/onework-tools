package com.onework.tools.modularity.organization.domain.impl;

import com.baomidou.mybatisplus.core.toolkit.IdWorker;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.organization.domain.OrganizationDomainService;
import com.onework.tools.modularity.organization.domain.repository.DepartmentRepository;
import com.onework.tools.modularity.organization.domain.repository.OrganizationPersonnelRepository;
import com.onework.tools.modularity.organization.domain.repository.OrganizationRepository;
import com.onework.tools.modularity.organization.domain.repository.PostRepository;
import com.onework.tools.modularity.organization.domain.vo.DepartmentVo;
import com.onework.tools.modularity.organization.domain.vo.OrganizationVo;
import com.onework.tools.modularity.organization.domain.vo.PostVo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Objects;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月26日 17:05
 */
@Service
public class OrganizationDomainServiceImpl implements OrganizationDomainService {

    @Autowired
    private OrganizationRepository organizationRepository;

    @Autowired
    private DepartmentRepository departmentRepository;

    @Autowired
    private PostRepository postRepository;

    @Autowired
    private OrganizationPersonnelRepository organizationPersonnelRepository;

    @Override
    public ExecuteResult<Boolean> addOrganization(OrganizationVo organization) {
        // 判断是否添加根组织
        String parentId = organization.getParentId();
        OrganizationVo dbOrganization;
        if (parentId == null) {
            // 控制同级name不能出现重复
            dbOrganization = organizationRepository.getNotParentOrganization(organization.getName());
            Check.isTrue(dbOrganization != null, new AppException(""));
            organization.setUid(IdWorker.getIdStr());
            organization.setParentIds(organization.getUid());
        } else {
            // 控制同级name不能出现重复
            dbOrganization = organizationRepository.getOrganization(organization.getParentId(), organization.getName());
            Check.isTrue(dbOrganization != null, new AppException(""));
            // 验证上级是否存在
            OrganizationVo parentOrganization = organizationRepository.getOrganization(organization.getParentId());
            Check.notNull(parentOrganization, new AppException(""));
            // 控制固定属性值
            organization.setUid(IdWorker.getIdStr());
            organization.setParentName(parentOrganization.getName());
            String parentIds = String.format("%s.%s", parentOrganization.getParentIds(), organization.getUid());
            organization.setParentIds(parentIds);
        }
        organizationRepository.addOrganization(organization);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> changeOrganization(OrganizationVo organization) {
        // 判断修改对象是否存在
        OrganizationVo dbOrganization = organizationRepository.getOrganization(organization.getUid());
        Check.notNull(dbOrganization, new AppException(""));
        // 判断parentId是否修改
        if (Objects.equals(organization.getParentId(), dbOrganization.getParentId())) {
            // 控制同级name不能出现重复
            dbOrganization = organizationRepository.getOrganization(organization.getParentId(), organization.getName());
            Check.isTrue(dbOrganization != null, new AppException(""));
            organizationRepository.updateOrganization(organization);
        } else {
            String parentId = organization.getParentId();
            String dbParentIds = dbOrganization.getParentIds();
            if (parentId == null) {
                organization.setParentIds(organization.getUid());
            } else {
                // 验证上级是否存在
                OrganizationVo parentOrganization = organizationRepository.getOrganization(organization.getParentId());
                Check.notNull(parentOrganization, new AppException(""));
                String parentIds = String.format("%s.%s", parentOrganization.getParentIds(), organization.getUid());
                organization.setParentIds(parentIds);
            }
            // 处理下级
            List<OrganizationVo> childrenOrganization =
                organizationRepository.getAllChildrenOrganization(organization.getUid());
            childrenOrganization.forEach(organizationVo -> {
                // 替换parentIds
                String parentIds = organization.getParentIds();
                parentIds = parentIds.replaceAll(dbParentIds, organization.getParentIds());
                organizationVo.setParentIds(parentIds);
                organizationRepository.updateOrganization(organizationVo);
            });
            organizationRepository.updateOrganization(organization);
        }
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deleteOrganization(String organizationId) {
        // 判断修改对象是否存在
        OrganizationVo dbOrganization = organizationRepository.getOrganization(organizationId);
        Check.notNull(dbOrganization, new AppException(""));
        // 删除部门
        departmentRepository.deleteDepartmentByOrganization(organizationId);
        // 删除岗位
        postRepository.deletePostByOrganization(organizationId);
        // 删除组织人员
        organizationPersonnelRepository.deletePersonnelByOrganization(organizationId);
        // 删除组织
        organizationRepository.deleteOrganization(organizationId);

        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> addDepartment(DepartmentVo department) {
        // 判断修改对象是否存在
        OrganizationVo dbOrganization = organizationRepository.getOrganization(department.getOrganizationId());
        Check.notNull(dbOrganization, new AppException(""));
        //设置关联属性值
        department.setOrganizationName(dbOrganization.getName());
        //控制同组织下不能出现重复name
        DepartmentVo dbDepartment =
            departmentRepository.getDepartment(department.getOrganizationId(), department.getName());
        Check.isTrue(dbDepartment != null, new AppException(""));
        // 添加部门
        departmentRepository.addDepartment(department);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updateDepartment(DepartmentVo department) {
        // 判断修改对象是否存在
        DepartmentVo dbDepartment = departmentRepository.getDepartment(department.getUid());
        Check.notNull(dbDepartment, new AppException(""));
        // 控制不能修改属性值
        department.setOrganizationId(dbDepartment.getOrganizationId());
        departmentRepository.updateDepartment(department);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deleteDepartment(String departmentId) {
        // 判断修改对象是否存在
        DepartmentVo dbDepartment = departmentRepository.getDepartment(departmentId);
        Check.notNull(dbDepartment, new AppException(""));
        // 判断是否存在部门人员
        long personnelCount = dbDepartment.getPersonnelCount();
        Check.isTrue(personnelCount > 0, new AppException(""));
        //删除部门
        departmentRepository.deleteDepartment(departmentId);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> addPost(PostVo post) {
        // 判断修改对象是否存在
        OrganizationVo dbOrganization = organizationRepository.getOrganization(post.getOrganizationId());
        Check.notNull(dbOrganization, new AppException(""));
        //设置关联属性值
        post.setOrganizationName(dbOrganization.getName());
        //控制同组织下不能出现重复name
        PostVo dbPost = postRepository.getPost(post.getOrganizationId(), post.getName());
        Check.isTrue(dbPost != null, new AppException(""));
        // 添加部门
        postRepository.addPost(post);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updatePost(PostVo post) {
        // 判断修改对象是否存在
        PostVo dbPost = postRepository.getPost(post.getUid());
        Check.notNull(dbPost, new AppException(""));
        // 控制不能修改属性值
        post.setOrganizationId(dbPost.getOrganizationId());
        postRepository.updatePost(post);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deletePost(String postId) {
        // 判断修改对象是否存在
        PostVo dbPost = postRepository.getPost(postId);
        Check.notNull(dbPost, new AppException(""));
        // 判断是否存在岗位人员
        long personnelCount = dbPost.getPersonnelCount();
        Check.isTrue(personnelCount > 0, new AppException(""));
        //删除部门
        postRepository.deletePost(postId);
        return ExecuteResult.success(true);
    }
}
