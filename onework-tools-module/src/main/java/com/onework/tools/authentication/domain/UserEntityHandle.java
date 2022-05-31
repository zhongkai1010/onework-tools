package com.onework.tools.authentication.domain;

import com.onework.tools.authentication.domain.vo.UserVo;
import com.onework.tools.domain.entity.Entity;
import com.onework.tools.domain.event.EntityApplicationEvent;
import com.onework.tools.domain.event.EntityHandle;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.domain
 * @Description: 描述
 * @date Date : 2022年05月30日 14:57
 */
public class UserEntityHandle implements EntityHandle {

    @Override
    public Boolean isDo(EntityApplicationEvent applicationEvent) {
        Entity entity = applicationEvent.getEntity();
        return entity.getClass().equals(UserVo.class);
    }

    @Override
    public void doHandle(EntityApplicationEvent applicationEvent) {
    }
}
