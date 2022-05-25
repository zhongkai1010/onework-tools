package com.onework.tools.modularity.dictionary.domain.repository;

import com.onework.tools.modularity.dictionary.domain.vo.DictionaryGroupVo;

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
     * 根据name获取字典组
     *
     * @param groupName
     * @return
     */
    DictionaryGroupVo getGroupByName(String groupName);

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
    void addGroup(DictionaryGroupVo group);

    /**
     * 更新字典组
     * @param dictionaryGroup
     */
    void updateGroup(DictionaryGroupVo dictionaryGroup);

    /**
     * 删除字典组
     * @param groupId
     */
    void deleteGroup(String groupId);
}
