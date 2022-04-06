package com.onework.tools.domain.translate;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月06日 10:41
 */
@Data
public class TranslateConfig {
    /**
     * Api 地址
     */
    private String url;

    /**
     * 平台
     */
    private String appid;

    /**
     * 签名
     */
    private String sign;
}
