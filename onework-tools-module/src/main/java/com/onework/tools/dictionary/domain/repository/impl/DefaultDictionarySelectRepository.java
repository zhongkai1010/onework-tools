package com.onework.tools.dictionary.domain.repository.impl;

import com.onework.tools.dictionary.domain.repository.DictionarySelectRepository;
import com.onework.tools.dictionary.domain.vo.DictionarySelectVo;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.dictionary.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:30
 */
@Repository
public class DefaultDictionarySelectRepository implements DictionarySelectRepository {

    @Override
    public void deleteItemByGroup(String groupId) {

    }

    @Override
    public void addItem(DictionarySelectVo item) {

    }

    @Override
    public DictionarySelectVo getItem(String id) {
        return null;
    }

    @Override
    public List<DictionarySelectVo> getChildrenItem(String uid) {
        return null;
    }

    @Override
    public void updateItem(DictionarySelectVo item) {

    }

    @Override
    public void deleteItem(String uid) {

    }
}
