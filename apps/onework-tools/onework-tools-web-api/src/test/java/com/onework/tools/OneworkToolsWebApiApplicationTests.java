package com.onework.tools;

import com.onework.tools.domain.database.DomainDatabaseException;
import com.onework.tools.domain.translate.Language;
import com.onework.tools.domain.translate.provide.ThreeTranslateService;
import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@Slf4j
@SpringBootTest
class OneworkToolsWebApiApplicationTests {

    @Autowired
    private ThreeTranslateService translateService;

    @Test
    void contextLoads() throws DomainDatabaseException {

        //        TranslateResult translateResult = translateService.translateText("hello\nthree", "auto", "auto");
        //        Assertions.assertTrue(true);

        System.out.println(Language.en.toString());
    }
}
