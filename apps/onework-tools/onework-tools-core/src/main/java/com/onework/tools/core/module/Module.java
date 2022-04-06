package com.onework.tools.core.module;

import org.springframework.stereotype.Component;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.module
 * @Description: 描述
 * @date Date : 2022年04月06日 15:24
 */
@Component
public interface Module {

    /**
     * 获取模块名称
     *
     * @return 模块名称
     */
    String getModuleName();

    /**
     * 获取模块编码
     *
     * @return 模块编码
     */
    String getModuleCode();

    /***
     * 获取异常信息Map集合，具体模块可以通过读取数据库或返回静态数据
     *
     * @return 异常信息Map
     */
    Map<String,String> getErrorMessageMaps();
}
