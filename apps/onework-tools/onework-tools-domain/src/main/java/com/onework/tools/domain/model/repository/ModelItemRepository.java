package com.onework.tools.domain.model.repository;

import com.onework.tools.domain.model.entity.ModelItem;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.domain.repository
 * @Description: 描述
 * @date Date : 2022年04月18日 16:22
 */
@Component
public interface ModelItemRepository {

    /**
     * 根据Code获取数据模型
     *
     * @param code
     * @return
     */
    ModelItem query(String code);

    /**
     * 添加数据模型项
     *
     * @param modelItem
     */
    void insert(ModelItem modelItem);

    /**
     * 修改数据模型项
     *
     * @param modelItem
     */
    void update(ModelItem modelItem);

    /**
     * 删除数据模型项
     *
     * @param code
     */
    void delete(String code);
}
