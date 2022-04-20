package com.onework.tools.domain.model.repository;

import com.onework.tools.domain.model.dao.ModelData;
import com.onework.tools.domain.model.dao.ModelDataBehavior;
import com.onework.tools.domain.model.dao.ModelDataItem;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 15:55
 */
@Component
public interface ModelDataRepository {

    /**
     * 根据Code获取数据模型
     *
     * @param code
     * @return
     */
    ModelData query(String code);

    /**
     * 添加
     *
     * @param modelData
     */
    void insert(ModelData modelData);

    /**
     * 修改
     *
     * @param modelData
     */
    void update(ModelData modelData);

    /**
     * 删除
     *
     * @param code
     */
    void delete(String code);

    /**
     * 获取数据模型数据项集合
     *
     * @param dataCode
     * @return
     */
    List<ModelDataItem> getItems(String dataCode);

    /**
     * 获取数据模型行为集合
     *
     * @param dataCode
     * @return
     */
    List<ModelDataBehavior> getBehaviors(String dataCode);
}
