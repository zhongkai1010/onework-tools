package onework.sample.mybatisplus.generate.service.impl;

import onework.sample.mybatisplus.generate.entity.Account;
import onework.sample.mybatisplus.generate.mapper.AccountMapper;
import onework.sample.mybatisplus.generate.service.IAccountService;
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
public class AccountServiceImpl extends ServiceImpl<AccountMapper, Account> implements IAccountService {

}
