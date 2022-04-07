package com.onework.tools.domain.translate;

import com.onework.tools.domain.translate.repository.TranslateRecordRepository;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月07日 17:23
 */

@Component
public class TranslateService {

    private final ThreeTranslateService threeTranslateService;
    private final TranslateRecordRepository translateRecordRepository;

    public TranslateService(ThreeTranslateService threeTranslateService,
        TranslateRecordRepository translateRecordRepository) {
        this.threeTranslateService = threeTranslateService;
        this.translateRecordRepository = translateRecordRepository;
    }

    public static String translateText(String text) {
        return translateText(new String[] {text})[0];
    }

    public static String[] translateText(String[] texts) {

        String[] result =

            translateRecordRepository.queryTranslate()

    }
}
