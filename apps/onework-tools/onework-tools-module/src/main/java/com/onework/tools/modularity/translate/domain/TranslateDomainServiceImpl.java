package com.onework.tools.modularity.translate.domain;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.translate.Language;
import com.onework.tools.modularity.translate.TranslateException;
import com.onework.tools.modularity.translate.domain.repository.TranslateRecordRepository;
import com.onework.tools.modularity.translate.domain.vo.TranslationRecordVo;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

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
public class TranslateDomainServiceImpl implements TranslateDomainService {

    final TranslateRecordRepository translateRecordRepository;

    final ThreeTranslateService threeTranslateService;

    public TranslateDomainServiceImpl(TranslateRecordRepository translateRecordRepository,
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

        TranslationRecordVo translationRecord = new TranslationRecordVo();
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

        //存储需要翻译文本,将数据库与调用区分开
        ArrayList<String> translateTexts = new ArrayList<>();
        Map<String, String> textMap = new HashMap<>(srcs.size());
        srcs.forEach(s -> {
            String dst = translateRecordRepository.queryRecord(from, to, s);
            if (dst == null) {
                translateTexts.add(s);
            }
            textMap.put(s, dst);
        });

        // 存储翻译文本结果
        ArrayList<String> dsts = getTranslateDsts(from, to, translateTexts);
        for (int i = 0; i < dsts.size(); i++) {
            String key = translateTexts.get(i);
            String dst = dsts.get(i);
            textMap.replace(key, dst);
            insertRecord(from, to, key, dst);
        }

        // 按照参数顺序组装结果
        ArrayList<String> dataResult = new ArrayList<>();
        for (int i = 0; i < srcs.size(); i++) {
            String key = srcs.get(i);
            String value = textMap.get(key);
            dataResult.add(i, value);
        }

        return executeResult.ok(dataResult);
    }

    private void insertRecord(Language from, Language to, String text, String dst) {
        TranslationRecordVo translationRecord = new TranslationRecordVo();
        translationRecord.setFrom(from);
        translationRecord.setTo(to);
        translationRecord.setSrc(text);
        translationRecord.setDst(dst);
        translationRecord.setSource(threeTranslateService.getApiName());
        translateRecordRepository.insertRecord(translationRecord);
    }

    private String getTranslateDsts(Language from, Language to, String src) {
        ArrayList<String> params = new ArrayList<>();
        params.add(src);
        ArrayList<String> data = getTranslateDsts(from, to, params);
        return data.get(0);
    }

    private ArrayList<String> getTranslateDsts(Language from, Language to, ArrayList<String> srcs) {

        if (srcs.size() == 0) {
            return new ArrayList<>();
        }

        TranslateResult translateResult = threeTranslateService.translateText(from, to, srcs);

        Check.notNull(translateResult, new AppException(TranslateException.THREE_API_NOT_DATA));

        List<TranslateResult.Result> result = translateResult.getTransResult();
        Check.notData(result, new AppException(TranslateException.THREE_API_NOT_DATA));

        ArrayList<String> dsts = new ArrayList<>();
        result.forEach(r -> dsts.add(r.getDst()));

        return dsts;
    }
}
