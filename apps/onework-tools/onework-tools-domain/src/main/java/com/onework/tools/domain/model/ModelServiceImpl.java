package com.onework.tools.domain.model;

import cn.hutool.core.bean.BeanUtil;
import com.onework.tools.domain.model.dao.ModelCollection;
import com.onework.tools.domain.model.dao.ModelItem;
import com.onework.tools.domain.model.repository.ModelItemRepository;
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
public class ModelServiceImpl implements ModelService {

    private final ModelItemRepository modelItemRepository;

    public ModelServiceImpl(ModelItemRepository modelItemRepository) {
        this.modelItemRepository = modelItemRepository;
    }

    @Override
    public boolean existMoldeItem(String code) {

        ModelItem modelItem = modelItemRepository.getModelItemByCode(code);
        return modelItem != null;
    }

    @Override
    public ModelItem addMoldeItem(ModelItem modelItem) {
        ModelItem oldModelItem = modelItemRepository.getModelItemByCode(modelItem.getCode());
        if (oldModelItem != null) {
            throw new DomainModelException("");
        }
        modelItemRepository.insert(modelItem);
        return modelItem;
    }

    @Override
    public ModelItem updateMoldeItem(ModelItem modelItem) {
        ModelItem oldModelItem = modelItemRepository.getModelItemByCode(modelItem.getCode());
        if (oldModelItem != null) {
            throw new DomainModelException("");
        }
        BeanUtil.copyProperties(modelItem, oldModelItem);
        modelItemRepository.update(oldModelItem);
        return modelItem;
    }

    @Override
    public void deleteMoldeItem(String code) {
        ModelItem oldModelItem = modelItemRepository.getModelItemByCode(code);
        if (oldModelItem == null) {
            throw new DomainModelException("");
        }
        modelItemRepository.deleteModelItem(code);
    }

    @Override
    public void incrementCount(String code) {

    }

    @Override
    public void subtractCount(String code) {

    }

    @Override
    public ModelCollection addModelCollection(String code, String name, ArrayList<String> codes) {
        return null;
    }

    @Override
    public void deleteModelCollection(String code) {

    }
}
