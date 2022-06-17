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

    /**
     * 添加用户
     *
     * @param user
     */
    void insertUser(UserVo user);

    /**
     * 根据用户名获取用户
     *
     * @param username
     * @return
     */
    UserVo findUserByUserName(String username);

    /**
     * 根据id获取用户
     *
     * @param uid
     * @return
     */
    UserVo getUser(String uid);

    /**
     * 根据username获取用户，排除指定id
     *
     * @param username
     * @param uid
     * @return
     */
    UserVo findUserByUserName(String username, String uid);

    /**
     * 更新用户
     *
     * @param user
     */
    void updateUser(UserVo user);

    /**
     * 删除用户
     *
     * @param user
     */
    void deleteUser(UserVo user);
}
