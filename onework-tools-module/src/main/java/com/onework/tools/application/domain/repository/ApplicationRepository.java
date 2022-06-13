package com.onework.tools.application.domain.repository;

import com.onework.tools.application.domain.vo.ApplicationVo;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.application.domain.repository
 * @Description: 描述
 * @date Date : 2022年06月10日 15:21
 */
@Component
public interface ApplicationRepository {

    /**
     * 根据code获取应用,无数据则为空
     *
     * @param code
     * @return
     */
    ApplicationVo findApplicationByCode(String code);

    /**
     * 新增应用
     *
     * @param applicationVo
     */
    void insertApplication(ApplicationVo applicationVo);

    /**
     * 根据id获取应用
     *
     * @param uid
     * @return
     */
    ApplicationVo getApplication(String uid);

    /**
     * 修改应用
     *
     * @param application
     */
    void updateApplication(ApplicationVo application);

    /**
     * 删除应用
     *
     * @param application
     */
    void deleteApplication(ApplicationVo application);
}
