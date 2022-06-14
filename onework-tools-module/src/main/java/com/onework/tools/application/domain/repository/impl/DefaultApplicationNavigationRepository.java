package com.onework.tools.application.domain.repository.impl;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.application.domain.repository.ApplicationNavigationRepository;
import com.onework.tools.application.domain.vo.ApplicationNavigationVo;
import com.onework.tools.application.entity.ApplicationNavigation;
import com.onework.tools.application.mapper.ApplicationNavigationMapper;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.application.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 15:48
 */
@Repository
public class DefaultApplicationNavigationRepository implements ApplicationNavigationRepository {

    private final ApplicationNavigationMapper applicationNavigationMapper;

    public DefaultApplicationNavigationRepository(ApplicationNavigationMapper applicationNavigationMapper) {
        this.applicationNavigationMapper = applicationNavigationMapper;
    }

    @Override
    public ApplicationNavigationVo findNavigation(String appId, String name) {
        ApplicationNavigation applicationNavigation =
            new LambdaQueryChainWrapper<>(applicationNavigationMapper).eq(ApplicationNavigation::getAppId, appId)
                .eq(ApplicationNavigation::getName, name).last("limit 1").one();
        if (applicationNavigation == null) {
            return null;
        }
        return BeanUtil.copyProperties(applicationNavigation, ApplicationNavigationVo.class);
    }

    @Override
    public void insertNavigation(ApplicationNavigationVo navigation) {
        ApplicationNavigation applicationNavigation = BeanUtil.copyProperties(navigation, ApplicationNavigation.class);
        int count = applicationNavigationMapper.insert(applicationNavigation);
        Check.isTrue(count == 0, new AppException("insert application navigation is error"));
        BeanUtil.copyProperties(applicationNavigation, navigation);
    }

    @Override
    public ApplicationNavigationVo getNavigation(String id) {
        ApplicationNavigation applicationNavigation =
            new LambdaQueryChainWrapper<>(applicationNavigationMapper).eq(ApplicationNavigation::getUid, id)
                .last("limit 1").one();
        Check.notNull(applicationNavigation, new AppException("get application navigation is not find"));
        return BeanUtil.copyProperties(applicationNavigation, ApplicationNavigationVo.class);
    }

    @Override
    public List<ApplicationNavigationVo> getAllChildrenNavigation(String id) {
        String ids = String.format("%s.", id);
        List<ApplicationNavigation> applicationNavigations =
            new LambdaQueryChainWrapper<>(applicationNavigationMapper).like(ApplicationNavigation::getParentIds, ids)
                .list();
        List<ApplicationNavigationVo> vos = new ArrayList<>(applicationNavigations.size());
        applicationNavigations.forEach(item -> {
            ApplicationNavigationVo vo = BeanUtil.copyProperties(item, ApplicationNavigationVo.class);
            vos.add(vo);
        });
        return vos;
    }

    @Override
    public void updatedNavigation(ApplicationNavigationVo navigation) {
        ApplicationNavigation applicationNavigation = BeanUtil.copyProperties(navigation, ApplicationNavigation.class);
        boolean success = new LambdaUpdateChainWrapper<>(applicationNavigationMapper).eq(ApplicationNavigation::getUid,
            navigation.getUid()).update(applicationNavigation);
        Check.isTrue(!success, new AppException("update application navigation is error"));
    }

    @Override
    public void deleteNavigation(String id) {
        boolean success =
            new LambdaUpdateChainWrapper<>(applicationNavigationMapper).eq(ApplicationNavigation::getUid, id).remove();
        Check.isTrue(!success, new AppException("delete application navigation is error"));
    }

    @Override
    public List<ApplicationNavigationVo> getChildrenNavigation(String id) {

        List<ApplicationNavigation> applicationNavigations =
            new LambdaQueryChainWrapper<>(applicationNavigationMapper).eq(ApplicationNavigation::getParentId, id)
                .list();
        List<ApplicationNavigationVo> vos = new ArrayList<>(applicationNavigations.size());
        applicationNavigations.forEach(item -> {
            ApplicationNavigationVo vo = BeanUtil.copyProperties(item, ApplicationNavigationVo.class);
            vos.add(vo);
        });
        return vos;
    }
}
