package com.onework.tools.authentication.domain.repository;

import com.onework.tools.authentication.domain.vo.UserVo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月30日 15:23
 */
public interface UserRepository {
    void addUser(UserVo user);
}
