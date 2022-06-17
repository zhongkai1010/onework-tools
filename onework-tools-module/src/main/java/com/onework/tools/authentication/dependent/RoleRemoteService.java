package com.onework.tools.authentication.dependent;

import com.onework.tools.authentication.dependent.dto.RoleDto;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.dependent
 * @Description: 描述
 * @date Date : 2022年06月17日 10:00
 */
@Component
public interface RoleRemoteService {

    /**
     * 根据id获取角色信息
     * @param roleId
     * @return
     */
    RoleDto getRole(String roleId);
}
