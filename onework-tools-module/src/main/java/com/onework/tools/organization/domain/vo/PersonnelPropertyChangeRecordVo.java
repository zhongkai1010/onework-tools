package com.onework.tools.organization.domain.vo;

import com.onework.tools.domain.entity.EntityCreatedAndUpdated;
import lombok.Data;

import java.time.LocalDateTime;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月26日 16:59
 */
@Data
public class PersonnelPropertyChangeRecordVo implements EntityCreatedAndUpdated {

    private String uid;

    private String personnelId;

    private String property;

    private String oldValue;

    private String newValue;

    private LocalDateTime created;

    private LocalDateTime updated;
}
