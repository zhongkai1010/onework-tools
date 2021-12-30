package onework.springframework.sample.mapper.impl;

import onework.springframework.sample.common.CacheManager;
import onework.springframework.sample.common.TransactionManager;
import onework.springframework.sample.entity.User;
import onework.springframework.sample.mapper.UserMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

/**
 * @projectName: onework-springframework.sample
 * @package: onework.springframework.sample.mapper.impl
 * @className: UserMapperImpl
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/26 10:08
 * @version: 1.0
 */

public class UserMapperImpl implements UserMapper {

    private final List<User> userStore;

    private final static String cacheKey = "user_list";

    private TransactionManager transactionManager;

    public void setCacheManager(CacheManager cacheManager) {
        this.cacheManager = cacheManager;
    }

    private CacheManager cacheManager;

    public UserMapperImpl(TransactionManager transactionManager) {
        this.userStore = new ArrayList<>();
        this.transactionManager = transactionManager;
    }

    /**
     * 获取所有实体对象
     *
     * @return long
     * @author ZK
     * @description 获取所有实体对象
     * @date 2021/12/28 21:44
     */
    @Override public List<User> getAll() {

        if (cacheManager.exist(cacheKey)) {
            return cacheManager.get(cacheKey);
        }
        cacheManager.set("user_list", userStore);
        return userStore;
    }

    /**
     * 添加
     *
     * @param user :
     * @return T
     * @author ZK
     * @description 添加
     * @date 2021/12/28 21:49
     */
    @Override public User add(User user) {
        try {
            transactionManager.begin();
            userStore.add(user);
            cacheManager.remove(cacheKey);
            System.out.println("添加一条数据：" + user);
            transactionManager.submit();
        } catch (Exception exception) {
            transactionManager.rollback();
            exception.printStackTrace();
        }
        return user;
    }
}
