package com.onework.tools.authentication.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.authentication.domain.vo.RegisterUserVo;
import com.onework.tools.authentication.domain.vo.UserVo;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain
 * @Description: 描述
 * @date Date : 2022年05月27日 17:15
 */
@Component
public interface UserDomainService {

    /**
     * 添加用户
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> addUser(UserVo user);

    /**
     * 修改用户
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> updateUser(UserVo user);

    /**
     * 删除用户
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> deleteUser(UserVo user);

    /**
     * 注册用户
     *
     * @param registerUser
     * @return
     */
    ExecuteResult<UserVo> registerUser(RegisterUserVo registerUser);

    /**
     * 修改用户信息
     *
     * @param user
     * @return
     */
    ExecuteResult<UserVo> updateUserInformation(UserVo user);

    /**
     * 申请找回密码
     *
     * @param userId
     * @return
     */
    ExecuteResult<Boolean> applyRecoverPassword(String userId);

    /**
     * 验证找回密码
     *
     * @param userId
     * @param certificate
     * @return
     */
    ExecuteResult<Boolean> recoverPassword(String userId, String certificate);

    /**
     * 申请验证短信
     *
     * @param userId
     * @return
     */
    ExecuteResult<Boolean> applyVerifySms(String userId);

    /**
     * 验证短信
     *
     * @param userId
     * @param certificate
     * @return
     */
    ExecuteResult<Boolean> verifySms(String userId, String certificate);

    /**
     * 验证短信
     *
     * @param userId
     * @param certificate
     * @return
     */
    ExecuteResult<Boolean> applyVerifyMailbox(String userId, String certificate);

    /**
     * 锁定用户
     *
     * @param userId
     * @param lock
     * @return
     */
    ExecuteResult<Boolean> lockUser(String userId, String lock);
}
