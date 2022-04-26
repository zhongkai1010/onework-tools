package com.onework.tools.model.domain;

import com.onework.tools.core.ExecuteResult;
import com.onework.tools.model.domain.vo.ModelCollection;
import com.onework.tools.model.domain.vo.ModelItem;
import com.onework.tools.model.domain.vo.ModelItemType;
import org.springframework.stereotype.Component;

import java.util.ArrayList;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model
 * @Description: 描述
 * @date Date : 2022年04月18日 15:36
 */
@Component
public interface ModelDomainService {

    /**
     * 数据模型是否存在
     *
     * @param code
     * @return
     */
    ExecuteResult<ModelItem> getModelItem(String code);

    /**
     * 添加数据模型项
     *
     * @param code
     * @param name
     * @param type
     * @return
     */
    ExecuteResult<ModelItem> saveModelItem(String code, String name, ModelItemType type);

    /**
     * 删除数据模型项
     *
     * @param code
     * @return
     */
    ExecuteResult deleteModel(String code);

    /**
     * 添加关联或取消关联计数
     *
     * @param code
     * @param linked
     * @return
     */
    ExecuteResult linkModelItem(String code, boolean linked);

    /**
     * 添加数据模型项集合
     *
     * @param code
     * @param name
     * @param itemCode
     * @param description
     * @return
     */
    ExecuteResult<ModelCollection> saveModelCollection(String code, String name, ArrayList<String> itemCode,
        String description);

    /**
     * 删除数据模型项集合
     *
     * @param code
     * @return
     */
    ExecuteResult deleteModelCollection(String code);
}
