package com.onework.tools.modularity.application.domain.repository;

import com.onework.tools.modularity.application.domain.vo.SystemVo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.application.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月25日 14:39
 */
public interface SystemRepository {

    /**
     * 根据id获取系统，不存在则返回null
     *
     * @param id
     * @return
     */
    SystemVo getSystem(String id);
}
