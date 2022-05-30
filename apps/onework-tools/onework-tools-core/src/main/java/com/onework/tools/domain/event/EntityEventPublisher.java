package com.onework.tools.domain.event;

import com.onework.tools.domain.entity.Entity;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.context.ApplicationEventPublisherAware;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.event
 * @Description: 描述
 * @date Date : 2022年05月30日 14:31
 */
@Component
public class EntityEventPublisher implements ApplicationEventPublisherAware {

    @Autowired
    private ApplicationEventPublisher applicationEventPublisher;

    @Override
    public void setApplicationEventPublisher(ApplicationEventPublisher applicationEventPublisher) {
        this.applicationEventPublisher = applicationEventPublisher;
    }

    public void publishAddEntity(Entity entity) {
        //消息发布
        applicationEventPublisher.publishEvent(
            new EntityApplicationEvent(applicationEventPublisher, entity, OperateType.CREATE));
    }

    public void publishUpdateEntity(Entity entity) {
        //消息发布
        applicationEventPublisher.publishEvent(
            new EntityApplicationEvent(applicationEventPublisher, entity, OperateType.UPDATE));
    }

    public void publishDeleteEntity(Entity entity) {
        //消息发布
        applicationEventPublisher.publishEvent(
            new EntityApplicationEvent(applicationEventPublisher, entity, OperateType.DELETE));
    }
}
