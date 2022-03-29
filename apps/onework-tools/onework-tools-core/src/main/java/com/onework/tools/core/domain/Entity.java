package com.onework.tools.core.domain;

import java.io.Serializable;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.common.domain
 * @className: IdEntity
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/16 21:45
 * @version: 1.0
 */
public interface Entity extends Serializable {

    /**
     * 获取Id
     *
     * @return
     */
    String getUid();

    /**
     * 设置Id
     *
     * @param value
     */
    void setUid(String value);
}
