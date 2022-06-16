package com.onework.tools.application;

import cn.hutool.core.io.FileUtil;
import cn.hutool.json.JSONUtil;
import com.onework.tools.BaseApplicationTest;
import com.onework.tools.ExecuteResult;
import com.onework.tools.application.domain.ApplicationDomainService;
import com.onework.tools.application.domain.NavigationDomainService;
import com.onework.tools.application.domain.vo.ApplicationNavigationVo;
import com.onework.tools.application.domain.vo.ApplicationVo;
import com.onework.tools.webapi.OneworkToolsWebapiApplication;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

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

    private final NavigationCollection navigationCollection;

    public NavigationDomainServiceTest() {
        String fileName =
            System.getProperty("user.dir").concat("/src/test/java/com/onework/tools/application/nav.json");
        String json = FileUtil.readString(fileName, "utf-8");
        navigationCollection = JSONUtil.toBean(json, NavigationCollection.class);
    }

    @Test
    void addNavigation() {
        ApplicationVo applicationVo = new ApplicationVo();
        applicationVo.setName("测试应用1");
        applicationVo.setCode("test1");
        ExecuteResult<ApplicationVo> executeResult = applicationDomainService.getApplicationByCodeAsSave(applicationVo);

        ApplicationVo application = executeResult.getData();
        navigationCollection.getNavigations()
            .forEach(navigationDto -> internalAddNavigation(application.getUid(), null, navigationDto));
    }

    @Test
    void updateNavigation() {

        ApplicationVo applicationVo = new ApplicationVo();
        applicationVo.setName("测试应用1");
        applicationVo.setCode("test1");
        ExecuteResult<ApplicationVo> executeResult = applicationDomainService.getApplicationByCodeAsSave(applicationVo);

        ApplicationVo application = executeResult.getData();
        ExecuteResult<ApplicationNavigationVo> executeResult1 =
            navigationDomainService.getNavigation(application.getUid(), "角色管理");
        ApplicationNavigationVo applicationNavigationVo = executeResult1.getData();

        ExecuteResult<ApplicationNavigationVo> executeResult2 =
            navigationDomainService.getNavigation(application.getUid(), "用户管理");
        applicationNavigationVo.setParentId(executeResult2.getData().getUid());
        navigationDomainService.updateNavigation(applicationNavigationVo);
    }

    @Test
    void deleteNavigation() {
        ApplicationVo applicationVo = new ApplicationVo();
        applicationVo.setName("测试应用1");
        applicationVo.setCode("test1");
        ExecuteResult<ApplicationVo> executeResult = applicationDomainService.getApplicationByCodeAsSave(applicationVo);

        ApplicationVo application = executeResult.getData();
        ExecuteResult<ApplicationNavigationVo> executeResult1 =
            navigationDomainService.getNavigation(application.getUid(), "角色管理");
        ApplicationNavigationVo applicationNavigationVo = executeResult1.getData();
        navigationDomainService.deleteNavigation(applicationNavigationVo.getUid());
    }

    private void internalAddNavigation(String appId, ApplicationNavigationVo parent, NavigationDto navigationDto) {

        ApplicationNavigationVo applicationNavigationVo = new ApplicationNavigationVo();
        applicationNavigationVo.setPath(navigationDto.getPath());
        applicationNavigationVo.setName(navigationDto.getName());
        applicationNavigationVo.setAppId(appId);
        if (parent != null) {
            applicationNavigationVo.setParentId(parent.getUid());
        }
        navigationDomainService.addNavigation(applicationNavigationVo);

        List<NavigationDto> children = navigationDto.getChildren();
        if (children != null) {
            children.forEach(childNavigation -> internalAddNavigation(appId, applicationNavigationVo, childNavigation));
        }
    }
}