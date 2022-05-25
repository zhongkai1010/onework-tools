package com.onework.tools.domain.entity;

import java.time.LocalDateTime;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.common.domain
 * @className: DeleteEntity
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/16 21:53
 * @version: 1.0
 */
public interface EntityDeleted {
    /**
     * 获取deleted
     *
     * @return
     */
    LocalDateTime getDeleted();

    /**
     * 设置deleted
     *
     * @param value
     */
    void setDeleted(LocalDateTime value);
}
