package com.onework.tools.domain.translate.repository;

import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate.dao
 * @Description: 描述
 * @date Date : 2022年04月06日 17:09
 */
@Component
public interface TranslateRecordRepository {

    /**
     * 根据文本查询翻译内容
     *
     * @param text
     * @return
     */
    String queryTranslate(String text);
}
