package com.onework.tools.file.domain;

import cn.hutool.json.JSONUtil;
import com.onework.tools.BaseApplicationTest;
import com.onework.tools.file.domain.vo.FileCategoryConfigType;
import com.onework.tools.webapi.OneworkToolsWebapiApplication;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.file.domain
 * @Description: 描述
 * @date Date : 2022年06月14日 14:47
 */
@SpringBootTest(classes = {OneworkToolsWebapiApplication.class})
class FileCategoryManagerTest extends BaseApplicationTest {

    @Autowired
    private FileCategoryManager fileCategoryManager;

    @Test
    void loadFileCategory() {

        Map<String, Map<FileCategoryConfigType, String>> map = fileCategoryManager.loadFileCategory();

        String json = JSONUtil.toJsonPrettyStr(map);

        System.out.println(json);
    }
}