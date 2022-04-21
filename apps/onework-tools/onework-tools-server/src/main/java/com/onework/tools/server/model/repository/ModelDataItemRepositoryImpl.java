package com.onework.tools.server.model.repository;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.onework.tools.core.Check;
import com.onework.tools.domain.model.dao.ModelDataItem;
import com.onework.tools.domain.model.repository.ModelDataItemRepository;
import com.onework.tools.server.model.ServerModelException;
import com.onework.tools.server.model.ServerModelModule;
import com.onework.tools.server.model.mapper.ModelDataItemMapper;
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
public class ModelDataItemRepositoryImpl implements ModelDataItemRepository {

    private final ModelDataItemMapper modelDataItemMapper;

    public ModelDataItemRepositoryImpl(ModelDataItemMapper modelDataItemMapper) {
        this.modelDataItemMapper = modelDataItemMapper;
    }

    @Override
    public void deleteModeDataItems(String dataCode) {
        LambdaQueryWrapper<com.onework.tools.server.model.entity.ModelDataItem> lambdaQueryWrapper =
            new LambdaQueryWrapper<>();
        lambdaQueryWrapper.eq(com.onework.tools.server.model.entity.ModelDataItem::getDataCode, dataCode);
        modelDataItemMapper.delete(lambdaQueryWrapper);
    }

    @Override
    public void insert(ModelDataItem items) {
        com.onework.tools.server.model.entity.ModelDataItem item =
            BeanUtil.copyProperties(items, com.onework.tools.server.model.entity.ModelDataItem.class);
        int count = modelDataItemMapper.insert(item);
        Check.isTrue(count == 0, new ServerModelException(ServerModelModule.INSERT_MODEL_DATA_ITEM_ERROR));
    }
}
