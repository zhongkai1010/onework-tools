package com.onework.tools.modularity.translate.domain;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.ArrayList;
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


    private String from;


    private String to;

    @JsonProperty("trans_result")
    private final List<Result> transResult = new ArrayList<>();

    @JsonProperty("error_code")
    private String errorCode;

    @JsonProperty("error_msg")
    private String errorMsg;

    @NoArgsConstructor
    @Data
    public static class Result {

        private String src;

        private String dst;
    }
}
