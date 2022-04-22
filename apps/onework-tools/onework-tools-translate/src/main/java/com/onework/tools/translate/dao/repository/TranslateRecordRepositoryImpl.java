package com.onework.tools.translate.dao.repository;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.core.Check;
import com.onework.tools.translate.TranslateException;
import com.onework.tools.translate.TranslationModule;
import com.onework.tools.translate.dao.entity.ToolTranslation;
import com.onework.tools.translate.dao.mapper.ToolTranslationMapper;
import com.onework.tools.translate.domain.Language;
import com.onework.tools.translate.domain.entity.TranslationRecord;
import com.onework.tools.translate.domain.repository.TranslateRecordRepository;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.translate.repository
 * @Description: 描述
 * @date Date : 2022年04月08日 9:19
 */
@Component
public class TranslateRecordRepositoryImpl implements TranslateRecordRepository {

    private final ToolTranslationMapper toolTranslationMapper;

    public TranslateRecordRepositoryImpl(ToolTranslationMapper toolTranslationMapper) {
        this.toolTranslationMapper = toolTranslationMapper;
    }

    @Override
    public String queryRecord(Language from, Language to, String src) {

        ToolTranslation toolTranslation =
            new LambdaQueryChainWrapper<>(toolTranslationMapper).eq(ToolTranslation::getFrom, from)
                .eq(ToolTranslation::getTo, to).eq(ToolTranslation::getSrc, src).one();
        return toolTranslation != null ? toolTranslation.getDst() : null;
    }

    @Override
    public void insertRecord(TranslationRecord record) {
        ToolTranslation toolTranslation = BeanUtil.copyProperties(record, ToolTranslation.class);
        int count = toolTranslationMapper.insert(toolTranslation);
        Check.notExecute(count, new TranslateException(TranslationModule.NOT_SUCCESS_INSERT_RECORD));
    }
}
