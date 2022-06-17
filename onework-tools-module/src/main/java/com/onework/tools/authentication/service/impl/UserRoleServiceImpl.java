package com.onework.tools.authentication.service.impl;

import com.onework.tools.authentication.entity.UserRole;
import com.onework.tools.authentication.mapper.UserRoleMapper;
import com.onework.tools.authentication.service.IUserRoleService;
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
public class UserRoleServiceImpl extends ServiceImpl<UserRoleMapper, UserRole> implements IUserRoleService {

}
