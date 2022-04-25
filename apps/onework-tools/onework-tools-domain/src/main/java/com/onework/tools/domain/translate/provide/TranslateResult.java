package com.onework.tools.domain.translate.provide;

import com.alibaba.fastjson.annotation.JSONField;
import com.alibaba.fastjson.parser.Feature;
import com.alibaba.fastjson.serializer.SerializerFeature;
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

    @JSONField(name = "from")
    private String from;

    @JSONField(name = "to")
    private String to;

    @JSONField(name = "trans_result", serialzeFeatures = SerializerFeature.BeanToArray, parseFeatures = Feature.SupportArrayToBean)
    private List<Result> transResult = new ArrayList<>();

    @JSONField(name = "error_code")
    private String errorCode;

    @JSONField(name = "error_msg")
    private String errorMsg;

    @NoArgsConstructor
    @Data
    public static class Result {
        @JSONField(name = "src")
        private String src;
        @JSONField(name = "dst")
        private String dst;
    }
}
