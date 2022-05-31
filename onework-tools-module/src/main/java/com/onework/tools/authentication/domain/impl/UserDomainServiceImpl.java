package com.onework.tools.authentication.domain.impl;

import com.onework.tools.ExecuteResult;
import com.onework.tools.authentication.domain.UserDomainService;
import com.onework.tools.authentication.domain.repository.UserRepository;
import com.onework.tools.authentication.domain.vo.RegisterUserVo;
import com.onework.tools.authentication.domain.vo.UserVo;
import org.springframework.beans.factory.annotation.Autowired;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月30日 14:23
 */
public class UserDomainServiceImpl implements UserDomainService {

    @Autowired
    private UserRepository userRepository;

    @Override
    public ExecuteResult<Boolean> addUser(UserVo user) {
        userRepository.addUser(user);
        return ExecuteResult.success();
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
    public ExecuteResult<UserVo> registerUser(RegisterUserVo registerUser) {
        return null;
    }

    @Override
    public ExecuteResult<UserVo> updateUserInformation(UserVo user) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> applyRecoverPassword(String userId) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> recoverPassword(String userId, String certificate) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> applyVerifySms(String userId) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> verifySms(String userId, String certificate) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> applyVerifyMailbox(String userId, String certificate) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> lockUser(String userId, String lock) {
        return null;
    }
}
