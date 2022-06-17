package com.onework.tools.authentication.domain.impl;

import cn.hutool.core.bean.BeanUtil;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.authentication.dependent.RoleRemoteService;
import com.onework.tools.authentication.dependent.dto.RoleDto;
import com.onework.tools.authorize.domain.repository.RoleRepository;
import com.onework.tools.authorize.vo.RoleVo;
import org.springframework.stereotype.Service;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.dependent.impl
 * @Description: 描述
 * @date Date : 2022年06月17日 14:45
 */
@Service
public class DefaultRoleRemoteServiceImpl implements RoleRemoteService {

    private final RoleRepository roleRepository;

    public DefaultRoleRemoteServiceImpl(RoleRepository roleRepository) {
        this.roleRepository = roleRepository;
    }

    @Override
    public RoleDto getRole(String roleId) {
        RoleVo roleVo = roleRepository.geRole(roleId);
        Check.notNull(roleVo, new AppException(String.format("get role remote service not find id %s", roleId)));
        return BeanUtil.copyProperties(roleVo, RoleDto.class);
    }
}
