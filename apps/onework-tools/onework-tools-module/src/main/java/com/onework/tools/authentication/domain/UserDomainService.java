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
}
