package com.onework.tools.application.domain.impl;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.NavigationDomainService;
import com.onework.tools.application.domain.repository.ApplicationRepository;
import com.onework.tools.application.domain.repository.SystemNavigationRepository;
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

    private final SystemNavigationRepository systemNavigationRepository;

    private ApplicationRepository applicationRepository;

    public NavigationDomainServiceImpl(SystemNavigationRepository systemNavigationRepository,
        ApplicationRepository applicationRepository) {
        this.systemNavigationRepository = systemNavigationRepository;
        this.applicationRepository = applicationRepository;
    }

    /**
     * 1.验证
     * 1.1 验证关联系统是否存在
     * 1.2 验证同系统name是否存在
     * 1.3 验证上级导航是否存在
     * 2.计算
     * 2.1 计算parentPath
     * 3.关联
     * 3.1 处理下级导航
     * 4.数据
     * 4.1 添加数据
     *
     * @param navigationVo
     * @return
     */
    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> addNavigation(ApplicationNavigationVo navigationVo) {
        //验证关联系统是否存在
        ApplicationVo applicationVo = applicationRepository.getApplication(navigationVo.getSystemId());
        navigationVo.setSystemName(applicationVo.getName());
        // 验证同系统name是否存在
        ApplicationNavigationVo dbNavigation =
            systemNavigationRepository.getNavigation(applicationVo.getUid(), navigationVo.getCode());
        Check.isTrue(dbNavigation != null, new AppException(""));
        // 验证上级导航是否存在
        String parentId = navigationVo.getParentId();
        if (parentId != null) {
            ApplicationNavigationVo parentNavigation = systemNavigationRepository.getNavigation(parentId);
            Check.notNull(parentNavigation, new AppException(""));
            navigationVo.setParentName(parentNavigation.getName());

            String code = String.format("%s.%s", parentNavigation.getCode(), navigationVo.getCode());
            navigationVo.setCode(code);
        }
        systemNavigationRepository.addNavigation(navigationVo);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> updateNavigation(ApplicationNavigationVo navigationVo) {
        // 获取旧数据进行比对
        ApplicationNavigationVo dbNav = systemNavigationRepository.getNavigation(navigationVo.getUid());
        Check.notNull(dbNav, new AppException(""));
        // 控制不能进行修改属性
        navigationVo.setSystemId(dbNav.getSystemId());
        navigationVo.setSystemName(dbNav.getSystemName());
        navigationVo.setCode(dbNav.getCode());
        // 处理更换上级导航
        String parentId = navigationVo.getParentId();
        if (!Objects.equals(dbNav.getParentId(), parentId)) {
            ApplicationNavigationVo parentNavigation = systemNavigationRepository.getNavigation(parentId);
            Check.notNull(parentNavigation, new AppException(""));

            String parentCode = String.format("%s.%s", parentNavigation.getCode(), navigationVo.getCode());
            navigationVo.setParentName(parentNavigation.getName());
            navigationVo.setCode(parentCode);
            // 处理下级导航
            List<ApplicationNavigationVo> children = systemNavigationRepository.getAllNavChildren(dbNav.getCode());
            children.forEach(nav -> {
                String code = nav.getCode();
                String newCode = code.replaceAll(dbNav.getCode(), parentCode);
                nav.setCode(newCode);
                systemNavigationRepository.updatedNavigation(nav);
            });
        }

        systemNavigationRepository.updatedNavigation(navigationVo);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> deleteNavigation(String navigationId) {
        // 获取数据详情
        ApplicationNavigationVo dbNav = systemNavigationRepository.getNavigation(navigationId);
        Check.notNull(dbNav, new AppException(""));
        // 处理下级导航
        List<ApplicationNavigationVo> children = systemNavigationRepository.getAllNavChildren(dbNav.getCode());
        children.forEach(nav -> systemNavigationRepository.deleteNavigation(nav.getUid()));
        systemNavigationRepository.deleteNavigation(navigationId);
        return ExecuteResult.success(true);
    }
}
