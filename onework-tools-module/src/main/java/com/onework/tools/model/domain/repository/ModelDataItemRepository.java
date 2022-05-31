package com.onework.tools.model.domain.repository;

import com.onework.tools.model.domain.vo.ModelDataItemVo;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.domain.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 16:11
 */
@Component
public interface ModelDataItemRepository {

    /**
     * 根据数据模型code删除数据模型项
     *
     * @param dataCode
     */
    void deleteModeDataItems(String dataCode);

    /**
     * 根据数据模型code删除添加数据模型项
     *
     * @param items
     */
    void insert(ModelDataItemVo items);
}
