package com.onework.tools.dictionary.domain.impl;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.dictionary.domain.DictionaryItemDomainService;
import com.onework.tools.dictionary.domain.repository.DictionaryGroupRepository;
import com.onework.tools.dictionary.domain.repository.DictionaryItemRepository;
import com.onework.tools.dictionary.domain.repository.DictionarySelectRepository;
import com.onework.tools.dictionary.domain.vo.DictionaryGroupVo;
import com.onework.tools.dictionary.domain.vo.DictionaryItemVo;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.stream.Collectors;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.dictionary.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月25日 16:33
 */
@Service
public class DictionaryDomainServiceImpl implements DictionaryItemDomainService {

    private final DictionaryGroupRepository dictionaryGroupRepository;

    private final DictionaryItemRepository dictionaryItemRepository;

    public DictionaryDomainServiceImpl(DictionaryGroupRepository dictionaryGroupRepository,
        DictionaryItemRepository dictionaryItemRepository, DictionarySelectRepository dictionarySelectRepository) {
        this.dictionaryGroupRepository = dictionaryGroupRepository;
        this.dictionaryItemRepository = dictionaryItemRepository;
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> addItems(String groupId, List<DictionaryItemVo> items) {
        DictionaryGroupVo dbGroup = dictionaryGroupRepository.getGroup(groupId);
        // 获取字典组的自定义，控制字典项不能出现重复
        List<DictionaryItemVo> dbItems = dictionaryItemRepository.getItemByGroup(groupId);
        Map<String, DictionaryItemVo> maps = dbItems.stream()
            .collect(Collectors.toMap(DictionaryItemVo::getValue, dictionaryItemVo -> dictionaryItemVo));
        // 逐步添加字典项
        items.forEach(item -> {
            if (maps.containsKey(item.getValue())) {
                throw new AppException(String.format("batch add dictionary item value %s is repeat", item.getValue()));
            }
            item.setGroupId(groupId);
            dictionaryItemRepository.addItem(item);
        });
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> addItem(DictionaryItemVo item) {
        List<DictionaryItemVo> items = new ArrayList<>();
        items.add(item);
        return addItems(item.getGroupId(), items);
    }

    @Override
    public ExecuteResult<Boolean> updateItem(DictionaryItemVo item) {
        DictionaryItemVo dbItem = dictionaryItemRepository.getItem(item.getUid());
        // 控制无法修改属性
        item.setGroupId(dbItem.getGroupId());
        // 控制字典项值不能出现重复
        if (!Objects.equals(dbItem.getValue(), item.getValue())) {
            dbItem = dictionaryItemRepository.getItem(item.getGroupId(), item.getValue());
            Check.isTrue(dbItem != null, new AppException(""));
        }
        dictionaryItemRepository.updateItem(item);
        return ExecuteResult.success(true);
    }
}
