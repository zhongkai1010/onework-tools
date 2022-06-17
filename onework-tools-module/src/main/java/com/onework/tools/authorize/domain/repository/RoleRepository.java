package com.onework.tools.authorize.domain.repository;
import com.onework.tools.authorize.vo.RoleVo;
/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authorize.domain.repository
 * @Description: 描述
 * @date Date : 2022年06月17日 14:46
 */
public interface RoleRepository {
    RoleVo geRole(String roleId);
}
