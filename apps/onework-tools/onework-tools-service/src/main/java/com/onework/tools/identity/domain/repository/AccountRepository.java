package com.onework.tools.identity.domain.repository;

import com.onework.tools.identity.domain.AccountType;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.identity.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月09日 9:41
 */
@Repository
public interface AccountRepository {

    /**
     * 添加用户账户
     *
     * @param userUid
     * @param type
     * @param account
     */
    void insertAccount(String userUid, AccountType type, String account);
}
