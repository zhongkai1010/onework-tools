package com.onework.tools.domain.event;

import com.onework.tools.domain.entity.Entity;
import lombok.Getter;
import org.springframework.context.ApplicationEvent;

import java.time.Clock;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.event
 * @Description: 描述
 * @date Date : 2022年05月30日 14:27
 */

public class EntityApplicationEvent extends ApplicationEvent {

    @Getter
    private Entity entity;

    @Getter
    private OperateType operate;

    public EntityApplicationEvent(Object source, Entity entity, OperateType operate) {
        super(source);
        this.entity = entity;
        this.operate = operate;
    }

    public EntityApplicationEvent(Object source, Clock clock, Entity entity, OperateType operate) {
        super(source, clock);
        this.entity = entity;
        this.operate = operate;
    }

    public EntityApplicationEvent(Object source) {
        super(source);

    }
}
