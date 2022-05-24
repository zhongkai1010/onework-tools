package com.onework.tools.modularity.model.domain;

import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.model.domain.vo.ModelCollectionVo;
import com.onework.tools.modularity.model.domain.vo.ModelItemType;
import com.onework.tools.modularity.model.domain.vo.ModelItemVo;
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
    ExecuteResult<ModelItemVo> getModelItem(String code);

    /**
     * 添加数据模型项
     *
     * @param code
     * @param name
     * @param type
     * @return
     */
    ExecuteResult<ModelItemVo> saveModelItem(String code, String name, ModelItemType type);

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
    ExecuteResult<ModelCollectionVo> saveModelCollection(String code, String name, ArrayList<String> itemCode,
        String description);

    /**
     * 删除数据模型项集合
     *
     * @param code
     * @return
     */
    ExecuteResult deleteModelCollection(String code);
}
