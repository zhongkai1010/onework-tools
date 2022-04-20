package com.onework.tools.server.model.repository;

import com.onework.tools.domain.model.dao.ModelCollection;
import com.onework.tools.domain.model.repository.ModelCollectionRepository;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.server.model.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:51
 */
@Repository
public class ModelCollectionRepositoryImpl implements ModelCollectionRepository {

    @Override
    public ModelCollection query(String code) {
        return null;
    }

    @Override
    public ModelCollection insert(ModelCollection modelCollection) {
        return null;
    }

    @Override
    public ModelCollection update(ModelCollection modelCollection) {
        return null;
    }

    @Override
    public void delete(String code) {

    }
}
