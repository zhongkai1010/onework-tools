package com.onework.tools.domain.translate;

import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月06日 17:32
 */
@Component
public interface ThreeTranslateService {

    /**
     * 百度翻译Api
     *
     * @param query
     * @return
     */
    BaiduTranslateResult baiduTranslateText(String query);

    /**
     * 百度翻译Api
     *
     * @param queries
     * @return
     */
    BaiduTranslateResult baiduTranslateText(String[] queries);

    /**
     * 百度翻译Api
     *
     * @param query
     * @param from
     * @param to
     * @return
     */
    BaiduTranslateResult baiduTranslateText(String query, String from, String to);

}
