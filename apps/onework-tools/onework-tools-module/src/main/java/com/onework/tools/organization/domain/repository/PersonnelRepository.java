package com.onework.tools.organization.domain.repository;

import com.onework.tools.organization.domain.vo.PersonnelPropertyChangeRecordVo;
import com.onework.tools.organization.domain.vo.PersonnelVo;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月27日 9:14
 */
public interface PersonnelRepository {
    void addPersonnel(PersonnelVo personnel);
 
    void addPersonnelProperty(String uid, String k, String v);

    PersonnelVo getPersonnel(String uid);

    void updatePersonnel(PersonnelVo personnel);

    Map<String, String> getPersonnelProperties(String personnelId);

    void updatePersonnelProperty(String personnelId, String extKey, String extValue);

    void addPropertyChangeRecord(PersonnelPropertyChangeRecordVo changeRecord);
}
