package com.onework.tools.domain.translate.provide;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月06日 17:52
 */
@NoArgsConstructor
@Data
public class TranslateResult {

    @JsonProperty("from")
    private String from;

    @JsonProperty("to")

    private String to;
    @JsonProperty("trans_result")
    private List<Result> transResult;

    @NoArgsConstructor
    @Data
    public static class Result {
        @JsonProperty("src")
        private String src;
        @com.fasterxml.jackson.annotation.JsonProperty("dst")
        private String dst;
    }
}
