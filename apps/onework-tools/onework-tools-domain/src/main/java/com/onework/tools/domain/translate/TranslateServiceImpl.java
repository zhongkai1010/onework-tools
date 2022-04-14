package com.onework.tools.domain.translate;

import com.onework.tools.core.Check;
import com.onework.tools.core.ExecuteResult;
import com.onework.tools.domain.translate.dao.TranslationRecord;
import com.onework.tools.domain.translate.provide.ThreeTranslateService;
import com.onework.tools.domain.translate.provide.TranslateResult;
import com.onework.tools.domain.translate.repository.TranslateRecordRepository;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月14日 14:15
 */
@Component
@Slf4j
public class TranslateServiceImpl implements TranslateService {

    final TranslateRecordRepository translateRecordRepository;

    final ThreeTranslateService threeTranslateService;

    public TranslateServiceImpl(TranslateRecordRepository translateRecordRepository,
        ThreeTranslateService threeTranslateService) {
        this.translateRecordRepository = translateRecordRepository;
        this.threeTranslateService = threeTranslateService;
    }

    @Override
    public ExecuteResult<String> translateText(Language from, Language to, String text) {

        ExecuteResult<String> result = new ExecuteResult<>();

        String dst = translateRecordRepository.queryRecord(from, to, text);
        if (dst != null) {
            return result.ok(dst);
        }
        dst = getTranslateDsts(from, to, text);

        TranslationRecord translationRecord = new TranslationRecord();
        translationRecord.setFrom(from);
        translationRecord.setTo(to);
        translationRecord.setSrc(text);
        translationRecord.setDst(dst);
        translationRecord.setSource(threeTranslateService.getApiName());
        translateRecordRepository.insertRecord(translationRecord);

        return result.ok(dst);
    }

    @Override
    public ExecuteResult<String> translateText(String text) {

        return translateText(Language.zh, Language.en, text);
    }

    @Override
    public ExecuteResult<ArrayList<String>> translateText(Language from, Language to, ArrayList<String> srcs) {

        ExecuteResult<ArrayList<String>> executeResult = new ExecuteResult<>();
        ArrayList<String> data = new ArrayList<>();

        for (int i = 0; i < srcs.size(); i++) {
            String src = srcs.get(i);
            String dst = translateRecordRepository.queryRecord(from, to, src);
            if (dst == null) {
                // TODO 后续考虑批量查询
                dst = getTranslateDsts(from, to, src);

                TranslationRecord translationRecord = new TranslationRecord();
                translationRecord.setFrom(from);
                translationRecord.setTo(to);
                translationRecord.setSrc(src);
                translationRecord.setDst(dst);
                translationRecord.setSource(threeTranslateService.getApiName());
                translateRecordRepository.insertRecord(translationRecord);

                data.add(i, dst);
            }
            data.add(i, dst);
        }

        return executeResult.ok(data);
    }

    private String getTranslateDsts(Language from, Language to, String src) {
        ArrayList<String> params = new ArrayList<>();
        params.add(src);
        ArrayList<String> data = getTranslateDsts(from, to, params);
        return data.get(0);
    }

    private ArrayList<String> getTranslateDsts(Language from, Language to, ArrayList<String> srcs) {

        TranslateResult translateResult = threeTranslateService.translateText(from, to, srcs);

        Check.notNull(translateResult, new DomainTranslateException(DomainTranslationModule.MODULE_CODE));

        List<TranslateResult.Result> result = translateResult.getTransResult();
        Check.notNull(result, new DomainTranslateException(DomainTranslationModule.MODULE_CODE));

        Check.notData(result, new DomainTranslateException(DomainTranslationModule.MODULE_CODE));

        ArrayList<String> dsts = new ArrayList<>();
        result.forEach(r -> dsts.add(r.getDst()));

        return dsts;
    }
}
