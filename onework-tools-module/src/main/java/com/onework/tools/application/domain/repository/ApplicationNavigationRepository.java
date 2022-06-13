package com.onework.tools.application.domain.repository;

import com.onework.tools.application.domain.vo.ApplicationNavigationVo;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.application.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月25日 14:19
 */
public interface ApplicationNavigationRepository {

    /**
     * 根据appId和名称查询导航
     *
     * @param appId
     * @param name
     * @return
     */
    ApplicationNavigationVo findNavigation(String appId, String name);

    /**
     * 添加导航
     *
     * @param navigation
     */
    void insertNavigation(ApplicationNavigationVo navigation);

    /**
     * 根据id获取导航，无数据则异常
     *
     * @param id
     * @return
     */
    ApplicationNavigationVo getNavigation(String id);

    /**
     * 根据id获取所有子导航
     *
     * @param id
     * @return
     */
    List<ApplicationNavigationVo> getAllChildrenNavigation(String id);

    /**
     * 更新导航
     *
     * @param nav
     */
    void updatedNavigation(ApplicationNavigationVo nav);

    /**
     * 根据id删除导航
     *
     * @param id
     */
    void deleteNavigation(String id);

    /**
     * 根据id获取子集导航
     *
     * @param id
     * @return
     */
    List<ApplicationNavigationVo> getChildrenNavigation(String id);
}
