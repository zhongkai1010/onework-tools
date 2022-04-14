package com.onework.tools.domain.translate.provide;

import cn.hutool.core.util.ArrayUtil;
import cn.hutool.core.util.RandomUtil;
import cn.hutool.crypto.SecureUtil;
import com.onework.tools.domain.translate.Language;
import com.onework.tools.domain.translate.TranslateProperties;
import org.springframework.stereotype.Component;
import org.springframework.web.client.RestTemplate;

import javax.validation.constraints.NotNull;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月07日 14:33
 */
@Component
public class BaiduTranslateServiceImpl implements ThreeTranslateService {

    private final TranslateProperties translateConfiguration;

    private final RestTemplate restTemplate;

    public BaiduTranslateServiceImpl(TranslateProperties translateConfiguration, RestTemplate restTemplate) {
        this.translateConfiguration = translateConfiguration;
        this.restTemplate = restTemplate;
    }

    @Override
    public String getApiName() {
        return "baidu";
    }

    @Override
    public TranslateResult translateText(String text) {
        return translateText(Language.zh, Language.en, new ArrayList<String>() {{
            add(text);
        }});
    }

    @Override
    public TranslateResult translateText(ArrayList<String> texts) {
        return translateText(Language.zh, Language.en, texts);
    }

    @Override
    public TranslateResult translateText(Language from, Language to, ArrayList<String> texts) {
        return internalBaiduTranslateText(from, to, texts.toArray(new String[0]));
    }

    @Override
    public TranslateResult translateText(Language from, Language to, String text) {
        return internalBaiduTranslateText(from, to, text);
    }

    private TranslateResult internalBaiduTranslateText(@NotNull Language from, @NotNull Language to,
        @NotNull String... query) {

        String url = translateConfiguration.getBaidu().getUrl();
        String appId = translateConfiguration.getBaidu().getAppId();
        String salt = RandomUtil.randomString(5);
        String secretKey = translateConfiguration.getBaidu().getSecretKey();

        String keywords = getBaiduTranslateQueryValue(query);
        String md5 = SecureUtil.md5(appId.concat(keywords).concat(salt).concat(secretKey));

        Map<String, Object> queryParams = new HashMap<>(16);
        queryParams.put("q", keywords);
        queryParams.put("from", from != null ? from : "auto");
        queryParams.put("to", to != null ? from : "auto");
        queryParams.put("appid", appId);
        queryParams.put("salt", salt);
        queryParams.put("sign", md5);

        return restTemplate.getForObject(url, TranslateResult.class, queryParams);
    }

    private static String getBaiduTranslateQueryValue(String[] queries) {
        return ArrayUtil.join(queries, "/n");
    }
}
