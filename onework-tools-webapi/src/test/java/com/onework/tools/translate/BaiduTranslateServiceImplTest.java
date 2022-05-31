//package com.onework.tools.translate;
//
//import com.fasterxml.jackson.core.JsonProcessingException;
//import com.fasterxml.jackson.databind.ObjectMapper;
//import com.onework.tools.modularity.translate.domain.TranslateResult;
//import com.onework.tools.modularity.translate.domain.provide.BaiduTranslateServiceImpl;
//import com.onework.tools.webapi.OneworkToolsWebapiApplication;
//import org.junit.jupiter.api.Assertions;
//import org.junit.jupiter.api.Test;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.boot.test.context.SpringBootTest;
//
//import java.util.ArrayList;
//
///**
// * @author : zhongkai1010@163.com
// * @version V1.0
// * @Project: onework-tools
// * @Package com.onework.tools.domain.translate.provide
// * @Description: 描述
// * @date Date : 2022年04月15日 9:24
// */
//@SpringBootTest(classes = OneworkToolsWebapiApplication.class)
//class BaiduTranslateServiceImplTest {
//
//    @Autowired
//    private BaiduTranslateServiceImpl baiduTranslateService;
//
//    @Autowired
//    private ObjectMapper objectMapper;
//
//    @Test
//    void getApiName() {
//
//        Assertions.assertNotNull(baiduTranslateService.getApiName());
//    }
//
//    @Test
//    void translateText() throws JsonProcessingException {
//        ArrayList<String> arrayList = new ArrayList<>();
//        arrayList.add("开发");
//        arrayList.add("测试");
//        arrayList.add("交付");
//        TranslateResult translateResult = baiduTranslateService.translateText(arrayList);
//        System.out.println(objectMapper.writeValueAsString(translateResult));
//        Assertions.assertTrue(true);
//    }
//}