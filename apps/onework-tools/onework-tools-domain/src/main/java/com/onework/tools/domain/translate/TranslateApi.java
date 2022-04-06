package com.onework.tools.domain.translate;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月06日 10:43
 */
public interface TranslateApi {

    /**
     * 翻译文本
     *
     * @param source
     * @return
     */
    String translateText(String source);
}
