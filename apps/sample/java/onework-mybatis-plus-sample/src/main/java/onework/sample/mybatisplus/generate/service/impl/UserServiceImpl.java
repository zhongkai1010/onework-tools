package onework.sample.mybatisplus.generate.service.impl;

import onework.sample.mybatisplus.generate.entity.User;
import onework.sample.mybatisplus.generate.mapper.UserMapper;
import onework.sample.mybatisplus.generate.service.IUserService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2021-12-23
 */
@Service
public class UserServiceImpl extends ServiceImpl<UserMapper, User> implements IUserService {

}
