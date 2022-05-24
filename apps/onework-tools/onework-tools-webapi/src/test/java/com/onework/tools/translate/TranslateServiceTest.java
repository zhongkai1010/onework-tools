package com.onework.tools.translate;

import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.translate.Language;
import com.onework.tools.modularity.translate.domain.TranslateDomainService;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.ArrayList;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月14日 17:52
 */
@SpringBootTest()
class TranslateServiceTest {

    @Autowired
    TranslateDomainService translateService;

    @Test
    void translateText() {
        ArrayList<String> arrayList = new ArrayList<>();
        arrayList.add("老人");
        arrayList.add("鼠标");
        arrayList.add("小孩");
        arrayList.add("键盘");
        ExecuteResult<ArrayList<String>> executeResult = translateService.translateText(Language.zh, Language.en,
            arrayList);
        executeResult.getData().forEach(s -> System.out.println(s));
        Assertions.assertTrue(executeResult.compare(ExecuteResult.SUCCESS));
    }
}