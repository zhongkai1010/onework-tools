package com.onework.tools.model.dao.repository;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.onework.tools.core.Check;
import com.onework.tools.model.ModelException;
import com.onework.tools.model.ModelModule;
import com.onework.tools.model.dao.mapper.ModelItemMapper;
import com.onework.tools.model.domain.entity.ModelItem;
import com.onework.tools.model.domain.repository.ModelItemRepository;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.dao.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:50
 */
@Repository
public class ModelItemRepositoryImpl implements ModelItemRepository {

    private final ModelItemMapper modelItemMapper;

    public ModelItemRepositoryImpl(ModelItemMapper modelItemMapper) {
        this.modelItemMapper = modelItemMapper;
    }

    @Override
    public ModelItem query(String code) {
        com.onework.tools.model.dao.entity.ModelItem item =
            new LambdaQueryChainWrapper<>(modelItemMapper).eq(com.onework.tools.model.dao.entity.ModelItem::getCode,
                code).one();
        return BeanUtil.copyProperties(item, ModelItem.class);
    }

    @Override
    public void insert(ModelItem modelItem) {
        com.onework.tools.model.dao.entity.ModelItem item =
            BeanUtil.copyProperties(modelItem, com.onework.tools.model.dao.entity.ModelItem.class);

        int count = modelItemMapper.insert(item);

        Check.isTrue(count == 0, new ModelException(ModelModule.INSERT_MODEL_ITEM_ERROR));
    }

    @Override
    public void update(ModelItem modelItem) {

        boolean result =
            new LambdaUpdateChainWrapper<>(modelItemMapper).eq(com.onework.tools.model.dao.entity.ModelItem::getCode,
                    modelItem.getCode()).set(com.onework.tools.model.dao.entity.ModelItem::getName, modelItem.getName())
                .set(com.onework.tools.model.dao.entity.ModelItem::getType, modelItem.getType())
                .set(com.onework.tools.model.dao.entity.ModelItem::getCumulate, modelItem.getCumulate()).update();

        Check.isTrue(!result, new ModelException(ModelModule.UPDATE_MODEL_ITEM_ERROR));
    }

    @Override
    public void delete(String code) {

        LambdaQueryChainWrapper<com.onework.tools.model.dao.entity.ModelItem> queryChainWrapper =
            new LambdaQueryChainWrapper<>(modelItemMapper).eq(com.onework.tools.model.dao.entity.ModelItem::getCode,
                code);

        int count = modelItemMapper.delete(queryChainWrapper);

        Check.isTrue(count == 0, new ModelException(ModelModule.DELETE_MODEL_ITEM_ERROR));
    }
}
