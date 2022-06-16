package com.onework.tools.domain.event;

import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.event
 * @Description: 描述
 * @date Date : 2022年05月30日 14:44
 */
@Component
public interface EntityHandler {

    /**
     * 是否处理
     *
     * @param applicationEvent
     * @return
     */
    Boolean isDo(EntityApplicationEvent applicationEvent);

    /**
     * 处理
     *
     * @param applicationEvent
     * @return
     */
    void doHandle(EntityApplicationEvent applicationEvent);
}
