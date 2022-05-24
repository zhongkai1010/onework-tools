package com.onework.tools.modularity.model.domain.repository.imlp;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.modularity.model.ModelException;
import com.onework.tools.modularity.model.domain.repository.ModelItemRepository;
import com.onework.tools.modularity.model.domain.vo.ModelItemVo;
import com.onework.tools.modularity.model.entity.ModelItem;
import com.onework.tools.modularity.model.mapper.ModelItemMapper;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.repository
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
    public ModelItemVo query(String code) {
        ModelItem item = new LambdaQueryChainWrapper<>(modelItemMapper).eq(
           ModelItem::getCode, code).one();
        return BeanUtil.copyProperties(item, ModelItemVo.class);
    }

    @Override
    public void insert(ModelItemVo modelItem) {
        ModelItem item = BeanUtil.copyProperties(modelItem,
            ModelItem.class);

        int count = modelItemMapper.insert(item);

        Check.isTrue(count == 0, new AppException(ModelException.INSERT_MODEL_ITEM_ERROR));
    }

    @Override
    public void update(ModelItemVo modelItem) {

        boolean result = new LambdaUpdateChainWrapper<>(modelItemMapper).eq(
                ModelItem::getCode, modelItem.getCode())
            .set(ModelItem::getName, modelItem.getName())
            .set(ModelItem::getType, modelItem.getType())
            .set(ModelItem::getCumulate, modelItem.getCumulate()).update();

        Check.isTrue(!result, new AppException(ModelException.UPDATE_MODEL_ITEM_ERROR));
    }

    @Override
    public void delete(String code) {

        LambdaQueryChainWrapper<ModelItem> queryChainWrapper
            = new LambdaQueryChainWrapper<>(modelItemMapper).eq(ModelItem::getCode,
            code);

        int count = modelItemMapper.delete(queryChainWrapper);

        Check.isTrue(count == 0, new AppException(ModelException.DELETE_MODEL_ITEM_ERROR));
    }
}
