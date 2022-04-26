package com.onework.tools.translate.domain;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.translate.Language;
import org.springframework.stereotype.Component;

import java.util.ArrayList;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月07日 17:23
 */
@Component
public interface TranslateDomainService {

    /**
     * 翻译文本
     *
     * @param from
     * @param to
     * @param text
     * @return
     */
    ExecuteResult<String> translateText(Language from, Language to, String text);

    /**
     * 翻译文本
     *
     * @param text
     * @return
     */
    ExecuteResult<String> translateText(String text);

    /**
     * 翻译多行文本
     *
     * @param from
     * @param to
     * @param texts
     * @return
     */
    ExecuteResult<ArrayList<String>> translateText(Language from, Language to, ArrayList<String> texts);

}
