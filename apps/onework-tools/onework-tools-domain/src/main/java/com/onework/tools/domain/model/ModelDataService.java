package com.onework.tools.domain.model;

import com.onework.tools.domain.model.dao.ModelDataBehavior;
import com.onework.tools.domain.model.dao.ModelItem;
import org.springframework.stereotype.Component;

import java.util.ArrayList;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model.dao
 * @Description: 描述
 * @date Date : 2022年04月18日 15:36
 */
@Component
public interface ModelDataService {

    /**
     * 添加数据模型
     *
     * @param code
     * @param name
     * @param items
     * @param behaviors
     */
    void addModelData(String code, String name, ArrayList<ModelItem> items, ArrayList<ModelDataBehavior> behaviors);

    /**
     * 移除数据模型数据项
     *
     * @param modelDataCode
     * @param itemCode
     */
    void removeModelDataItem(String modelDataCode, String itemCode);

    /**
     * 新增数据模型数据项
     *
     * @param modelDataCode
     * @param itemCode
     */
    void addModelDataItem(String modelDataCode, String itemCode);
}
