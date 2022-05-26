package com.onework.tools.modularity.file.domain.event;

import com.onework.tools.modularity.file.domain.vo.FileCategoryVo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.context.ApplicationEventPublisherAware;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file
 * @Description: 描述
 * @date Date : 2022年05月26日 14:56
 */
@Component
public class FileCategoryEventPublisher implements ApplicationEventPublisherAware {

    @Autowired
    private ApplicationEventPublisher applicationEventPublisher;

    public void publishFileCategory(FileCategoryVo fileCategoryVo) {
        //消息发布
        applicationEventPublisher.publishEvent(new FileCategoryEvent(this, fileCategoryVo));
    }

    @Override
    public void setApplicationEventPublisher(ApplicationEventPublisher applicationEventPublisher) {
        this.applicationEventPublisher = applicationEventPublisher;
    }
}
