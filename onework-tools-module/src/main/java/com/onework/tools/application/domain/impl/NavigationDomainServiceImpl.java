package com.onework.tools.application.domain.impl;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.NavigationDomainService;
import com.onework.tools.application.domain.repository.ApplicationNavigationRepository;
import com.onework.tools.application.domain.repository.ApplicationRepository;
import com.onework.tools.application.domain.vo.ApplicationNavigationVo;
import com.onework.tools.application.domain.vo.ApplicationVo;
import com.onework.tools.domain.tree.TreeNameNodeHandler;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.application.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月25日 14:04
 */
@Service
public class NavigationDomainServiceImpl extends TreeNameNodeHandler<ApplicationNavigationVo>
    implements NavigationDomainService {

    private final ApplicationNavigationRepository applicationNavigationRepository;

    private final ApplicationRepository applicationRepository;

    public NavigationDomainServiceImpl(ApplicationNavigationRepository systemNavigationRepository,
        ApplicationRepository applicationRepository) {
        this.applicationNavigationRepository = systemNavigationRepository;
        this.applicationRepository = applicationRepository;
    }

    /**
     * 1.验证
     *
     * @param navigation
     * @return
     */
    @Override
    public ExecuteResult<Boolean> addNavigation(ApplicationNavigationVo navigation) {
        // 获取应用，验证参数是否正确
        String appId = navigation.getAppId();
        Check.notNull(appId, new AppException("add navigation app id is null"));
        ApplicationVo application = applicationRepository.getApplication(appId);
        // 控制关联属性
        navigation.setAppId(appId);
        navigation.setAppName(application.getName());
        // 添加节点
        addNode(navigation);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> updateNavigation(ApplicationNavigationVo navigation) {
        // 获取旧数据进行比对
        ApplicationNavigationVo dbNavigation = applicationNavigationRepository.getNavigation(navigation.getUid());
        // 控制不能进行修改属性
        navigation.setAppId(dbNavigation.getAppId());
        navigation.setAppName(dbNavigation.getAppName());
        // 更新导航
        updateNode(navigation);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> deleteNavigation(String navigationId) {
        deleteNode(navigationId);
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

    @Override
    protected ApplicationNavigationVo getNode(String id) {
        return applicationNavigationRepository.getNavigation(id);
    }

    @Override
    protected List<ApplicationNavigationVo> getAllChildrenNode(String id) {
        return applicationNavigationRepository.getAllChildrenNavigation(id);
    }

    @Override
    protected void saveNode(ApplicationNavigationVo node, Boolean isNew) {
        String id = node.getUid();
        if (isNew) {
            applicationNavigationRepository.insertNavigation(node);
        } else {
            applicationNavigationRepository.updatedNavigation(node);
        }
    }

    @Override
    protected void afterDeleteNode(ApplicationNavigationVo node) {
        applicationNavigationRepository.deleteNavigation(node.getUid());
    }

    @Override
    protected void updateChildNode(ApplicationNavigationVo childNode) {
        applicationNavigationRepository.updatedNavigation(childNode);
    }
}
