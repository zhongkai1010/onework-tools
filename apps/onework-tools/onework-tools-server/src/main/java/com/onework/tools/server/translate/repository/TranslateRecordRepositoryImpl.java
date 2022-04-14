package com.onework.tools.server.translate.repository;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.core.Check;
import com.onework.tools.domain.translate.Language;
import com.onework.tools.domain.translate.dao.TranslationRecord;
import com.onework.tools.domain.translate.repository.TranslateRecordRepository;
import com.onework.tools.server.translate.ServerTranslateException;
import com.onework.tools.server.translate.ServerTranslateModule;
import com.onework.tools.server.translate.entity.ToolTranslation;
import com.onework.tools.server.translate.mapper.ToolTranslationMapper;
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
        Check.notExecute(count, new ServerTranslateException(ServerTranslateModule.NOT_SUCCESS_INSERT_RECORD));
    }
}
