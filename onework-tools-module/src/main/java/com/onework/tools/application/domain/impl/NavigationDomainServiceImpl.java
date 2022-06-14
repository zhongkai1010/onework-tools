package com.onework.tools.application.domain.impl;

import com.baomidou.mybatisplus.core.toolkit.IdWorker;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.NavigationDomainService;
import com.onework.tools.application.domain.repository.ApplicationNavigationRepository;
import com.onework.tools.application.domain.repository.ApplicationRepository;
import com.onework.tools.application.domain.vo.ApplicationNavigationVo;
import com.onework.tools.application.domain.vo.ApplicationVo;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Objects;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.application.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月25日 14:04
 */
@Service
public class NavigationDomainServiceImpl implements NavigationDomainService {

    private final ApplicationNavigationRepository applicationNavigationRepository;

    private final ApplicationRepository applicationRepository;

    public NavigationDomainServiceImpl(ApplicationNavigationRepository systemNavigationRepository,
        ApplicationRepository applicationRepository) {
        this.applicationNavigationRepository = systemNavigationRepository;
        this.applicationRepository = applicationRepository;
    }

    @Override
    public ExecuteResult<Boolean> addRootNavigation(String appId, ApplicationNavigationVo navigation) {
        // 获取应用，验证参数是否正确
        ApplicationVo application = applicationRepository.getApplication(appId);
        // 验证同应用导航name是否重复
        Check.notNull(navigation.getName(), new AppException("add navigation name is null"));
        ApplicationNavigationVo dbNavigation =
            applicationNavigationRepository.findNavigation(application.getUid(), navigation.getName());
        Check.isTrue(dbNavigation != null, new AppException(
            String.format("add root navigation appid:%s name:%s is exist", appId, navigation.getName())));
        // 控制默认值
        navigation.setUid(IdWorker.getIdStr());
        navigation.setAppId(appId);
        navigation.setAppName(application.getName());
        navigation.setParentId("");
        navigation.setParentName("");
        // 上级路径，根目录存id
        navigation.setParentIds(navigation.getUid());
        applicationNavigationRepository.insertNavigation(navigation);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> addChildNavigation(String parentId, ApplicationNavigationVo navigation) {
        // 获取上级导航，验证参数是否正确
        ApplicationNavigationVo parentNavigation = applicationNavigationRepository.getNavigation(parentId);
        String appId = parentNavigation.getAppId();
        // 验证同应用导航name是否重复
        Check.notNull(navigation.getName(), new AppException("add navigation name is null"));
        ApplicationNavigationVo dbNavigation =
            applicationNavigationRepository.findNavigation(appId, navigation.getName());
        Check.isTrue(dbNavigation != null, new AppException(
            String.format("add child navigation appid:%s name:%s is exist", appId, navigation.getName())));
        // 控制默认值
        navigation.setUid(IdWorker.getIdStr());
        navigation.setAppId(appId);
        navigation.setAppName(parentNavigation.getAppName());
        String parentIds = String.format("%s.%s", parentNavigation.getParentIds(), navigation.getUid());
        navigation.setParentId(parentId);
        navigation.setParentIds(parentIds);
        navigation.setParentName(parentNavigation.getName());
        applicationNavigationRepository.insertNavigation(navigation);
        return ExecuteResult.success(true);
    }

    /**
     * 1.验证
     *
     * @param navigation
     * @return
     */
    @Override
    public ExecuteResult<Boolean> addNavigation(ApplicationNavigationVo navigation) {
        if (!Objects.equals(navigation.getParentId(), "")) {
            return addChildNavigation(navigation.getParentId(), navigation);
        } else {
            return addRootNavigation(navigation.getAppId(), navigation);
        }
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> updateNavigation(ApplicationNavigationVo navigation) {
        // 获取旧数据进行比对
        ApplicationNavigationVo dbNavigation = applicationNavigationRepository.getNavigation(navigation.getUid());
        // 控制不能进行修改属性
        navigation.setAppId(dbNavigation.getAppId());
        navigation.setAppName(dbNavigation.getAppName());
        // 处理上级id更换
        String parentId = navigation.getParentId();
        String dbParentId = dbNavigation.getParentId();
        if (!Objects.equals(parentId, dbParentId)) {
            if (Objects.equals(parentId, "")) {
                navigation.setParentId("");
                navigation.setParentName("");
                navigation.setParentIds(navigation.getUid());
            } else {
                // 获取上级导航，验证参数是否正确
                ApplicationNavigationVo parentNavigation = applicationNavigationRepository.getNavigation(parentId);
                String parentIds = String.format("%s.%s", parentNavigation.getParentIds(), navigation.getUid());
                navigation.setParentIds(parentIds);
                navigation.setParentName(parentNavigation.getName());
            }
            // 处理子集
            List<ApplicationNavigationVo> children =
                applicationNavigationRepository.getAllChildrenNavigation(dbNavigation.getUid());
            children.forEach(nav -> {
                String parentIds = dbNavigation.getParentIds();
                String oldIds = nav.getParentIds();
                String newIds = oldIds.replaceAll(parentIds, navigation.getParentIds());
                nav.setParentIds(newIds);
                applicationNavigationRepository.updatedNavigation(nav);
            });
        }
        // 处理名称更换
        String name = navigation.getName();
        String dbName = dbNavigation.getName();
        if (!Objects.equals(name, dbName)) {
            // 验证同应用导航name是否重复
            Check.notNull(name, new AppException("update navigation name is null"));
            ApplicationNavigationVo dbNameNavigation =
                applicationNavigationRepository.findNavigation(dbNavigation.getAppId(), name);
            Check.isTrue(dbNameNavigation != null, new AppException(
                String.format("update navigation appid:%s name:%s is exist", dbNavigation.getAppId(),
                    navigation.getName())));
            List<ApplicationNavigationVo> children =
                applicationNavigationRepository.getChildrenNavigation(dbNavigation.getUid());
            children.forEach(nav -> {
                nav.setParentName(name);
                applicationNavigationRepository.updatedNavigation(nav);
            });
        }
        // 更新导航
        applicationNavigationRepository.updatedNavigation(navigation);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> deleteNavigation(String navigationId) {
        // 获取数据详情
        ApplicationNavigationVo navigation = applicationNavigationRepository.getNavigation(navigationId);
        // 处理下级导航
        List<ApplicationNavigationVo> children =
            applicationNavigationRepository.getAllChildrenNavigation(navigation.getUid());
        children.forEach(nav -> applicationNavigationRepository.deleteNavigation(nav.getUid()));
        applicationNavigationRepository.deleteNavigation(navigationId);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<ApplicationNavigationVo> getNavigation(String id) {
        ApplicationNavigationVo navigation = applicationNavigationRepository.getNavigation(id);
        return ExecuteResult.success(navigation);
    }

    @Override
    public ExecuteResult<ApplicationNavigationVo> getNavigation(String appId, String name) {
        ApplicationNavigationVo navigation = applicationNavigationRepository.findNavigation(appId, name);
        Check.notNull(navigation, new AppException("find not get navigation by name"));
        return ExecuteResult.success(navigation);
    }
}
