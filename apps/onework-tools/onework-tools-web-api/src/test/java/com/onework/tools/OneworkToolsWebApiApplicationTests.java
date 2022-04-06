package com.onework.tools;

import cn.hutool.core.util.RandomUtil;
import cn.hutool.crypto.SecureUtil;
import com.onework.tools.domain.database.DatabaseDomainException;
import com.onework.tools.domain.translate.BaiduTranslateResult;
import com.onework.tools.domain.translate.TranslateService;
import com.onework.tools.server.database.mapper.DatabaseTableMapper;
import javafx.scene.control.Cell;
import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import retrofit2.Retrofit;

import java.util.HashMap;
import java.util.Map;

@Slf4j
@SpringBootTest
class OneworkToolsWebApiApplicationTests {

    @Autowired
    private DatabaseTableMapper databaseTableMapper;

    @Test
    void contextLoads() throws DatabaseDomainException {

        //        final String url = "https://fanyi-api.baidu.com/api/trans/vip/translate";
        final String q = "泛基因组";
        final String appId = "20210206000692404";
        final String salt = RandomUtil.randomString(5);
        final String secretKey = "26ZZ7HwrFuxiOcAQ_inQ";
        final String md5 = SecureUtil.md5(appId.concat(q).concat(salt).concat(secretKey));
        final Map<String, String> query = new HashMap<>();
        query.put("q", q);
        query.put("from", "auto");
        query.put("to", "auto");
        query.put("appid", appId);
        query.put("salt", salt);
        query.put("sign", md5);
        //        final String result = HttpUtil.get(url, query);
        //        System.out.println(UnicodeUtil.toString(result));

        final Retrofit retrofit = new Retrofit.Builder().build();
        final TranslateService translateService = retrofit.create(TranslateService.class);
        final Cell<BaiduTranslateResult> cell = translateService.translateText(query);
        final BaiduTranslateResult baiduTranslateResult = cell.getItem();
    }
}
