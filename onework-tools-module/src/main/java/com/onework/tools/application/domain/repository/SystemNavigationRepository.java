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
public interface SystemNavigationRepository {

    /**
     * 根据code获取导航，无数据则返回null
     *
     * @param systemId
     * @param navCode
     * @return
     */
    ApplicationNavigationVo getNavigation(String systemId, String navCode);

    /**
     * 根据导航Id获取导航，无数据则返回null
     *
     * @param navId
     * @return
     */
    ApplicationNavigationVo getNavigation(String navId);

    /**
     *  获取所有下级导航
     * @param navCode
     * @return
     */
    List<ApplicationNavigationVo> getAllNavChildren(String navCode);

    /**
     * 添加导航
     *
     * @param navigation
     */
    void addNavigation(ApplicationNavigationVo navigation);

    /**
     * 修改导航，同步更新path
     *
     * @param navigation
     */
    void updatedNavigation(ApplicationNavigationVo navigation);


    /**
     * 删除导航，包括下级导航
     *
     * @param id
     */
    void deleteNavigation(String id);
}
