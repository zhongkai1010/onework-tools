package com.onework.tools.dictionary.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.dictionary.domain.vo.DictionarySelectVo;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.dictionary.domain
 * @Description: 描述
 * @date Date : 2022年06月16日 9:17
 */
@Component
public interface DictionarySelectDomainService {

    /**
     * 添加字典项
     *
     * @param item
     * @return
     */
    ExecuteResult<Boolean> addSelectItem(DictionarySelectVo item);

    /**
     * 修改字典项
     *
     * @param item
     * @return
     */
    ExecuteResult<Boolean> updateSelectItem(DictionarySelectVo item);

    /**
     * 删除字典项
     *
     * @param itemId
     * @return
     */
    ExecuteResult<Boolean> deleteSelectItem(String itemId);
}
