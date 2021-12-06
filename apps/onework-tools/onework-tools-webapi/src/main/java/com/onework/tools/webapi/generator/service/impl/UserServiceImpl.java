package com.onework.tools.webapi.generator.service.impl;

import com.onework.tools.webapi.generator.entity.User;
import com.onework.tools.webapi.generator.mapper.UserMapper;
import com.onework.tools.webapi.generator.service.IUserService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author 钟凯
 * @since 2021-12-07
 */
@Service
public class UserServiceImpl extends ServiceImpl<UserMapper, User> implements IUserService {

}
