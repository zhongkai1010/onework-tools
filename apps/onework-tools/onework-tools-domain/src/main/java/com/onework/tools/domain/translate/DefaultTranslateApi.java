package com.onework.tools.domain.translate;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月06日 10:44
 */
public abstract class DefaultTranslateApi implements TranslateApi {

    private TranslateConfig translateConfig;

    protected DefaultTranslateApi(TranslateConfig translateConfig) {
        this.translateConfig = translateConfig;
    }

    /**
     * 翻译文本
     *
     * @param source
     * @return
     */
    @Override
    public abstract String translateText(String source);
}
