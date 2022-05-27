package com.onework.tools.model.domain.impl;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.model.domain.repository.ModelCollectionRepository;
import com.onework.tools.model.domain.repository.ModelItemRepository;
import com.onework.tools.model.domain.vo.ModelCollectionVo;
import com.onework.tools.model.domain.vo.ModelItemType;
import com.onework.tools.model.domain.vo.ModelItemVo;
import com.onework.tools.model.ModelException;
import com.onework.tools.model.domain.ModelDomainService;
import org.springframework.stereotype.Component;

import java.util.ArrayList;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.domain.model
 * @Description: 描述
 * @date Date : 2022年04月18日 16:14
 */
@Component
public class ModelDomainServiceImpl implements ModelDomainService {

    private final ModelItemRepository modelItemRepository;
    private final ModelCollectionRepository modelCollectionRepository;

    public ModelDomainServiceImpl(ModelItemRepository modelItemRepository,
        ModelCollectionRepository modelCollectionRepository) {
        this.modelItemRepository = modelItemRepository;
        this.modelCollectionRepository = modelCollectionRepository;
    }

    @Override
    public ExecuteResult<ModelItemVo> getModelItem(String code) {

        ModelItemVo modelItem = modelItemRepository.query(code);
        return ExecuteResult.success(modelItem);
    }

    @Override
    public ExecuteResult<ModelItemVo> saveModelItem(String code, String name, ModelItemType type) {

        ModelItemVo modelItem = modelItemRepository.query(code);

        if (modelItem != null) {
            modelItem.setName(name);
            modelItem.setType(type);
            modelItemRepository.update(modelItem);
        } else {
            modelItem = new ModelItemVo();
            modelItem.setCode(code);
            modelItem.setName(name);
            modelItem.setCumulate(0);
            modelItem.setType(type);
            modelItemRepository.insert(modelItem);
        }

        return ExecuteResult.success(modelItem);
    }

    @Override
    public ExecuteResult<Boolean> deleteModel(String code) {

        ModelItemVo modelItem = modelItemRepository.query(code);

        Check.notNull(modelItem, new AppException(ModelException.DELETE_MODEL_NOT_FIND, code));

        Check.isTrue(modelItem.getCumulate() > 0, new AppException(ModelException.DELETE_MODEL_ITEM_USE, code));

        modelItemRepository.delete(code);

        return ExecuteResult.success();
    }

    @Override
    public ExecuteResult<ModelItemVo> linkModelItem(String code, boolean linked) {

        ModelItemVo modelItem = modelItemRepository.query(code);

        Check.notNull(modelItem, new AppException(ModelException.LINKED_MODEL_NOT_FIND, code));

        int cumulate = modelItem.getCumulate();
        if (linked) {
            cumulate += 1;
        } else {
            cumulate -= 1;
        }
        modelItem.setCumulate(cumulate);

        modelItemRepository.update(modelItem);

        return ExecuteResult.success(modelItem);
    }

    @Override
    public ExecuteResult<ModelCollectionVo> saveModelCollection(String code, String name, ArrayList<String> itemCodes,
        String description) {

        ModelCollectionVo modelCollection = modelCollectionRepository.query(code);

        ArrayList<ModelItemVo> modelItems = new ArrayList<>();
        for (String itemCode : itemCodes) {
            ModelItemVo modelItem = modelItemRepository.query(itemCode);
            Check.notNull(modelItem, new AppException(ModelException.ADD_MODEL_COLLECTION_ITEM_NOT_FIND, itemCode));
            modelItems.add(modelItem);
        }

        boolean added = false;
        if (modelCollection == null) {
            modelCollection = new ModelCollectionVo();
            added = true;
        }

        modelCollection.setCode(code);
        modelCollection.setName(name);
        modelCollection.setDescription(description);
        modelCollection.setItems(modelItems);

        if (added) {
            modelCollectionRepository.insert(modelCollection);
        } else {
            modelCollectionRepository.update(modelCollection);
        }

        return ExecuteResult.success(modelCollection);
    }

    @Override
    public ExecuteResult deleteModelCollection(String code) {

        ModelCollectionVo modelCollection = modelCollectionRepository.query(code);

        Check.notNull(modelCollection, new AppException(ModelException.DELETE_MODEL_COLLECTION_EXIST, code));

        modelCollectionRepository.delete(code);

        return ExecuteResult.success();
    }
}
