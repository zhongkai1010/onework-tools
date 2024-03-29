package com.onework.tools.component.spring;

import cn.hutool.core.collection.ListUtil;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.client.BufferingClientHttpRequestFactory;
import org.springframework.http.client.SimpleClientHttpRequestFactory;
import org.springframework.web.client.RestTemplate;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.spring
 * @Description: 描述
 * @date Date : 2022年04月08日 9:17
 */
@Configuration
public class RestTemplateConfig {

    @Bean
    public RestTemplate restTemplate() {

        SimpleClientHttpRequestFactory factory = new SimpleClientHttpRequestFactory();
        BufferingClientHttpRequestFactory bufferingClientHttpRequestFactory =
            new BufferingClientHttpRequestFactory(factory);
        RestTemplate restTemplate = new RestTemplate(bufferingClientHttpRequestFactory);

        // 日志拦截器
        restTemplate.setInterceptors(ListUtil.list(true, new LogClientHttpRequestInterceptor()));
        //换上fastjson
        //        List<HttpMessageConverter<?>> messageConverters = restTemplate.getMessageConverters();
        //        Iterator<HttpMessageConverter<?>> iterator = messageConverters.iterator();
        //        while (iterator.hasNext()) {
        //            HttpMessageConverter<?> converter = iterator.next();
        //            //原有的String是ISO-8859-1编码 去掉
        //            if (converter instanceof StringHttpMessageConverter) {
        //                iterator.remove();
        //            }
        //            //由于系统中默认有jackson 在转换json时自动会启用  但是我们不想使用它 可以直接移除
        //            if (converter instanceof GsonHttpMessageConverter
        //                || converter instanceof MappingJackson2HttpMessageConverter) {
        //                iterator.remove();
        //            }
        //        }
        //        messageConverters.add(new StringHttpMessageConverter(Charset.forName("utf-8")));
        //        FastJsonHttpMessageConverter fastJsonHttpMessageConverter = new FastJsonHttpMessageConverter();
        //        FastJsonConfig fastJsonConfig = new FastJsonConfig();
        //        fastJsonConfig.setSerializerFeatures(SerializerFeature.WriteMapNullValue,
        //            SerializerFeature.WriteNullStringAsEmpty, SerializerFeature.WriteNullListAsEmpty,
        //            SerializerFeature.DisableCircularReferenceDetect);
        //        fastJsonHttpMessageConverter.setFastJsonConfig(fastJsonConfig);
        //        messageConverters.add(fastJsonHttpMessageConverter);
//

        return restTemplate;

    }
}
