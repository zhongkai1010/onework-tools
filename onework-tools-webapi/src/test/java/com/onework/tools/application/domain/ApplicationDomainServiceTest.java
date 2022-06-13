package com.onework.tools.application.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.vo.ApplicationVo;
import com.onework.tools.webapi.OneworkToolsWebapiApplication;
import com.onework.tools.BaseApplicationTest;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.application.domain
 * @Description: 描述
 * @date Date : 2022年06月13日 11:04
 */
@SpringBootTest(classes = {OneworkToolsWebapiApplication.class})
class ApplicationDomainServiceTest extends BaseApplicationTest {

    @Autowired
    private ApplicationDomainService applicationDomainService;

    @Test
    void addApplication() {
        ApplicationVo applicationVo = new ApplicationVo();
        applicationVo.setName("测试应用");
        applicationVo.setCode("application.test");
        ExecuteResult<Boolean> executeResult = applicationDomainService.addApplication(applicationVo);
        Assertions.assertEquals(executeResult.isResult(), true);
    }

    @Test
    void updateApplication() {

        ExecuteResult<ApplicationVo> applicationVoExecuteResult = applicationDomainService.getApplication("application.test");
        ApplicationVo applicationVo = applicationVoExecuteResult.getData();

        applicationVo.setName("测试应用1");
        applicationVo.setCode("application.test");

        ExecuteResult<Boolean> executeResult = applicationDomainService.updateApplication(applicationVo);
        Assertions.assertEquals(executeResult.isResult(), true);
    }

    @Test
    void deleteApplication() {
        ExecuteResult<ApplicationVo> applicationVoExecuteResult = applicationDomainService.getApplication("application.test");
        ApplicationVo applicationVo = applicationVoExecuteResult.getData();

        ExecuteResult<Boolean> executeResult =  applicationDomainService.deleteApplication(applicationVo.getUid());
        Assertions.assertEquals(executeResult.isResult(), true);
    }

}