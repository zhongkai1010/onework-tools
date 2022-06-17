package com.onework.tools.authentication.domain.impl;

import cn.hutool.core.bean.BeanUtil;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.authentication.dependent.OrganizationRemoteService;
import com.onework.tools.authentication.dependent.dto.PersonnelDto;
import com.onework.tools.organization.domain.repository.PersonnelRepository;
import com.onework.tools.organization.domain.vo.PersonnelVo;
import org.springframework.stereotype.Service;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.dependent.impl
 * @Description: 描述
 * @date Date : 2022年06月17日 14:42
 */
@Service
public class DefaultOrganizationRemoteServiceImpl implements OrganizationRemoteService {

    private final PersonnelRepository personnelRepository;

    public DefaultOrganizationRemoteServiceImpl(PersonnelRepository personnelRepository) {
        this.personnelRepository = personnelRepository;
    }

    @Override
    public PersonnelDto getPersonnel(String personnelId) {
        PersonnelVo personnelVo = personnelRepository.getPersonnel(personnelId);
        Check.notNull(personnelVo,
            new AppException(String.format("get personnel remote service not find id %s", personnelId)));
        return BeanUtil.copyProperties(personnelVo, PersonnelDto.class);
    }
}
