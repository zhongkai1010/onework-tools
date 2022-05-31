package com.onework.tools.organization.domain.impl;

import cn.hutool.core.collection.ListUtil;
import cn.hutool.core.util.ReflectUtil;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.organization.domain.PersonnelDomainService;
import com.onework.tools.organization.domain.repository.*;
import com.onework.tools.organization.domain.vo.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.lang.reflect.Field;
import java.util.Comparator;
import java.util.List;
import java.util.Map;
import java.util.Objects;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月26日 18:01
 */
@Service
public class PersonnelDomainServiceImpl implements PersonnelDomainService {

    @Autowired
    private PersonnelRepository personnelRepository;

    @Autowired
    private OrganizationRepository organizationRepository;

    @Autowired
    private DepartmentRepository departmentRepository;

    @Autowired
    private OrganizationPersonnelRepository organizationPersonnelRepository;

    @Autowired
    private PostRepository postRepository;

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> addPersonnel(PersonnelVo personnel, Map<String, String> extData) {
        // 添加人员
        personnelRepository.addPersonnel(personnel);
        // 添加人员属性
        extData.forEach((k, v) -> personnelRepository.addPersonnelProperty(personnel.getUid(), k, v));
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> updatePersonnel(PersonnelVo personnel) {
        // 验证操作对象是否存在
        PersonnelVo dbPersonnel = personnelRepository.getPersonnel(personnel.getUid());
        Check.notNull(dbPersonnel, new AppException(""));
        // 记录字段变更
        Field[] fields = ReflectUtil.getFieldsDirectly(PersonnelVo.class, true);
        for (Field field : fields) {
            Object newValue = ReflectUtil.getFieldValue(personnel, field.getName());
            Object oldValue = ReflectUtil.getFieldValue(dbPersonnel, field.getName());
            if (!newValue.equals(oldValue)) {
                PersonnelPropertyChangeRecordVo changeRecord = new PersonnelPropertyChangeRecordVo();
                changeRecord.setPersonnelId(personnel.getUid());
                changeRecord.setProperty(field.getName());
                changeRecord.setOldValue(oldValue.toString());
                changeRecord.setNewValue(newValue.toString());
                personnelRepository.addPropertyChangeRecord(changeRecord);
            }
        }
        // 修改人员
        personnelRepository.updatePersonnel(personnel);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> updatePersonnel(String personnelId, String extKey, String extValue) {
        // 验证操作对象是否存在
        PersonnelVo dbPersonnel = personnelRepository.getPersonnel(personnelId);
        Check.notNull(dbPersonnel, new AppException(""));
        // 验证属性是否存在
        Map<String, String> properties = personnelRepository.getPersonnelProperties(personnelId);
        Check.isTrue(!properties.containsValue(extKey), new AppException(""));
        String oldValue = properties.get(extKey);
        // 更新属性
        personnelRepository.updatePersonnelProperty(personnelId, extKey, extValue);
        // 记录字段变更
        PersonnelPropertyChangeRecordVo changeRecord = new PersonnelPropertyChangeRecordVo();
        changeRecord.setPersonnelId(personnelId);
        changeRecord.setProperty(extKey);
        changeRecord.setOldValue(oldValue);
        changeRecord.setNewValue(extValue);
        personnelRepository.addPropertyChangeRecord(changeRecord);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> updatePersonnel(String personnelId, Map<String, String> extData) {
        // 验证操作对象是否存在
        PersonnelVo dbPersonnel = personnelRepository.getPersonnel(personnelId);
        Check.notNull(dbPersonnel, new AppException(""));
        // 比较属性,有则修改，反之新增
        Map<String, String> properties = personnelRepository.getPersonnelProperties(personnelId);
        extData.forEach((k, v) -> {
            if (properties.containsKey(k)) {
                personnelRepository.updatePersonnelProperty(personnelId, k, v);
                String oldValue = properties.get(k);
                String newValue = extData.get(k);
                if (!newValue.equals(oldValue)) {
                    // 记录字段变更
                    PersonnelPropertyChangeRecordVo changeRecord = new PersonnelPropertyChangeRecordVo();
                    changeRecord.setPersonnelId(personnelId);
                    changeRecord.setProperty(k);
                    changeRecord.setOldValue(oldValue);
                    changeRecord.setNewValue(newValue);
                    personnelRepository.addPropertyChangeRecord(changeRecord);
                }
            } else {
                personnelRepository.addPersonnelProperty(personnelId, k, v);
            }

        });
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> addOrganizationPersonnel(String organizationId, PersonnelVo personnel) {
        OrganizationVo organization = organizationRepository.getOrganization(organizationId);
        Check.notNull(organization, new AppException(""));
        // 验证人员是否已在组织,不在则添加
        List<OrganizationPersonnelVo> organizationPersonnels =
            organizationPersonnelRepository.getOrganizationPersonnel(organizationId, personnel.getUid());
        if (organizationPersonnels.size() == 0) {
            OrganizationPersonnelVo organizationPersonnel = new OrganizationPersonnelVo();
            organizationPersonnel.setOrganizationId(organization.getUid());
            organizationPersonnel.setOrganizationName(organization.getName());
            organizationPersonnel.setPersonnelId(personnel.getUid());
            organizationPersonnel.setPersonnelName(personnel.getName());
            organizationPersonnel.setPriority(100);
            organizationPersonnelRepository.addOrganizationPersonnel(organizationPersonnel);
            // 添加记录
            PersonnelChangeRecordVo personnelChangeRecord = new PersonnelChangeRecordVo();
            personnelChangeRecord.setPersonnelId(personnel.getUid());
            personnelChangeRecord.setType(PersonnelChangeType.ORGANIZATION);
            personnelChangeRecord.setNewValue(organization.getName());
            organizationPersonnelRepository.addPersonnelChangeRecord(personnelChangeRecord);
        }
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> addOrganizationPersonnel(String organizationId, List<PersonnelVo> personnels) {
        ExecuteResult<Boolean> executeResult = ExecuteResult.failure();
        for (PersonnelVo personnel : personnels) {
            executeResult = addOrganizationPersonnel(organizationId, personnel);
            if (executeResult.compare(ExecuteResult.FAIL)) {
                return executeResult;
            }
        }
        return executeResult;
    }

    @Override
    public ExecuteResult<Boolean> assignPersonnelDepartment(PersonnelVo personnel, String departmentId) {
        // 验证操作对象是否存在
        DepartmentVo departmentVo = departmentRepository.getDepartment(departmentId);
        Check.notNull(departmentVo, new AppException(""));
        // 验证人员组织
        List<OrganizationPersonnelVo> organizationPersonnels =
            organizationPersonnelRepository.getOrganizationPersonnel(departmentVo.getOrganizationId(),
                personnel.getUid());

        if (organizationPersonnels.size() > 0) {
            // 该人员已在部门中
            organizationPersonnels = ListUtil.filter(organizationPersonnels, organizationPersonnelVo -> {
                if (Objects.equals(organizationPersonnelVo.getDepartmentId(), departmentId)) {
                    return organizationPersonnelVo;
                }
                return null;
            });
            Check.isTrue(organizationPersonnels.size() > 0, new AppException(""));
            // 原有记录上赋值部门
            OrganizationPersonnelVo maxVo = organizationPersonnels.get(0);
            maxVo = organizationPersonnels.stream().max(Comparator.comparing(OrganizationPersonnelVo::getPriority))
                .orElse(maxVo);
            maxVo.setDepartmentId(departmentVo.getUid());
            maxVo.setDepartmentName(departmentVo.getName());
            organizationPersonnelRepository.updateOrganizationPersonnel(maxVo);
        } else {
            OrganizationPersonnelVo organizationPersonnel = new OrganizationPersonnelVo();
            organizationPersonnel.setOrganizationId(departmentVo.getOrganizationId());
            organizationPersonnel.setOrganizationName(departmentVo.getOrganizationName());
            organizationPersonnel.setPersonnelId(personnel.getUid());
            organizationPersonnel.setPersonnelName(personnel.getName());
            organizationPersonnel.setDepartmentId(departmentVo.getUid());
            organizationPersonnel.setDepartmentName(departmentVo.getName());
            organizationPersonnelRepository.addOrganizationPersonnel(organizationPersonnel);
        }

        // 添加记录
        PersonnelChangeRecordVo personnelChangeRecord = new PersonnelChangeRecordVo();
        personnelChangeRecord.setPersonnelId(personnel.getUid());
        personnelChangeRecord.setType(PersonnelChangeType.DEPARTMENT);
        personnelChangeRecord.setNewValue(departmentVo.getName());
        organizationPersonnelRepository.addPersonnelChangeRecord(personnelChangeRecord);

        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> assignPersonnelPost(PersonnelVo personnel, String postId) {
        // 验证操作对象是否存在
        PostVo post = postRepository.getPost(postId);
        Check.notNull(post, new AppException(""));
        // 验证人员组织
        List<OrganizationPersonnelVo> organizationPersonnels =
            organizationPersonnelRepository.getOrganizationPersonnel(post.getOrganizationId(), personnel.getUid());
        if (organizationPersonnels.size() > 0) {
            // 该人员已在部门中
            organizationPersonnels = ListUtil.filter(organizationPersonnels, organizationPersonnelVo -> {
                if (Objects.equals(organizationPersonnelVo.getPostId(), post.getUid())) {
                    return organizationPersonnelVo;
                }
                return null;
            });
            Check.isTrue(organizationPersonnels.size() > 0, new AppException(""));
            // 原有记录上赋值岗位
            OrganizationPersonnelVo maxVo = organizationPersonnels.get(0);
            maxVo = organizationPersonnels.stream().max(Comparator.comparing(OrganizationPersonnelVo::getPriority))
                .orElse(maxVo);
            maxVo.setPostId(post.getUid());
            maxVo.setPostName(post.getName());
            organizationPersonnelRepository.updateOrganizationPersonnel(maxVo);
        } else {
            OrganizationPersonnelVo organizationPersonnel = new OrganizationPersonnelVo();
            organizationPersonnel.setOrganizationId(post.getOrganizationId());
            organizationPersonnel.setOrganizationName(post.getOrganizationName());
            organizationPersonnel.setPostId(post.getUid());
            organizationPersonnel.setPostName(post.getName());
            organizationPersonnel.setPersonnelId(personnel.getUid());
            organizationPersonnel.setPersonnelName(personnel.getName());
            organizationPersonnelRepository.addOrganizationPersonnel(organizationPersonnel);
        }
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> revokePersonnelDepartment(PersonnelVo personnel, String departmentId) {
        // 验证操作对象是否存在
        DepartmentVo departmentVo = departmentRepository.getDepartment(departmentId);
        Check.notNull(departmentVo, new AppException(""));
        // 验证人员组织
        List<OrganizationPersonnelVo> organizationPersonnels =
            organizationPersonnelRepository.getOrganizationPersonnel(departmentVo.getOrganizationId(),
                personnel.getUid());
        //筛选出部门数据
        organizationPersonnels = ListUtil.filter(organizationPersonnels, organizationPersonnelVo -> {
            if (Objects.equals(organizationPersonnelVo.getDepartmentId(), departmentVo.getUid())) {
                return organizationPersonnelVo;
            }
            return null;
        });
        // 删除部门数据
        organizationPersonnels.forEach(
            organizationPersonnelVo -> organizationPersonnelRepository.deleteOrganizationPersonnel(
                organizationPersonnelVo.getUid()));
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> revokePersonnelPost(PersonnelVo personnel, String postId) {
        // 验证操作对象是否存在
        PostVo post = postRepository.getPost(postId);
        Check.notNull(post, new AppException(""));
        // 验证人员组织
        List<OrganizationPersonnelVo> organizationPersonnels =
            organizationPersonnelRepository.getOrganizationPersonnel(post.getOrganizationId(), personnel.getUid());
        //筛选出岗位数据
        organizationPersonnels = ListUtil.filter(organizationPersonnels, organizationPersonnelVo -> {
            if (Objects.equals(organizationPersonnelVo.getPostId(), post.getUid())) {
                return organizationPersonnelVo;
            }
            return null;
        });
        // 删除部门岗位
        organizationPersonnels.forEach(
            organizationPersonnelVo -> organizationPersonnelRepository.deleteOrganizationPersonnel(
                organizationPersonnelVo.getUid()));
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> removePersonnel(PersonnelVo personnel, String organizationId) {
        OrganizationVo organization = organizationRepository.getOrganization(organizationId);
        Check.notNull(organization, new AppException(""));
        // 验证人员组织
        List<OrganizationPersonnelVo> organizationPersonnels =
            organizationPersonnelRepository.getOrganizationPersonnel(organization.getUid(), personnel.getUid());
        // 删除部门岗位
        organizationPersonnels.forEach(
            organizationPersonnelVo -> organizationPersonnelRepository.deleteOrganizationPersonnel(
                organizationPersonnelVo.getUid()));
        return ExecuteResult.success(true);
    }
}
