package com.onework.tools.modularity.dictionary.domain.repository;

import com.onework.tools.modularity.dictionary.domain.vo.DictionaryItemVo;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月25日 16:48
 */
@Component
public interface DictionaryItemRepository {
    /**
     * 根据字典组id删除字典项
     *
     * @param groupId
     */
    void deleteItemByGroup(String groupId);

    /**
     * 根据字典组id查询字典项
     *
     * @param groupId
     * @return
     */
    List<DictionaryItemVo> getItemByGroup(String groupId);

    /**
     * 添加字典项
     *
     * @param dbItem
     */
    void addItem(DictionaryItemVo dbItem);

    /**
     * 根据id查询字典项，无数据则返回null
     *
     * @param uid
     * @return
     */
    DictionaryItemVo getItem(String uid);

    /**
     * 根据字典组id和value值查询字典项，无数据则返回null
     *
     * @param groupId
     * @param value
     * @return
     */
    DictionaryItemVo getItem(String groupId, String value);

    /**
     * 更新字典项
     *
     * @param item
     */
    void updateItem(DictionaryItemVo item);
}
