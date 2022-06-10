package com.onework.tools.application.domain.impl;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.ApplicationDomainService;
import com.onework.tools.application.domain.repository.ApplicationRepository;
import com.onework.tools.application.domain.vo.ApplicationVo;
import org.springframework.beans.factory.annotation.Autowired;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.application.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月25日 14:03
 */
public class ApplicationDomainServiceImpl implements ApplicationDomainService {

    @Autowired
    private ApplicationRepository applicationRepository;

    @Override
    public ExecuteResult<Boolean> addApplication(ApplicationVo applicationVo) {
        // 验证应用编码，避免出现重复
        ApplicationVo application = applicationRepository.getApplicationByCode(applicationVo.getCode());
        Check.isTrue(application == null, new AppException(""));
        // 添加应用
        applicationRepository.insertApplication(applicationVo);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updateApplication(ApplicationVo applicationVo) {
        // 获取更新应用，验证提交数据
        ApplicationVo application = applicationRepository.getApplication(applicationVo.getUid());
        Check.notNull(application,new AppException(""));
        // 控制不能变更的字段
        application.setName(application.getName());
        // 更新应用
        applicationRepository.updateApplication(application);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deleteApplication(ApplicationVo applicationVo) {
        // 获取更新应用，验证提交数据
        ApplicationVo application = applicationRepository.getApplication(applicationVo.getUid());
        Check.notNull(application,new AppException(""));
        // 更新应用
        applicationRepository.deleteApplication(application);
        return ExecuteResult.success(true);
    }
}
