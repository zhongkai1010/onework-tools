package com.onework.tools.dictionary.domain.repository;

import com.onework.tools.dictionary.domain.vo.DictionarySelectVo;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月25日 16:49
 */
@Component
public interface DictionarySelectRepository {
    /**
     * 根据字典组id删除字典项
     *
     * @param groupId
     */
    void deleteItemByGroup(String groupId);

    /**
     * 添加字典项
     *
     * @param item
     */
    void addItem(DictionarySelectVo item);

    /**
     * 根据字典项id查询字典项
     *
     * @param id
     * @return
     */
    DictionarySelectVo getItem(String id);

    /**
     * 查询字典项id下的字典项
     *
     * @param uid
     * @return
     */
    List<DictionarySelectVo> getChildrenItem(String uid);

    /**
     * 更新字典项
     *
     * @param item
     */
    void updateItem(DictionarySelectVo item);

    /**
     * 删除字典项
     *
     * @param uid
     */
    void deleteItem(String uid);
}
