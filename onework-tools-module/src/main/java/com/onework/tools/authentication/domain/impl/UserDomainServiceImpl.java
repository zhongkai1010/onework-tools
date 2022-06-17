package com.onework.tools.authentication.domain.impl;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.authentication.dependent.OrganizationRemoteService;
import com.onework.tools.authentication.dependent.RoleRemoteService;
import com.onework.tools.authentication.dependent.dto.PersonnelDto;
import com.onework.tools.authentication.dependent.dto.RoleDto;
import com.onework.tools.authentication.domain.UserDomainService;
import com.onework.tools.authentication.domain.repository.UserOrganizationRepository;
import com.onework.tools.authentication.domain.repository.UserRepository;
import com.onework.tools.authentication.domain.repository.UserRoleRepository;
import com.onework.tools.authentication.domain.vo.UserOrganizationVo;
import com.onework.tools.authentication.domain.vo.UserRoleVo;
import com.onework.tools.authentication.domain.vo.UserVo;
import com.onework.tools.domain.event.EntityEventPublisher;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月30日 14:23
 */
@Service
public class UserDomainServiceImpl implements UserDomainService {

    private final UserRepository userRepository;

    private final EntityEventPublisher entityEventPublisher;

    private final RoleRemoteService roleRemoteService;

    private final UserRoleRepository userRoleRepository;

    private final UserOrganizationRepository userOrganizationRepository;

    private final OrganizationRemoteService organizationRemoteService;

    public UserDomainServiceImpl(UserRepository userRepository, EntityEventPublisher entityEventPublisher,
        RoleRemoteService roleRemoteService, UserRoleRepository userRoleRepository,
        UserOrganizationRepository userOrganizationRepository, OrganizationRemoteService organizationRemoteService) {
        this.userRepository = userRepository;
        this.entityEventPublisher = entityEventPublisher;
        this.roleRemoteService = roleRemoteService;
        this.userRoleRepository = userRoleRepository;
        this.userOrganizationRepository = userOrganizationRepository;
        this.organizationRemoteService = organizationRemoteService;
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> addUser(UserVo user) {
        // 验证用户名
        String username = user.getUsername();
        Check.nullString(username, new AppException("add user username is null"));
        UserVo dbUser = userRepository.findUserByUserName(user.getUsername());
        Check.isTrue(dbUser != null,
            new AppException(String.format("add user  username %s is exist", user.getUsername())));
        // 添加用户
        userRepository.insertUser(user);
        Check.notNull(user.getUid(), new AppException("add user account not id"));
        // 发布新增用户事件
        entityEventPublisher.publishAddEntity(user);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updateUser(UserVo user) {
        UserVo dbUser = userRepository.getUser(user.getUid());
        // 验证用户名
        String username = user.getUsername();
        String dbUsername = dbUser.getUsername();
        Check.nullString(username, new AppException("update user username is null"));
        if (!Objects.equals(username, dbUsername)) {
            dbUser = userRepository.findUserByUserName(username, user.getUid());
            Check.isTrue(dbUser != null,
                new AppException(String.format("add user username %s is exist", user.getUsername())));
        }
        //修改用户
        userRepository.updateUser(user);
        // 发布修改用户事件
        entityEventPublisher.publishUpdateEntity(user);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deleteUser(String id) {
        UserVo user = userRepository.getUser(id);
        userRepository.deleteUser(user);
        // 发布删除用户事件
        entityEventPublisher.publishDeleteEntity(user);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> setUserRoles(String userId, List<String> roleIds) {
        UserVo dbUser = userRepository.getUser(userId);
        List<UserRoleVo> dbUserRoles = userRoleRepository.getUserRoles(dbUser.getUid());
        List<String> dbRoleIds = new ArrayList<>();
        // 处理已删除角色
        dbUserRoles.forEach(userRoleVo -> {
            String roleId = userRoleVo.getRoleId();
            boolean isDel = !roleIds.contains(roleId);
            if (isDel) {
                userRoleRepository.deleteUserRole(dbUser.getUid(), roleId);
            }
            dbRoleIds.add(roleId);
        });
        // 处理新增角色
        roleIds.forEach(roleId -> {
            boolean isNew = !dbRoleIds.contains(roleId);
            RoleDto role = roleRemoteService.getRole(roleId);
            UserRoleVo userRoleVo = new UserRoleVo();
            userRoleVo.setUserId(dbUser.getUid());
            userRoleVo.setRoleId(role.getUid());
            userRoleVo.setRoleName(role.getRoleName());
            userRoleRepository.insertUserRole(userRoleVo);
        });
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> setUserOrganization(String userid, String personnelId) {
        UserVo dbUser = userRepository.getUser(userid);
        UserOrganizationVo dbUserOrganization = userOrganizationRepository.findUserOrganization(userid);
        Check.notNull(dbUserOrganization,
            new AppException(String.format("set user organization user id %s exist", dbUser.getUid())));

        PersonnelDto personnel = organizationRemoteService.getPersonnel(personnelId);
        // 添加用户与人员信息关联关系
        dbUserOrganization = new UserOrganizationVo();
        dbUserOrganization.setUserId(userid);
        dbUserOrganization.setPersonnelId(personnel.getUid());
        userOrganizationRepository.addUserOrganization(dbUserOrganization);
        return ExecuteResult.success(true);
    }
}
