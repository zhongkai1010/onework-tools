package com.onework.tools.dictionary.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.dictionary.domain.vo.DictionaryGroupVo;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.dictionary.domain
 * @Description: 描述
 * @date Date : 2022年06月16日 9:14
 */
@Component
public interface DictionaryGroupDomainService {

    /**
     * 添加字典组
     *
     * @param dictionaryGroup
     * @return
     */
    ExecuteResult<Boolean> addGroup(DictionaryGroupVo dictionaryGroup);

    /**
     * 修改字典组
     *
     * @param dictionaryGroup
     * @return
     */
    ExecuteResult<Boolean> updateGroup(DictionaryGroupVo dictionaryGroup);

    /**
     * 删除字典组
     *
     * @param groupId
     * @return
     */
    ExecuteResult<Boolean> deleteGroup(String groupId);
}
