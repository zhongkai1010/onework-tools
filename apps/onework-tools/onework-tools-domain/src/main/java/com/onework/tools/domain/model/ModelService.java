package com.onework.tools.domain.model;

import com.onework.tools.domain.model.dao.ModelCollection;
import com.onework.tools.domain.model.dao.ModelItem;
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
public interface ModelService {

    /**
     * 数据模型是否存在
     *
     * @param code
     * @return
     */
    boolean existMoldeItem(String code);

    /**
     * 添加数据模型项
     *
     * @param modelItem
     * @return
     */
    ModelItem addMoldeItem(ModelItem modelItem);

    /**
     * 修改数据模型项
     *
     * @param modelItem
     * @return
     */
    ModelItem updateMoldeItem(ModelItem modelItem);

    /**
     * 删除数据模型项
     *
     * @param code
     */
    void deleteMoldeItem(String code);

    /**
     * 增加计数
     *
     * @param code
     */
    void incrementCount(String code);

    /**
     * 减除计数
     *
     * @param code
     */
    void subtractCount(String code);

    /**
     * 添加数据模型项集合
     *
     * @param code
     * @param name
     * @param codes
     * @return
     */
    ModelCollection addModelCollection(String code, String name, ArrayList<String> codes);

    /**
     * 删除数据模型项集合
     *
     * @param code
     */
    void deleteModelCollection(String code);
}
