package com.onework.tools.modularity.model.domain.repository.imlp;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.bean.copier.CopyOptions;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.modularity.model.ModelException;
import com.onework.tools.modularity.model.domain.repository.ModelCollectionRepository;
import com.onework.tools.modularity.model.domain.vo.ModelCollectionVo;
import com.onework.tools.modularity.model.entity.ModelCollection;
import com.onework.tools.modularity.model.mapper.ModelCollectionMapper;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.repository
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
    public ModelCollectionVo query(String code) {

        ModelCollection collection =
            new LambdaQueryChainWrapper<>(modelCollectionMapper).eq(ModelCollection::getCode, code).one();
        return BeanUtil.copyProperties(collection, ModelCollectionVo.class);
    }

    @Override
    public ModelCollectionVo insert(ModelCollectionVo modelCollection) {

        ModelCollection collection = new ModelCollection();
        CopyOptions copyOptions = new CopyOptions();
        copyOptions.setIgnoreProperties("items");
        BeanUtil.copyProperties(modelCollection, collection, copyOptions);
        ObjectMapper objectMapper = new ObjectMapper();

        String items = null;
        try {
            items = objectMapper.writeValueAsString(modelCollection.getItems());
        } catch (JsonProcessingException e) {
            items = null;
        }
        collection.setItems(items);

        int count = modelCollectionMapper.insert(collection);

        Check.isTrue(count == 0, new AppException(ModelException.INSERT_MODEL_COLLECTION_ERROR));

        return modelCollection;
    }

    @Override
    public ModelCollectionVo update(ModelCollectionVo modelCollection) {

        String items = null;
        ObjectMapper objectMapper = new ObjectMapper();
        try {
            items = objectMapper.writeValueAsString(modelCollection.getItems());
        } catch (JsonProcessingException e) {
            items = null;
        }
        boolean result = new LambdaUpdateChainWrapper<>(modelCollectionMapper).eq(ModelCollection::getCode,
                modelCollection.getCode()).set(ModelCollection::getName, modelCollection.getName())
            .set(ModelCollection::getItems, items)
            .set(ModelCollection::getDescription, modelCollection.getDescription()).update();

        Check.isTrue(!result, new AppException(ModelException.UPDATE_MODEL_COLLECTION_ERROR));

        return modelCollection;
    }

    @Override
    public void delete(String code) {

        LambdaQueryChainWrapper<ModelCollection> queryChainWrapper =
            new LambdaQueryChainWrapper<>(modelCollectionMapper).eq(ModelCollection::getCode, code);

        int count = modelCollectionMapper.delete(queryChainWrapper);

        Check.isTrue(count == 0, new AppException(ModelException.DELETE_MODEL_COLLECTION_ERROR));
    }
}
