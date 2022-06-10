package com.onework.tools.dictionary.domain.repository.impl;

import com.onework.tools.dictionary.domain.repository.DictionaryItemRepository;
import com.onework.tools.dictionary.domain.vo.DictionaryItemVo;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.dictionary.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:29
 */
@Repository
public class DefaultDictionaryItemRepository implements DictionaryItemRepository {

    @Override
    public void deleteItemByGroup(String groupId) {

    }

    @Override
    public List<DictionaryItemVo> getItemByGroup(String groupId) {
        return null;
    }

    @Override
    public void addItem(DictionaryItemVo dbItem) {

    }

    @Override
    public DictionaryItemVo getItem(String uid) {
        return null;
    }

    @Override
    public DictionaryItemVo getItem(String groupId, String value) {
        return null;
    }

    @Override
    public void updateItem(DictionaryItemVo item) {

    }
}
