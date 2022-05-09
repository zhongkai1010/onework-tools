package com.onework.tools.message;

import com.onework.tools.identity.domain.UserAccountApplicationEvent;
import org.springframework.context.ApplicationListener;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.message
 * @Description: 描述
 * @date Date : 2022年05月09日 10:37
 */
public class UserAccountMessageListener implements ApplicationListener<UserAccountApplicationEvent> {

    @Override
    public void onApplicationEvent(UserAccountApplicationEvent event) {
        System.out.println(event);
    }
}
