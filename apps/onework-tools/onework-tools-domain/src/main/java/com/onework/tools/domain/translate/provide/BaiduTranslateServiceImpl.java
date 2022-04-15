package com.onework.tools.domain.translate.provide;

import cn.hutool.core.util.ArrayUtil;
import cn.hutool.core.util.RandomUtil;
import cn.hutool.crypto.SecureUtil;
import cn.hutool.http.HttpUtil;
import com.alibaba.fastjson.JSON;
import com.onework.tools.core.Check;
import com.onework.tools.domain.translate.DomainTranslateException;
import com.onework.tools.domain.translate.DomainTranslationModule;
import com.onework.tools.domain.translate.Language;
import com.onework.tools.domain.translate.TranslateProperties;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Component;
import org.springframework.web.util.UriComponentsBuilder;

import javax.validation.constraints.NotNull;
import java.util.ArrayList;

/**
 * 52000 	 成功
 * 52001 	 请求超时 	 请重试
 * 52002 	 系统错误 	 请重试
 * 52003 	 未授权用户 	 请检查appid是否正确或者服务是否开通
 * 54000 	 必填参数为空 	 请检查是否少传参数
 * 54001 	 签名错误 	 请检查您的签名生成方法
 * 54003 	 访问频率受限 	 请降低您的调用频率，或进行身份认证后切换为高级版/尊享版
 * 54004 	 账户余额不足 	 请前往管理控制台为账户充值
 * 54005 	 长query请求频繁 	 请降低长query的发送频率，3s后再试
 * 58000 	 客户端IP非法 	 检查个人资料里填写的IP地址是否正确，可前往开发者信息-基本信息修改
 * 58001 	 译文语言方向不支持 	 检查译文语言是否在语言列表里
 * 58002 	 服务当前已关闭 	 请前往管理控制台开启服务
 * 90107 	 认证未通过或未生效 	 请前往我的认证查看认证进度
 *
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.translate
 * @Description: 描述
 * @date Date : 2022年04月07日 14:33
 */
@Slf4j
@Component
public class BaiduTranslateServiceImpl implements ThreeTranslateService {

    private final TranslateProperties translateConfiguration;

    public BaiduTranslateServiceImpl(TranslateProperties translateConfiguration) {
        this.translateConfiguration = translateConfiguration;
    }

    @Override
    public String getApiName() {
        return "baidu";
    }

    @Override
    public TranslateResult translateText(String text) {
        return translateText(Language.zh, Language.en, new ArrayList<String>() {{
            add(text);
        }});
    }

    @Override
    public TranslateResult translateText(ArrayList<String> texts) {
        return translateText(Language.zh, Language.en, texts);
    }

    @Override
    public TranslateResult translateText(Language from, Language to, ArrayList<String> texts) {

        return internalBaiduTranslateText(from, to, texts.toArray(new String[0]));
    }

    @Override
    public TranslateResult translateText(Language from, Language to, String text) {
        return internalBaiduTranslateText(from, to, text);
    }

    private TranslateResult internalBaiduTranslateText(@NotNull Language from, @NotNull Language to,
        @NotNull String... query) {

        if (from.equals(to)) {
            throw new DomainTranslateException(DomainTranslationModule.LANGUAGE_TYPE_ERROR);
        }

        String url = translateConfiguration.getBaidu().getUrl();
        String appId = translateConfiguration.getBaidu().getAppId();
        String salt = RandomUtil.randomString(5);
        String secretKey = translateConfiguration.getBaidu().getSecretKey();
        String text = ArrayUtil.join(query, "\n");
        String md5 = SecureUtil.md5(appId.concat(text).concat(salt).concat(secretKey));

        UriComponentsBuilder builder = UriComponentsBuilder.fromUriString(url);
        builder.queryParam("q", text);
        builder.queryParam("from", from);
        builder.queryParam("to", to);
        builder.queryParam("appid", appId);
        builder.queryParam("salt", salt);
        builder.queryParam("sign", md5);
        String requestUrl = builder.toUriString();
        String body = HttpUtil.get(requestUrl);
        TranslateResult translateResult = JSON.parseObject(body, TranslateResult.class);

        Check.notNull(translateResult, new DomainTranslateException(DomainTranslationModule.THREE_API_NOT_DATA));

        if (translateResult.getErrorCode() != null) {
            log.info("BaiduTranslateServiceImpl TranslateText Error,error code:{}", translateResult.getErrorCode());
            throw new DomainTranslateException(DomainTranslationModule.THREE_API_RESULT_ERROR,
                new String[] {translateResult.getErrorCode()});
        }

        return translateResult;
    }

}
