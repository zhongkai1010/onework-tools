package com.onework.tools.identity.domain.repository.Impl;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.identity.domain.repository.UserRepository;
import com.onework.tools.identity.domain.vo.User;
import com.onework.tools.identity.mapper.UserMapper;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.identity.domain.repository.lmpl
 * @Description: 描述
 * @date Date : 2022年05月09日 10:54
 */
@Repository
public class UserRepositoryImpl implements UserRepository {

    private UserMapper userMapper;

    public UserRepositoryImpl(UserMapper userMapper) {
        this.userMapper = userMapper;
    }

    @Override
    public User query(String username) {

        LambdaQueryChainWrapper<com.onework.tools.identity.entity.User> user =
            new LambdaQueryChainWrapper<>(userMapper).eq(com.onework.tools.identity.entity.User::getUsername, username);
        return BeanUtil.copyProperties(user,User.class);

    }

    @Override
    public void insertUser(User user) {

    }

    @Override
    public void updateUser(User user) {

    }
}
