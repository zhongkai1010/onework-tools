package com.onework.tools.identity.service.impl;

import com.onework.tools.identity.entity.UserAccount;
import com.onework.tools.identity.mapper.UserAccountMapper;
import com.onework.tools.identity.service.IUserAccountService;
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
public class UserAccountServiceImpl extends ServiceImpl<UserAccountMapper, UserAccount> implements IUserAccountService {

}
