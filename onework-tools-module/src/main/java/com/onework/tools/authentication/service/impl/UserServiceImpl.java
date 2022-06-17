package com.onework.tools.authentication.service.impl;

import com.onework.tools.authentication.entity.User;
import com.onework.tools.authentication.mapper.UserMapper;
import com.onework.tools.authentication.service.IUserService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-06-17
 */
@Service
public class UserServiceImpl extends ServiceImpl<UserMapper, User> implements IUserService {

}
