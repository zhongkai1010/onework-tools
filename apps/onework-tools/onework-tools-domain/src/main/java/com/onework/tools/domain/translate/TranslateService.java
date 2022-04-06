package com.onework.tools.domain.translate;

import javafx.scene.control.Cell;
import retrofit2.http.GET;
import retrofit2.http.QueryMap;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月06日 17:32
 */
public interface TranslateService {

    /**
     * 百度翻译Api
     *
     * @param query
     * @return
     */
    @GET("https://fanyi-api.baidu.com/api/trans/vip/translate")
    Cell<BaiduTranslateResult> translateText(@QueryMap Map<String, String> query);

}
