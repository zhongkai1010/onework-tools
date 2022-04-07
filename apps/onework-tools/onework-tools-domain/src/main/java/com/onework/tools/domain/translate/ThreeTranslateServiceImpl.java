package com.onework.tools.domain.translate;

import cn.hutool.core.text.UnicodeUtil;
import cn.hutool.core.util.ArrayUtil;
import cn.hutool.core.util.RandomUtil;
import cn.hutool.crypto.SecureUtil;
import cn.hutool.http.HttpUtil;
import cn.hutool.json.JSONUtil;
import org.springframework.stereotype.Component;

import javax.validation.constraints.NotNull;
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
public class ThreeTranslateServiceImpl implements ThreeTranslateService {

    private final TranslateProperties translateConfiguration;

    public ThreeTranslateServiceImpl(TranslateProperties translateConfiguration) {
        this.translateConfiguration = translateConfiguration;
    }

    @Override
    public BaiduTranslateResult baiduTranslateText(String query) {
        return internalBaiduTranslateText("auto", "auto", query);
    }

    @Override
    public BaiduTranslateResult baiduTranslateText(String[] queries) {
        return internalBaiduTranslateText("auto", "auto", queries);
    }

    @Override
    public BaiduTranslateResult baiduTranslateText(@NotNull String query, String from, String to) {
        return internalBaiduTranslateText(from, to, query);
    }

    private BaiduTranslateResult internalBaiduTranslateText(@NotNull String from, @NotNull String to,
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
        String result = HttpUtil.get(url, queryParams);
        result = UnicodeUtil.toString(result);
        return JSONUtil.toBean(result, BaiduTranslateResult.class);
    }

    private static String getBaiduTranslateQueryValue(String[] queries) {
        return ArrayUtil.join(queries, "/n");
    }
}
