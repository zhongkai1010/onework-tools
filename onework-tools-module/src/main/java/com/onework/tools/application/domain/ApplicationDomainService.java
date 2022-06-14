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
     * 根据code获取应用
     *
     * @param code
     * @return
     */
    ExecuteResult<ApplicationVo> getApplication(String code);

    /**
     * 添加应用
     *
     * @param application
     * @return
     */
    ExecuteResult<Boolean> addApplication(ApplicationVo application);

    /**
     * 修改应用
     *
     * @param application
     * @return
     */
    ExecuteResult<Boolean> updateApplication(ApplicationVo application);

    /**
     * 删除应用应用
     *
     * @param id
     * @return
     */
    ExecuteResult<Boolean> deleteApplication(String id);

    /**
     * 根据code查询应用，无数据则新增应用，反之返回应用数据
     *
     * @param application
     * @return
     */
    ExecuteResult<ApplicationVo> getApplicationByCodeAsSave(ApplicationVo application);
}
