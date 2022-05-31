package com.onework.tools.organization.domain.vo;

import com.onework.tools.domain.entity.Entity;
import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.vo
 * @Description: 描述
 * @date Date : 2022年05月27日 10:54
 */
@Data
public class PersonnelChangeRecordVo implements Entity {

    private String uid;
    private PersonnelChangeType type;
    private String personnelId;
    private String oldValue;
    private String newValue;
}
