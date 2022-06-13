package com.onework.tools.application.domain.repository.impl;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.application.domain.repository.ApplicationRepository;
import com.onework.tools.application.domain.vo.ApplicationVo;
import com.onework.tools.application.entity.Application;
import com.onework.tools.application.mapper.ApplicationMapper;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.application.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 15:55
 */
@Repository
public class DefaultApplicationRepository implements ApplicationRepository {

    private final ApplicationMapper applicationMapper;

    public DefaultApplicationRepository(ApplicationMapper applicationMapper) {
        this.applicationMapper = applicationMapper;
    }

    @Override
    public ApplicationVo findApplicationByCode(String code) {
        Application application =
            new LambdaQueryChainWrapper<>(applicationMapper).eq(Application::getCode, code).last("limit 1").one();
        if (application == null) {
            return null;
        }
        return BeanUtil.copyProperties(application, ApplicationVo.class);
    }

    @Override
    public void insertApplication(ApplicationVo application) {
        Application newApplication = BeanUtil.copyProperties(application, Application.class);
        int count = applicationMapper.insert(newApplication);
        Check.isTrue(count == 0, new AppException("insert application is error"));
        // 操作数据赋值参数上，便于后续操作
        BeanUtil.copyProperties(newApplication, application);
    }

    @Override
    public ApplicationVo getApplication(String uid) {
        Application application =
            new LambdaQueryChainWrapper<>(applicationMapper).eq(Application::getUid, uid).last("limit 1").one();
        Check.notNull(application, new AppException(String.format("get application id is %s not find", uid)));
        return BeanUtil.copyProperties(application, ApplicationVo.class);
    }

    @Override
    public void updateApplication(ApplicationVo application) {
        Application newApplication = BeanUtil.copyProperties(application, Application.class);
        applicationMapper.updateById(newApplication);
        // 操作数据赋值参数上，便于后续操作
        BeanUtil.copyProperties(newApplication, application);
    }

    @Override
    public void deleteApplication(ApplicationVo application) {
        LambdaQueryWrapper<Application> lambdaQueryWrapper =
            new LambdaQueryWrapper<Application>().eq(Application::getUid, application.getUid());
        applicationMapper.delete(lambdaQueryWrapper);
    }
}
