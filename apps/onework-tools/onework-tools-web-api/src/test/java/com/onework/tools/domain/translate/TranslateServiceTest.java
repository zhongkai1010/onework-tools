package com.onework.tools.domain.translate;

import com.onework.tools.core.ExecuteResult;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

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
    TranslateService translateService;

    @Test
    void translateText() {
        ExecuteResult<String> executeResult = translateService.translateText("hello");
        Assertions.assertTrue(executeResult.equals(ExecuteResult.SUCCESS));
    }
}