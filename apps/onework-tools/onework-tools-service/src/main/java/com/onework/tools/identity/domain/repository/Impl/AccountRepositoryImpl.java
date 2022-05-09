package com.onework.tools.identity.domain.repository.Impl;

import com.onework.tools.identity.domain.AccountType;
import com.onework.tools.identity.domain.repository.AccountRepository;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.identity.domain.repository.Impl
 * @Description: 描述
 * @date Date : 2022年05月09日 11:06
 */
@Repository
public class AccountRepositoryImpl implements AccountRepository {

    @Override
    public void insertAccount(String userUid, AccountType type, String account) {

    }
}
