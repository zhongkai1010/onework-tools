package com.onework.tools.model.domain.repository;

import com.onework.tools.model.domain.vo.ModelCollectionVo;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.domain.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 11:12
 */
@Component
public interface ModelCollectionRepository {

    /**
     * 根据Code获取数据模型
     *
     * @param code
     * @return
     */
    ModelCollectionVo query(String code);

    /**
     * 添加数据项集合
     *
     * @param modelCollection
     * @return
     */
    ModelCollectionVo insert(ModelCollectionVo modelCollection);

    /**
     * 修改数据项集合
     *
     * @param modelCollection
     * @return
     */
    ModelCollectionVo update(ModelCollectionVo modelCollection);

    /**
     * 删除数据项集合
     *
     * @param code
     */
    void delete(String code);
}
