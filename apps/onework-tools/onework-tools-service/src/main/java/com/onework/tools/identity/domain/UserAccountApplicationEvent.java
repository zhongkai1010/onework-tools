package com.onework.tools.identity.domain;

import org.springframework.context.ApplicationEvent;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.identity.domain
 * @Description: 描述
 * @date Date : 2022年05月09日 10:29
 */

public class UserAccountApplicationEvent extends ApplicationEvent {

    public UserAccountApplicationEvent(Object data) {
        super(data);
    }
}
