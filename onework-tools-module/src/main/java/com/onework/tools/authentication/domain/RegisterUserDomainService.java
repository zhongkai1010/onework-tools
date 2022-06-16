package com.onework.tools.authentication.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.authentication.domain.vo.UserVo;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain
 * @Description: 描述
 * @date Date : 2022年06月16日 15:32
 */
@Component
public interface RegisterUserDomainService {

    /**
     * 用户名注册
     *
     * @param username
     * @param password
     * @return
     */
    ExecuteResult<UserVo> registerUserName(String username, String password);

    /**
     * 手机注册
     *
     * @param phone
     * @return
     */
    ExecuteResult<UserVo> registerUserPhone(String phone);

    /**
     * 邮箱注册
     *
     * @param email
     * @param password
     * @return
     */
    ExecuteResult<UserVo> registerUserEmail(String email, String password);
}
