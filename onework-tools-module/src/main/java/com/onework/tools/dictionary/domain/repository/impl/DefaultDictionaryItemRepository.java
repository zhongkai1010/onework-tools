package com.onework.tools.dictionary.domain.repository.impl;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.dictionary.domain.repository.DictionaryItemRepository;
import com.onework.tools.dictionary.domain.vo.DictionaryItemVo;
import com.onework.tools.dictionary.entity.DictionaryItem;
import com.onework.tools.dictionary.mapper.DictionaryItemMapper;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.dictionary.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:29
 */
@Repository
public class DefaultDictionaryItemRepository implements DictionaryItemRepository {

    private final DictionaryItemMapper dictionaryItemMapper;

    public DefaultDictionaryItemRepository(DictionaryItemMapper dictionaryItemMapper) {
        this.dictionaryItemMapper = dictionaryItemMapper;
    }

    @Override
    public void deleteItemByGroup(String groupId) {
        LambdaQueryChainWrapper<DictionaryItem> wrapper =
            new LambdaQueryChainWrapper<>(dictionaryItemMapper).eq(DictionaryItem::getGroupId, groupId);
        int count = dictionaryItemMapper.delete(wrapper);
        Check.isTrue(count == 0,
            new AppException(String.format("delete dictionary item by group id %s no action", groupId)));
    }

    @Override
    public List<DictionaryItemVo> getItemByGroup(String groupId) {
        List<DictionaryItem> dictionaryItems =
            new LambdaQueryChainWrapper<>(dictionaryItemMapper).eq(DictionaryItem::getGroupId, groupId).list();
        List<DictionaryItemVo> dictionaryItemVos = new ArrayList<>();
        dictionaryItems.forEach(dictionaryItem -> BeanUtil.copyProperties(dictionaryItem, DictionaryItemVo.class));
        return dictionaryItemVos;
    }

    @Override
    public void addItem(DictionaryItemVo item) {
        DictionaryItem dictionaryItem = BeanUtil.copyProperties(item, DictionaryItem.class);
        int count = dictionaryItemMapper.insert(dictionaryItem);
        Check.isTrue(count == 0, new AppException("insert dictionary item is no action"));
    }

    @Override
    public DictionaryItemVo getItem(String id) {
        DictionaryItem dictionaryItem = dictionaryItemMapper.selectById(id);
        Check.notNull(dictionaryItem, new AppException(String.format("get dictionary item is not find id is %s", id)));
        return BeanUtil.copyProperties(dictionaryItem, DictionaryItemVo.class);
    }

    @Override
    public DictionaryItemVo getItem(String groupId, String value) {
        DictionaryItem dictionaryItem =
            new LambdaQueryChainWrapper<>(dictionaryItemMapper).eq(DictionaryItem::getGroupId, groupId)
                .eq(DictionaryItem::getValue, value).one();
        Check.notNull(dictionaryItem, new AppException(
            String.format("get dictionary item is not find group id is %s value is %s", groupId, value)));
        return BeanUtil.copyProperties(dictionaryItem, DictionaryItemVo.class);
    }

    @Override
    public void updateItem(DictionaryItemVo item) {
        DictionaryItem dictionaryItem = BeanUtil.copyProperties(item, DictionaryItem.class);
        int count = dictionaryItemMapper.updateById(dictionaryItem);
        Check.isTrue(count == 0, new AppException("update dictionary item is no action"));
    }
}
