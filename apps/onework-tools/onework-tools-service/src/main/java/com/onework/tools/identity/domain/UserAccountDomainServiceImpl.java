package com.onework.tools.identity.domain;

import com.onework.tools.core.Check;
import com.onework.tools.core.ExecuteResult;
import com.onework.tools.core.error.AppException;
import com.onework.tools.identity.IdentityException;
import com.onework.tools.identity.domain.repository.AccountRepository;
import com.onework.tools.identity.domain.repository.UserRepository;

import com.onework.tools.identity.domain.vo.User;
import org.jetbrains.annotations.NotNull;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.context.ApplicationEventPublisherAware;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.identity.domain
 * @Description: 描述
 * @date Date : 2022年05月09日 9:39
 */
@Service
public class UserAccountDomainServiceImpl implements UserAccountDomainService, ApplicationEventPublisherAware {

    private final UserRepository userRepository;

    private final AccountRepository accountRepository;

    private ApplicationEventPublisher applicationEventPublisher;

    public UserAccountDomainServiceImpl(UserRepository userRepository, AccountRepository accountRepository,
        ApplicationEventPublisher applicationEventPublisher) {
        this.userRepository = userRepository;
        this.accountRepository = accountRepository;
        this.applicationEventPublisher = applicationEventPublisher;
    }

    @Override
    public ExecuteResult<User> queryUserByName(String username) {
        return null;
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<User> addUser(User user) {

        User dbUser = userRepository.query(user.getUsername());
        Check.isTrue(dbUser != null, new AppException(IdentityException.QUERY_USER_EXIST, user.getUsername()));

        // 默认未激活未启用状态
        user.setActiveState(false);
        user.setEnableState(false);

        userRepository.insertUser(user);
        accountRepository.insertAccount(user.getUid(), AccountType.USER_NAME, user.getUsername());

        applicationEventPublisher.publishEvent(new UserAccountApplicationEvent(user));

        return ExecuteResult.success(user);
    }

    @Override
    public ExecuteResult<Boolean> verifyEmail(User user) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> verifyPhone(User user) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> verifyAccount(User user) {
        return null;
    }

    @Override
    public ExecuteResult<Boolean> disabledUser(User user) {
        return null;
    }

    @Override
    public void setApplicationEventPublisher(@NotNull ApplicationEventPublisher applicationEventPublisher) {
        this.applicationEventPublisher = applicationEventPublisher;
    }
}
