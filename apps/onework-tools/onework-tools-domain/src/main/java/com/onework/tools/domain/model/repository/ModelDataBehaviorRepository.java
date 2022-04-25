package com.onework.tools.domain.model.repository;

import com.onework.tools.domain.model.entity.ModelDataBehavior;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.domain.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:02
 */
@Component
public interface ModelDataBehaviorRepository {

    /**
     * 根据数据模型code删除数据模型行为
     *
     * @param dataCode
     */
    void deleteModeDataBehaviors(String dataCode);

    /**
     * 根据数据模型code删除数据模型行为
     *
     * @param modelDataBehavior
     */
    void insert(ModelDataBehavior modelDataBehavior);
}
