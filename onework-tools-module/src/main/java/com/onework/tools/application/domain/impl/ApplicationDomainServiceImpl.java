package com.onework.tools.application.domain.impl;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.ApplicationDomainService;
import com.onework.tools.application.domain.repository.ApplicationRepository;
import com.onework.tools.application.domain.vo.ApplicationVo;
import org.springframework.stereotype.Service;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.application.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月25日 14:03
 */
@Service
public class ApplicationDomainServiceImpl implements ApplicationDomainService {

    private final ApplicationRepository applicationRepository;

    public ApplicationDomainServiceImpl(ApplicationRepository applicationRepository) {
        this.applicationRepository = applicationRepository;
    }

    @Override
    public ExecuteResult<ApplicationVo> getApplication(String code) {
        ApplicationVo dbApplication = applicationRepository.findApplicationByCode(code);
        Check.notNull(dbApplication, new AppException(String.format("get application is not find code : %s", code)));
        return ExecuteResult.success(dbApplication);
    }

    @Override
    public ExecuteResult<Boolean> addApplication(ApplicationVo applicationVo) {
        // 验证应用编码，避免出现重复
        ApplicationVo dbApplication = applicationRepository.findApplicationByCode(applicationVo.getCode());
        Check.isTrue(dbApplication != null,
            new AppException(String.format("add application code is repeat,code : %s", applicationVo.getCode())));
        // 添加应用
        applicationRepository.insertApplication(applicationVo);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updateApplication(ApplicationVo applicationVo) {
        // 验证id是否存在
        Check.notNull(applicationVo.getUid(), new AppException("id must be empty"));
        // 获取更新应用，验证提交数据
        ApplicationVo dbApplication = applicationRepository.getApplication(applicationVo.getUid());
        // 控制不能变更的字段
        dbApplication.setName(applicationVo.getName());
        // 更新应用
        applicationRepository.updateApplication(dbApplication);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deleteApplication(String id) {
        // 获取更新应用，验证提交数据
        ApplicationVo application = applicationRepository.getApplication(id);
        // 更新应用
        applicationRepository.deleteApplication(application);
        return ExecuteResult.success(true);
    }
}
