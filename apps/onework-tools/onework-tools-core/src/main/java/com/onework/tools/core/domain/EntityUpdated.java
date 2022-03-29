package com.onework.tools.core.domain;

import java.time.LocalDateTime;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.common.domain
 * @className: EntityCreateAndUpdated
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/16 21:52
 * @version: 1.0
 */
public interface EntityUpdated {
    /**
     * 获取Id
     *
     * @return
     */
    LocalDateTime getUpdated();

    /**
     * 设置Id
     *
     * @param value
     */
    void setUpdated(LocalDateTime value);
}
