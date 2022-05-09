package com.onework.tools.identity.service.impl;

import com.onework.tools.identity.entity.User;
import com.onework.tools.identity.mapper.UserMapper;
import com.onework.tools.identity.service.IUserService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-05-09
 */
@Service
public class UserServiceImpl extends ServiceImpl<UserMapper, User> implements IUserService {

}
