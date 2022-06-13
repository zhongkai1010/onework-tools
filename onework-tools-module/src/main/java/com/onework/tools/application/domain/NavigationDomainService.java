package com.onework.tools.application.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.vo.ApplicationNavigationVo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.application.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月25日 11:26
 */
public interface NavigationDomainService {

    /**
     * 添加根导航
     *
     * @param appId      应用id
     * @param navigation 导航数据
     * @return
     */
    ExecuteResult<Boolean> addRootNavigation(String appId, ApplicationNavigationVo navigation);

    /**
     * 添加根导航
     *
     * @param parentId   父级导航id
     * @param navigation 导航数据
     * @return
     */
    ExecuteResult<Boolean> addChildNavigation(String parentId, ApplicationNavigationVo navigation);

    /**
     * 添加导航
     *
     * @param navigation
     * @return
     */
    ExecuteResult<Boolean> addNavigation(ApplicationNavigationVo navigation);

    /**
     * 修改导航
     *
     * @param navigation
     * @return
     */
    ExecuteResult<Boolean> updateNavigation(ApplicationNavigationVo navigation);

    /**
     * 删除导航
     *
     * @param navId
     * @return
     */
    ExecuteResult<Boolean> deleteNavigation(String navId);
}
