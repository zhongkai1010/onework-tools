package com.onework.tools.translate.domain.vo;

import com.onework.tools.translate.Language;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate.repository
 * @Description: 描述
 * @date Date : 2022年04月07日 17:31
 */
@Data
public class TranslationRecord {

    private String source;
    private String dst;
    private String src;
    private Language from;
    private Language to;
}
