package com.onework.tools.core.module;

import org.springframework.stereotype.Component;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.module
 * @Description: 描述
 * @date Date : 2022年03月31日 16:49
 */
@Component
public interface ModuleInfo {

    /**
     * 获取模块编码，便于区分异常编码
     *
     * @return
     */
    String getModuleCode();

    /**
     * 获取异常编码映射错误信息
     *
     * @return
     */
    Map<String, String> getErrorCodeMap();
}
