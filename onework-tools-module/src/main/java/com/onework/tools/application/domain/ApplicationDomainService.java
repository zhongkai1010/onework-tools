package com.onework.tools.application.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.vo.ApplicationVo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.application.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月25日 11:20
 */
public interface ApplicationDomainService {

    /**
     * 添加应用
     *
     * @param applicationVo
     * @return
     */
    ExecuteResult<Boolean> addApplication(ApplicationVo applicationVo);

    /**
     * 修改应用
     *
     * @param applicationVo
     * @return
     */
    ExecuteResult<Boolean> updateApplication(ApplicationVo applicationVo);

    /**
     * 删除应用应用
     *
     * @param applicationVo
     * @return
     */
    ExecuteResult<Boolean> deleteApplication(ApplicationVo applicationVo);

}
