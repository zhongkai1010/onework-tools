package com.onework.tools.domain.event;

import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationListener;
import org.springframework.stereotype.Component;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.event
 * @Description: 描述
 * @date Date : 2022年05月30日 14:41
 */
@Slf4j
@Component
public class EntityEventListener implements ApplicationListener<EntityApplicationEvent> {

    @Autowired
    private ApplicationContext applicationContext;

    /**
     * @param event 事件
     */
    @Override
    public void onApplicationEvent(EntityApplicationEvent event) {
        Map<String, EntityHandler> handleMap = applicationContext.getBeansOfType(EntityHandler.class);
        handleMap.forEach((k, v) -> {
            if (v.isDo(event)) {
                log.info("---------------do entity event is {}-------------------", k);
                v.doHandle(event);
            }
        });
    }
}
