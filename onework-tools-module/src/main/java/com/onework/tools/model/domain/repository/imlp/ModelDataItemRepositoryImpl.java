package com.onework.tools.model.domain.repository.imlp;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.model.entity.ModelDataItem;
import com.onework.tools.model.mapper.ModelDataItemMapper;
import com.onework.tools.model.ModelException;
import com.onework.tools.model.domain.repository.ModelDataItemRepository;
import com.onework.tools.model.domain.vo.ModelDataItemVo;
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
public class ModelDataItemRepositoryImpl implements ModelDataItemRepository {

    private final ModelDataItemMapper modelDataItemMapper;

    public ModelDataItemRepositoryImpl(ModelDataItemMapper modelDataItemMapper) {
        this.modelDataItemMapper = modelDataItemMapper;
    }

    @Override
    public void deleteModeDataItems(String dataCode) {
        LambdaQueryWrapper<ModelDataItem> lambdaQueryWrapper
            = new LambdaQueryWrapper<>();
        lambdaQueryWrapper.eq(ModelDataItem::getDataCode, dataCode);
        modelDataItemMapper.delete(lambdaQueryWrapper);
    }

    @Override
    public void insert(ModelDataItemVo items) {
        ModelDataItem item = BeanUtil.copyProperties(items,
            ModelDataItem.class);
        int count = modelDataItemMapper.insert(item);
        Check.isTrue(count == 0, new AppException(ModelException.INSERT_MODEL_DATA_ITEM_ERROR));
    }
}
