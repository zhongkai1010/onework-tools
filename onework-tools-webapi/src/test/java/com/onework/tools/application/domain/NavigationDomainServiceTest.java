package com.onework.tools.application.domain;

import com.onework.tools.BaseApplicationTest;
import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.vo.ApplicationNavigationVo;
import com.onework.tools.application.domain.vo.ApplicationVo;
import com.onework.tools.webapi.OneworkToolsWebapiApplication;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.application.domain
 * @Description: 描述
 * @date Date : 2022年06月13日 17:06
 */
@SpringBootTest(classes = {OneworkToolsWebapiApplication.class})
public class NavigationDomainServiceTest extends BaseApplicationTest {

    @Autowired
    private ApplicationDomainService applicationDomainService;

    @Autowired
    private NavigationDomainService navigationDomainService;

    private List<NavigationDto> navigations;

    public NavigationDomainServiceTest() {
        navigations = new ArrayList<NavigationDto>() {{
            add(new NavigationDto() {{
                setName("应用管理");
            }});
            add(new NavigationDto() {{
                setName("消息管理");
                setChild(new ArrayList<NavigationDto>(){{
                    add(new NavigationDto(){{
                        setName("消息模板");
                        setName("消息记录");
                    }});
                }});
            }});
            add(new NavigationDto() {{
                setName("应用管理");
            }});
            add(new NavigationDto() {{
                setName("应用管理");
            }});
            add(new NavigationDto() {{
                setName("应用管理");
            }});
            add(new NavigationDto() {{
                setName("应用管理");
            }});
        }};
    }

    @Test
    public void addRootNavigation() {
        ApplicationVo applicationVo = new ApplicationVo();
        applicationVo.setName("测试应用nav1");
        applicationVo.setCode("application_nav1");
        ExecuteResult<Boolean> executeResult = applicationDomainService.addApplication(applicationVo);
        Assertions.assertEquals(executeResult.isResult(), true);

        String appId = applicationVo.getUid();
        ApplicationNavigationVo applicationNavigationVo = new ApplicationNavigationVo();
        applicationNavigationVo.setAppId(appId);
        applicationNavigationVo.setPath("/test");
        applicationNavigationVo.setName("测试管理");
        executeResult = navigationDomainService.addRootNavigation(appId, applicationNavigationVo);
        Assertions.assertEquals(executeResult.isResult(), true);
    }

    @Test
    void addChildNavigation() {

        ApplicationVo applicationVo = new ApplicationVo();
        applicationVo.setName("测试应用nav2");
        applicationVo.setCode("application_nav2");
        ExecuteResult<Boolean> executeResult = applicationDomainService.addApplication(applicationVo);
        Assertions.assertEquals(executeResult.isResult(), true);

        String appId = applicationVo.getUid();
        ApplicationNavigationVo rootNavigation = new ApplicationNavigationVo();
        rootNavigation.setAppId(appId);
        rootNavigation.setPath("/test2");
        rootNavigation.setName("测试管理2");
        executeResult = navigationDomainService.addRootNavigation(appId, rootNavigation);
        Assertions.assertEquals(executeResult.isResult(), true);

        ApplicationNavigationVo childNavigation1 = new ApplicationNavigationVo();
        childNavigation1.setName("测试接口");
        childNavigation1.setPath("/test2/interface");
        executeResult = navigationDomainService.addChildNavigation(rootNavigation.getUid(), childNavigation1);
        Assertions.assertEquals(executeResult.isResult(), true);

        ApplicationNavigationVo childNavigation2 = new ApplicationNavigationVo();
        childNavigation2.setName("测试日志");
        childNavigation2.setPath("/test2/interface/logs");
        executeResult = navigationDomainService.addChildNavigation(childNavigation1.getUid(), childNavigation2);
        Assertions.assertEquals(executeResult.isResult(), true);
    }

    @Test
    void updateNavigation() {

    }

    @Test
    void deleteNavigation() {

    }
}