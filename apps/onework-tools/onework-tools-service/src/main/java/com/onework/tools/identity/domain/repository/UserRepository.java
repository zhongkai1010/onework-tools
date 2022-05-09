package com.onework.tools.identity.domain.repository;


import com.onework.tools.identity.domain.vo.User;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.identity.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月09日 9:40
 */
@Repository
public interface UserRepository {

    /**
     * 根据用户名查询用户
     *
     * @param username
     * @return
     */
    User query(String username);

    /**
     * 插入用户
     *
     * @param user
     */
    void insertUser(User user);

    /**
     * 修改用户
     *
     * @param user
     */
    void updateUser(User user);
}
