package com.onework.tools.domain.translate.dao;

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
    private String from;
    private String to;
}
