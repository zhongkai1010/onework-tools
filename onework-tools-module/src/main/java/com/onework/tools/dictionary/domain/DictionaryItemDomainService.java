package com.onework.tools.dictionary.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.dictionary.domain.vo.DictionaryItemVo;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain
 * @Description: 描述
 * @date Date : 2022年05月25日 15:47
 */
@Component
public interface DictionaryItemDomainService {

    /**
     * 添加字典组
     *
     * @param groupId
     * @param items
     * @return
     */
    ExecuteResult<Boolean> addItems(String groupId, List<DictionaryItemVo> items);

    /**
     * 添加字典项
     *
     * @param item
     * @return
     */
    ExecuteResult<Boolean> addItem(DictionaryItemVo item);

    /**
     * 修改字典项
     *
     * @param item
     * @return
     */
    ExecuteResult<Boolean> updateItem(DictionaryItemVo item);
}
