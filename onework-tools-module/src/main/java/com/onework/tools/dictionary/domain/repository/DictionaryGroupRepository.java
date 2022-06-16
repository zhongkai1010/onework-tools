package com.onework.tools.dictionary.domain.repository;

import com.onework.tools.dictionary.domain.vo.DictionaryGroupVo;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月25日 16:35
 */
public interface DictionaryGroupRepository {

    /**
     * 根据code检索字典组
     *
     * @param code
     * @return
     */
    DictionaryGroupVo findGroupByCode(String code);

    /**
     * 根据id获取字典组
     *
     * @param groupId
     * @return
     */
    DictionaryGroupVo getGroup(String groupId);

    /**
     * 添加字典组
     *
     * @param group
     */
    void insertGroup(DictionaryGroupVo group);

    /**
     * 更新字典组
     *
     * @param dictionaryGroup
     */
    void updateGroup(DictionaryGroupVo dictionaryGroup);

    /**
     * 删除字典组
     *
     * @param groupId
     */
    void deleteGroup(String groupId);

    /**
     * 获取指定id的所有子集
     *
     * @param id
     * @return
     */
    List<DictionaryGroupVo> getAllGroupChildren(String id);
}
