package com.onework.tools.application.domain.repository.impl;

import com.onework.tools.application.domain.repository.SystemNavigationRepository;
import com.onework.tools.application.domain.vo.ApplicationNavigationVo;
import org.springframework.stereotype.Repository;

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
public class DefaultSystemNavigationRepository implements SystemNavigationRepository {

    @Override
    public ApplicationNavigationVo getNavigation(String systemId, String navCode) {
        return null;
    }

    @Override
    public ApplicationNavigationVo getNavigation(String navId) {
        return null;
    }

    @Override
    public List<ApplicationNavigationVo> getAllNavChildren(String navCode) {
        return null;
    }

    @Override
    public void addNavigation(ApplicationNavigationVo navigation) {

    }

    @Override
    public void updatedNavigation(ApplicationNavigationVo navigation) {

    }

    @Override
    public void deleteNavigation(String id) {

    }
}
