package com.onework.tools.entity;

import java.time.LocalDateTime;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.common.domain
 * @className: EntityCreated
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/16 21:51
 * @version: 1.0
 */

public interface EntityCreated {
    /**
     * 获取created
     *
     * @return
     */
    LocalDateTime getCreated();

    /**
     * 设置created
     *
     * @param value
     */
    void setCreated(LocalDateTime value);
}
