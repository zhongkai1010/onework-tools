package com.onework.tools.authentication.domain.repository.impl;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.authentication.domain.repository.UserRepository;
import com.onework.tools.authentication.domain.vo.UserVo;
import com.onework.tools.authentication.entity.User;
import com.onework.tools.authentication.mapper.UserMapper;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月17日 14:10
 */
@Repository
public class UserRepositoryImpl implements UserRepository {

    private final UserMapper userMapper;

    public UserRepositoryImpl(UserMapper userMapper) {
        this.userMapper = userMapper;
    }

    @Override
    public void insertUser(UserVo user) {
        User dbUser = BeanUtil.copyProperties(user, User.class);
        int count = userMapper.insert(dbUser);
        Check.isTrue(count == 0, new AppException("insert user no action"));
    }

    @Override
    public UserVo findUserByUserName(String username) {
        User user = new LambdaQueryChainWrapper<>(userMapper).eq(User::getUsername, username).last("limit 1").one();
        if (user == null) {
            return null;
        }
        return BeanUtil.copyProperties(user, UserVo.class);
    }

    @Override
    public UserVo getUser(String uid) {
        User user = new LambdaQueryChainWrapper<>(userMapper).eq(User::getUid, uid).last("limit 1").one();
        Check.notNull(user, new AppException(String.format("get user id %s not find", uid)));
        return BeanUtil.copyProperties(user, UserVo.class);
    }

    @Override
    public UserVo findUserByUserName(String username, String uid) {
        User user = new LambdaQueryChainWrapper<>(userMapper).eq(User::getUsername, username).ne(User::getUid, uid)
            .last("limit 1").one();
        Check.notNull(user, new AppException(String.format("get user id %s not find", uid)));
        return BeanUtil.copyProperties(user, UserVo.class);
    }

    @Override
    public void updateUser(UserVo user) {
        User dbUser = BeanUtil.copyProperties(user, User.class);
        int count = userMapper.updateById(dbUser);
        Check.isTrue(count == 0, new AppException("update user no action"));
    }

    @Override
    public void deleteUser(UserVo user) {
        User dbUser = BeanUtil.copyProperties(user, User.class);
        int count = userMapper.deleteById(dbUser);
        Check.isTrue(count == 0, new AppException("delete user no action"));
    }
}
