package com.onework.tools.server.model.repository;

import com.onework.tools.domain.model.dao.ModelData;
import com.onework.tools.domain.model.dao.ModelDataBehavior;
import com.onework.tools.domain.model.dao.ModelDataItem;
import com.onework.tools.domain.model.repository.ModelDataRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.model.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:51
 */
@Repository
public class ModelDataRepositoryImpl implements ModelDataRepository {

    @Override
    public ModelData query(String code) {
        return null;
    }

    @Override
    public void insert(ModelData modelData) {

    }

    @Override
    public void update(ModelData modelData) {

    }

    @Override
    public void delete(String code) {

    }

    @Override
    public List<ModelDataItem> getItems(String dataCode) {
        return null;
    }

    @Override
    public List<ModelDataBehavior> getBehaviors(String dataCode) {
        return null;
    }
}
