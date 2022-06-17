package com.onework.tools.authentication.dependent;

import com.onework.tools.authentication.dependent.dto.PersonnelDto;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.authentication.dependent
 * @Description: 描述
 * @date Date : 2022年06月17日 10:01
 */
@Component
public interface OrganizationRemoteService {

    /**
     * @param personnelId
     * @return
     */
    PersonnelDto getPersonnel(String personnelId);
}
