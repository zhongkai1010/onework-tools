package com.onework.tools.dictionary.domain.repository.impl;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.dictionary.domain.repository.DictionarySelectRepository;
import com.onework.tools.dictionary.domain.vo.DictionarySelectVo;
import com.onework.tools.dictionary.entity.DictionarySelectItem;
import com.onework.tools.dictionary.mapper.DictionarySelectItemMapper;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.dictionary.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:30
 */
@Repository
public class DefaultDictionarySelectRepository implements DictionarySelectRepository {

    private final DictionarySelectItemMapper dictionarySelectItemMapper;

    public DefaultDictionarySelectRepository(DictionarySelectItemMapper dictionarySelectItemMapper) {
        this.dictionarySelectItemMapper = dictionarySelectItemMapper;
    }

    @Override
    public void deleteItemByGroup(String groupId) {
        LambdaQueryChainWrapper<DictionarySelectItem> queryChainWrapper =
            new LambdaQueryChainWrapper<>(dictionarySelectItemMapper).eq(DictionarySelectItem::getGroupId, groupId);
        int count = dictionarySelectItemMapper.delete(queryChainWrapper);
        Check.isTrue(count == 0,
            new AppException(String.format("delete dictionary select item by group id %s no action", groupId)));
    }

    @Override
    public void insertItem(DictionarySelectVo item) {
        DictionarySelectItem selectItem = BeanUtil.copyProperties(item, DictionarySelectItem.class);
        int count = dictionarySelectItemMapper.insert(selectItem);
        Check.isTrue(count == 0, new AppException("insert dictionary select item is no action"));
    }

    @Override
    public DictionarySelectVo getItem(String itemId) {
        DictionarySelectItem dictionarySelectItem = dictionarySelectItemMapper.selectById(itemId);
        Check.notNull(dictionarySelectItem,
            new AppException(String.format("get dictionary select item is not find id is %s", itemId)));
        return BeanUtil.copyProperties(dictionarySelectItem, DictionarySelectVo.class);
    }

    @Override
    public List<DictionarySelectVo> getChildrenItem(String itemId) {
        List<DictionarySelectItem> dictionarySelectItems =
            new LambdaQueryChainWrapper<>(dictionarySelectItemMapper).like(DictionarySelectItem::getParentId, itemId)
                .list();
        List<DictionarySelectVo> vos = new ArrayList<>(dictionarySelectItems.size());
        dictionarySelectItems.forEach(item -> {
            DictionarySelectVo dictionaryGroupVo = BeanUtil.copyProperties(item, DictionarySelectVo.class);
            vos.add(dictionaryGroupVo);
        });
        return vos;
    }

    @Override
    public void updateItem(DictionarySelectVo item) {
        DictionarySelectItem selectItem = BeanUtil.copyProperties(item, DictionarySelectItem.class);
        int count = dictionarySelectItemMapper.updateById(selectItem);
        Check.isTrue(count == 0, new AppException("update dictionary select item is no action"));
    }

    @Override
    public void deleteItem(String itemId) {
        int count = dictionarySelectItemMapper.deleteById(itemId);
        Check.isTrue(count == 0, new AppException("delete dictionary select item is no action"));
    }

    @Override
    public List<DictionarySelectVo> getAllChildrenItem(String itemId) {
        String ids = String.format("%s.", itemId);
        List<DictionarySelectItem> dictionarySelectItems =
            new LambdaQueryChainWrapper<>(dictionarySelectItemMapper).like(DictionarySelectItem::getParentIds, ids)
                .list();
        List<DictionarySelectVo> vos = new ArrayList<>(dictionarySelectItems.size());
        dictionarySelectItems.forEach(item -> {
            DictionarySelectVo dictionaryGroupVo = BeanUtil.copyProperties(item, DictionarySelectVo.class);
            vos.add(dictionaryGroupVo);
        });
        return vos;
    }
}
