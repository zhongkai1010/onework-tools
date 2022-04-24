package com.onework.tools.model.dao.repository;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.onework.tools.core.Check;
import com.onework.tools.core.error.AppException;
import com.onework.tools.model.ModelException;
import com.onework.tools.model.ModelModule;
import com.onework.tools.model.dao.mapper.ModelDataItemMapper;
import com.onework.tools.model.domain.entity.ModelDataItem;
import com.onework.tools.model.domain.repository.ModelDataItemRepository;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.model.dao.repository
 * @Description: 描述
 * @date Date : 2022年04月20日 17:51
 */
@Repository
public class ModelDataItemRepositoryImpl implements ModelDataItemRepository {

    private final ModelDataItemMapper modelDataItemMapper;

    public ModelDataItemRepositoryImpl(ModelDataItemMapper modelDataItemMapper) {
        this.modelDataItemMapper = modelDataItemMapper;
    }

    @Override
    public void deleteModeDataItems(String dataCode) {
        LambdaQueryWrapper<com.onework.tools.model.dao.entity.ModelDataItem> lambdaQueryWrapper =
            new LambdaQueryWrapper<>();
        lambdaQueryWrapper.eq(com.onework.tools.model.dao.entity.ModelDataItem::getDataCode, dataCode);
        modelDataItemMapper.delete(lambdaQueryWrapper);
    }

    @Override
    public void insert(ModelDataItem items) {
        com.onework.tools.model.dao.entity.ModelDataItem item =
            BeanUtil.copyProperties(items, com.onework.tools.model.dao.entity.ModelDataItem.class);
        int count = modelDataItemMapper.insert(item);
        Check.isTrue(count == 0, new AppException(ModelException.INSERT_MODEL_DATA_ITEM_ERROR));
    }
}
