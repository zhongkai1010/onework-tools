package com.onework.tools.server.model.repository;

import com.onework.tools.domain.model.dao.ModelItem;
import com.onework.tools.domain.model.repository.ModelItemRepository;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.model.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:50
 */
@Repository
public class ModelItemRepositoryImpl implements ModelItemRepository {

    @Override
    public ModelItem query(String code) {
        return null;
    }

    @Override
    public void insert(ModelItem modelItem) {

    }

    @Override
    public void update(ModelItem modelItem) {

    }

    @Override
    public void delete(String code) {

    }
}
