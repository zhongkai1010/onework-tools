package com.onework.tools.modularity.model.domain.repository;

import com.onework.tools.modularity.model.domain.vo.ModelItemVo;
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
    ModelItemVo query(String code);

    /**
     * 添加数据模型项
     *
     * @param modelItem
     */
    void insert(ModelItemVo modelItem);

    /**
     * 修改数据模型项
     *
     * @param modelItem
     */
    void update(ModelItemVo modelItem);

    /**
     * 删除数据模型项
     *
     * @param code
     */
    void delete(String code);
}
