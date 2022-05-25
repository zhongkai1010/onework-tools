package com.onework.tools.modularity.dictionary.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.dictionary.domain.vo.DictionaryGroupVo;
import com.onework.tools.modularity.dictionary.domain.vo.DictionaryItemVo;
import com.onework.tools.modularity.dictionary.domain.vo.DictionarySelectVo;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain
 * @Description: 描述
 * @date Date : 2022年05月25日 15:47
 */
public interface DictionaryDomainService {

    /**
     * 添加字典组
     *
     * @param dictionaryGroup
     * @return
     */
    ExecuteResult<Boolean> addDictionaryGroup(DictionaryGroupVo dictionaryGroup);

    /**
     * 修改字典组
     *
     * @param dictionaryGroup
     * @return
     */
    ExecuteResult<Boolean> updateDictionaryGroup(DictionaryGroupVo dictionaryGroup);

    /**
     * 删除字典组
     *
     * @param groupId
     * @return
     */
    ExecuteResult<Boolean> deleteDictionaryGroup(String groupId);

    /**
     * 添加字典组
     *
     * @param groupId
     * @param items
     * @return
     */
    ExecuteResult<Boolean> addDictionaryGroupItems(String groupId, List<DictionaryItemVo> items);

    /**
     * 添加字典项
     *
     * @param item
     * @return
     */
    ExecuteResult<Boolean> addDictionaryItem(DictionaryItemVo item);

    /**
     * 修改字典项
     *
     * @param item
     * @return
     */
    ExecuteResult<Boolean> updateDictionaryItem(DictionaryItemVo item);

    /**
     * 添加字典项
     *
     * @param item
     * @return
     */
    ExecuteResult<Boolean> addDictionarySelect(DictionarySelectVo item);

    /**
     * 修改字典项
     *
     * @param item
     * @return
     */
    ExecuteResult<Boolean> updateDictionarySelect(DictionarySelectVo item);

    /**
     * 删除字典项
     *
     * @param itemId
     * @return
     */
    ExecuteResult<Boolean> deleteDictionarySelect(String itemId);
}
