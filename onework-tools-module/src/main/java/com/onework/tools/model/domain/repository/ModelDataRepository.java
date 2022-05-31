package com.onework.tools.model.domain.repository;

import com.onework.tools.model.domain.vo.ModelDataVo;
import com.onework.tools.model.domain.vo.ModelDataBehaviorVo;
import com.onework.tools.model.domain.vo.ModelDataItemVo;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.domain.repository
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
    ModelDataVo query(String code);

    /**
     * 添加
     *
     * @param modelData
     */
    void insert(ModelDataVo modelData);

    /**
     * 修改
     *
     * @param modelData
     */
    void update(ModelDataVo modelData);

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
    List<ModelDataItemVo> getItems(String dataCode);

    /**
     * 获取数据模型行为集合
     *
     * @param dataCode
     * @return
     */
    List<ModelDataBehaviorVo> getBehaviors(String dataCode);
}
