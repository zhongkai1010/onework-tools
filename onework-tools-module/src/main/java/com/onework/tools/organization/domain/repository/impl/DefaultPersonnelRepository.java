package com.onework.tools.organization.domain.repository.impl;

import com.onework.tools.organization.domain.repository.PersonnelRepository;
import com.onework.tools.organization.domain.vo.PersonnelPropertyChangeRecordVo;
import com.onework.tools.organization.domain.vo.PersonnelVo;
import org.springframework.stereotype.Repository;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.organization.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:43
 */
@Repository
public class DefaultPersonnelRepository implements PersonnelRepository {
    @Override
    public void addPersonnel(PersonnelVo personnel) {

    }

    @Override
    public void addPersonnelProperty(String uid, String k, String v) {

    }

    @Override
    public PersonnelVo getPersonnel(String uid) {
        return null;
    }

    @Override
    public void updatePersonnel(PersonnelVo personnel) {

    }

    @Override
    public Map<String, String> getPersonnelProperties(String personnelId) {
        return null;
    }

    @Override
    public void updatePersonnelProperty(String personnelId, String extKey, String extValue) {

    }

    @Override
    public void addPropertyChangeRecord(PersonnelPropertyChangeRecordVo changeRecord) {

    }
}
