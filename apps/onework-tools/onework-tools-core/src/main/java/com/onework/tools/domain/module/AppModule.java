package com.onework.tools.domain.module;

import com.onework.tools.ErrorMessage;
import com.onework.tools.entity.Entity;
import lombok.Data;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core.module
 * @Description: 模块
 * @date Date : 2022年04月24日 10:49
 */
@Data
public class AppModule implements Entity {

    /**
     * 模块标识
     */
    private String uid;

    /**
     * 模块编码
     */
    private String code;

    /**
     * 模块名称
     */
    private String name;

    /**
     * 模块功能
     *
     * @return
     */
    private List<AppFeature> features;

    /**
     * 模块错误消息
     */
    private List<ErrorMessage> errorMessages;


    public AppModule(String code, String name) {
        this.code = code;
        this.name = name;
    }
}


