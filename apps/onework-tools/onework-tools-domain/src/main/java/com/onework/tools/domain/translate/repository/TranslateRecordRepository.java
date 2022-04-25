package com.onework.tools.domain.translate.repository;

import com.onework.tools.domain.translate.Language;
import com.onework.tools.domain.translate.entity.TranslationRecord;
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
     * 检索翻译记录
     *
     * @param from
     * @param to
     * @param src
     * @return
     */
    String queryRecord(Language from, Language to, String src);

    /**
     * 添加翻译文本记录
     *
     * @param record
     */
    void insertRecord(TranslationRecord record);
}
