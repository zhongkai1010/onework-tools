package com.onework.tools.modularity.application.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.application.domain.vo.SystemNavigationVo;

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
     * 添加导航
     *
     * @param navigation
     * @return
     */
    ExecuteResult<Boolean> addNavigation(SystemNavigationVo navigation);



    /**
     * 修改导航
     *
     * @param navigation
     * @return
     */
    ExecuteResult<Boolean> updateNavigation(SystemNavigationVo navigation);

    /**
     * 删除导航
     *
     * @param navId
     * @return
     */
    ExecuteResult<Boolean> deleteNavigation(String navId);
}
