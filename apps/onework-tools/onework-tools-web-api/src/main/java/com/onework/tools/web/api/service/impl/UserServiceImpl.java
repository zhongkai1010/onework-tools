package com.onework.tools.web.api.service.impl;

import com.onework.tools.web.api.entity.User;
import com.onework.tools.web.api.mapper.UserMapper;
import com.onework.tools.web.api.service.IUserService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author 钟凯
 * @since 2022-03-23
 */
@Service
public class UserServiceImpl extends ServiceImpl<UserMapper, User> implements IUserService {

}
