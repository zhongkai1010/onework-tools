package com.onework.tools.translate;

import com.alibaba.fastjson.JSON;
import com.onework.tools.translate.domain.TranslateResult;
import com.onework.tools.translate.domain.provide.BaiduTranslateServiceImpl;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.ArrayList;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate.provide
 * @Description: 描述
 * @date Date : 2022年04月15日 9:24
 */
@SpringBootTest()
class BaiduTranslateServiceImplTest {

    @Autowired
    private BaiduTranslateServiceImpl baiduTranslateService;

    @Test
    void getApiName() {

        Assertions.assertNotNull(baiduTranslateService.getApiName());
    }

    @Test
    void translateText() {
        ArrayList<String> arrayList = new ArrayList<>();
        arrayList.add("开发");
        arrayList.add("测试");
        arrayList.add("交付");
        TranslateResult translateResult = baiduTranslateService.translateText(arrayList);
        System.out.println(JSON.toJSON(translateResult));
        Assertions.assertTrue(true);
    }
}