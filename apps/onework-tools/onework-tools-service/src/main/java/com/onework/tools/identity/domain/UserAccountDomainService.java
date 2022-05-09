package com.onework.tools.identity.domain;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.identity.domain.vo.User;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.identity
 * @Description: 描述
 * @date Date : 2022年05月09日 9:25
 */
@Component
public interface UserAccountDomainService {

    /**
     * 根据用户名查询用户
     *
     * @param username
     * @return
     */
    ExecuteResult<User> queryUserByName(String username);

    /**
     * 添加用户
     *
     * @param user
     * @return
     */
    ExecuteResult<User> addUser(User user);

    /**
     * 验证用户邮箱
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> verifyEmail(User user);

    /**
     * 验证用户手机
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> verifyPhone(User user);

    /**
     * 验证用户账户
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> verifyAccount(User user);

    /**
     * 禁用用户
     *
     * @param user
     * @return
     */
    ExecuteResult<Boolean> disabledUser(User user);
}
