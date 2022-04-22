package com.onework.tools.translate.domain.provide;

import com.onework.tools.translate.domain.Language;
import org.springframework.stereotype.Component;

import java.util.ArrayList;

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
     * 获取翻译api名称
     *
     * @return
     */
    String getApiName();

    /**
     * 翻译Api
     *
     * @param query
     * @return
     */
    TranslateResult translateText(String query);

    /**
     * 翻译Api
     *
     * @param queries
     * @return
     */
    TranslateResult translateText(ArrayList<String> queries);

    /**
     * 翻译Api
     *
     * @param texts
     * @param from
     * @param to
     * @return
     */
    TranslateResult translateText(Language from, Language to, ArrayList<String> texts);

    /**
     * 翻译Api
     *
     * @param text
     * @param from
     * @param to
     * @return
     */
    TranslateResult translateText(Language from, Language to, String text);

}
