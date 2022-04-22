package com.onework.tools.model.domain;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.model.domain.entity.ModelData;
import com.onework.tools.model.domain.entity.ModelDataBehavior;
import com.onework.tools.model.domain.entity.ModelDataItem;
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
public interface DataModelService {

    /**
     * 添加数据模型
     *
     * @param modelData
     * @return
     */
    ExecuteResult saveModelData(ModelData modelData);

    /**
     * 添加数据模型
     *
     * @param modelData
     * @param items
     * @param behaviors
     * @param description
     * @return
     */
    ExecuteResult saveModelData(ModelData modelData, List<ModelDataItem> items, List<ModelDataBehavior> behaviors,
        String description);

    /**
     * 添加数据模型项
     *
     * @param code
     * @param items
     * @return
     */
    ExecuteResult saveModelDataItems(String code, List<ModelDataItem> items);

    /**
     * 添加数据模型行为
     *
     * @param code
     * @param behaviors
     * @return
     */
    ExecuteResult saveModelDataBehaviors(String code, List<ModelDataBehavior> behaviors);

    /**
     * 移除数据模型数据项
     *
     * @param code
     * @return
     */
    ExecuteResult deleteModelData(String code);
}
