package com.onework.tools.dictionary.domain.repository.impl;

import com.baomidou.mybatisplus.core.toolkit.IdWorker;
import com.onework.tools.dictionary.domain.repository.DictionaryGroupRepository;
import com.onework.tools.dictionary.domain.vo.DictionaryGroupVo;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.dictionary.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:29
 */
@Repository
public class DefaultDictionaryGroupRepository implements DictionaryGroupRepository {

    @Override
    public DictionaryGroupVo getGroupByName(String groupName) {
        return null;
    }

    @Override
    public DictionaryGroupVo getGroup(String groupId) {
        return null;
    }

    @Override
    public void addGroup(DictionaryGroupVo group) {
        group.setUid(IdWorker.getIdStr());
    }

    @Override
    public void updateGroup(DictionaryGroupVo dictionaryGroup) {

    }

    @Override
    public void deleteGroup(String groupId) {

    }
}
