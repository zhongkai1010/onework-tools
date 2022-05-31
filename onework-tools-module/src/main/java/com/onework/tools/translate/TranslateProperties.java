package com.onework.tools.translate;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月06日 10:41
 */
@Data
@Component
@ConfigurationProperties(prefix = "onework.translate")
public class TranslateProperties {

    private Baidu baidu;

    @Data
    public static class Baidu {
        private String url;
        private String appId;
        private String secretKey;
    }
}

