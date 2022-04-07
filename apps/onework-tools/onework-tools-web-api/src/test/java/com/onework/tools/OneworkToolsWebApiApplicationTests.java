package com.onework.tools;

import com.onework.tools.domain.database.DatabaseDomainException;
import com.onework.tools.domain.translate.BaiduTranslateResult;
import com.onework.tools.domain.translate.ThreeTranslateService;
import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@Slf4j
@SpringBootTest
class OneworkToolsWebApiApplicationTests {

    @Autowired
    private ThreeTranslateService translateService;

    @Test
    void contextLoads() throws DatabaseDomainException {

        BaiduTranslateResult translateResult = translateService.baiduTranslateText("hello\nthree", "auto", "auto");
        Assertions.assertTrue(true);
    }
}
