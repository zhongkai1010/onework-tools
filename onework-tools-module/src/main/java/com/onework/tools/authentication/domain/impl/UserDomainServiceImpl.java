package com.onework.tools.authentication.domain.impl;

import com.onework.tools.ExecuteResult;
import com.onework.tools.authentication.domain.UserDomainService;
import com.onework.tools.authentication.domain.repository.UserRepository;
import com.onework.tools.authentication.domain.vo.UserVo;
import org.springframework.stereotype.Service;

import java.util.List;

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

    public UserDomainServiceImpl(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Override
    public ExecuteResult<Boolean> addUser(UserVo user) {

        return null;
    }

    @Override
    public ExecuteResult<Boolean> updateUser(UserVo user) {

        return null;
    }

    @Override
    public ExecuteResult<Boolean> deleteUser(UserVo user) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> setUserRoles(String userId, List<String> roleIds) {

        return null;
    }

    @Override
    public ExecuteResult<Boolean> setUserOrganization(String userid, String organizationId, String personnelId) {
        return null;
    }
}
