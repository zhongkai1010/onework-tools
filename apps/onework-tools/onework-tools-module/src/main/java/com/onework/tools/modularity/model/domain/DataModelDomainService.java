package com.onework.tools.modularity.model.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.model.domain.vo.ModelDataVo;
import com.onework.tools.modularity.model.domain.vo.ModelDataBehaviorVo;
import com.onework.tools.modularity.model.domain.vo.ModelDataItemVo;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model.dao
 * @Description: 描述
 * @date Date : 2022年04月18日 15:36
 */
@Component
public interface DataModelDomainService {

    /**
     * 添加数据模型
     *
     * @param modelData
     * @return
     */
    ExecuteResult saveModelData(ModelDataVo modelData);

    /**
     * 添加数据模型
     *
     * @param modelData
     * @param items
     * @param behaviors
     * @param description
     * @return
     */
    ExecuteResult saveModelData(ModelDataVo modelData, List<ModelDataItemVo> items, List<ModelDataBehaviorVo> behaviors,
        String description);

    /**
     * 添加数据模型项
     *
     * @param code
     * @param items
     * @return
     */
    ExecuteResult saveModelDataItems(String code, List<ModelDataItemVo> items);

    /**
     * 添加数据模型行为
     *
     * @param code
     * @param behaviors
     * @return
     */
    ExecuteResult saveModelDataBehaviors(String code, List<ModelDataBehaviorVo> behaviors);

    /**
     * 移除数据模型数据项
     *
     * @param code
     * @return
     */
    ExecuteResult deleteModelData(String code);
}
