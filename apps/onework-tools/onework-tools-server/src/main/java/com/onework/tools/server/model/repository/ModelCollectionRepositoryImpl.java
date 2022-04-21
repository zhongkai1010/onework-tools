package com.onework.tools.server.model.repository;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.alibaba.fastjson.JSON;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.onework.tools.core.Check;
import com.onework.tools.domain.model.dao.ModelCollection;
import com.onework.tools.domain.model.repository.ModelCollectionRepository;
import com.onework.tools.server.model.ServerModelException;
import com.onework.tools.server.model.ServerModelModule;
import com.onework.tools.server.model.mapper.ModelCollectionMapper;
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

    private final ModelCollectionMapper modelCollectionMapper;

    public ModelCollectionRepositoryImpl(ModelCollectionMapper modelCollectionMapper) {
        this.modelCollectionMapper = modelCollectionMapper;
    }

    @Override
    public ModelCollection query(String code) {

        com.onework.tools.server.model.entity.ModelCollection collection =
            new LambdaQueryChainWrapper<>(modelCollectionMapper).eq(
                com.onework.tools.server.model.entity.ModelCollection::getCode, code).one();
        return BeanUtil.copyProperties(collection, ModelCollection.class);
    }

    @Override
    public ModelCollection insert(ModelCollection modelCollection) {

        com.onework.tools.server.model.entity.ModelCollection collection =
            new com.onework.tools.server.model.entity.ModelCollection();
        CopyOptions copyOptions = new CopyOptions();
        copyOptions.setIgnoreProperties("items");
        BeanUtil.copyProperties(modelCollection, collection, copyOptions);

        String items = JSON.toJSONString(modelCollection.getItems());
        collection.setItems(items);

        int count = modelCollectionMapper.insert(collection);

        Check.isTrue(count == 0, new ServerModelException(ServerModelModule.INSERT_MODEL_COLLECTION_ERROR));

        return modelCollection;
    }

    @Override
    public ModelCollection update(ModelCollection modelCollection) {

        String items = JSON.toJSONString(modelCollection.getItems());

        boolean result = new LambdaUpdateChainWrapper<>(modelCollectionMapper).eq(
                com.onework.tools.server.model.entity.ModelCollection::getCode, modelCollection.getCode())
            .set(com.onework.tools.server.model.entity.ModelCollection::getName, modelCollection.getName())
            .set(com.onework.tools.server.model.entity.ModelCollection::getItems, items)
            .set(com.onework.tools.server.model.entity.ModelCollection::getDescription,
                modelCollection.getDescription()).update();

        Check.isTrue(!result, new ServerModelException(ServerModelModule.UPDATE_MODEL_COLLECTION_ERROR));

        return modelCollection;
    }

    @Override
    public void delete(String code) {

        LambdaQueryChainWrapper<com.onework.tools.server.model.entity.ModelCollection> queryChainWrapper =
            new LambdaQueryChainWrapper<>(modelCollectionMapper).eq(
                com.onework.tools.server.model.entity.ModelCollection::getCode, code);

        int count = modelCollectionMapper.delete(queryChainWrapper);

        Check.isTrue(count == 0, new ServerModelException(ServerModelModule.DELETE_MODEL_COLLECTION_ERROR));
    }
}
