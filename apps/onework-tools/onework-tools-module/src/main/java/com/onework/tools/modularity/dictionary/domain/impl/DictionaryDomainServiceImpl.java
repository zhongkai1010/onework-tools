package com.onework.tools.modularity.dictionary.domain.impl;

import com.baomidou.mybatisplus.core.toolkit.IdWorker;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.modularity.dictionary.domain.DictionaryDomainService;
import com.onework.tools.modularity.dictionary.domain.repository.DictionaryGroupRepository;
import com.onework.tools.modularity.dictionary.domain.repository.DictionaryItemRepository;
import com.onework.tools.modularity.dictionary.domain.repository.DictionarySelectRepository;
import com.onework.tools.modularity.dictionary.domain.vo.DictionaryGroupType;
import com.onework.tools.modularity.dictionary.domain.vo.DictionaryGroupVo;
import com.onework.tools.modularity.dictionary.domain.vo.DictionaryItemVo;
import com.onework.tools.modularity.dictionary.domain.vo.DictionarySelectVo;
import org.springframework.beans.factory.annotation.Autowired;
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
public class DictionaryDomainServiceImpl implements DictionaryDomainService {

    @Autowired
    private DictionaryGroupRepository dictionaryGroupRepository;

    @Autowired
    private DictionaryItemRepository dictionaryItemRepository;

    @Autowired
    private DictionarySelectRepository dictionarySelectRepository;

    @Override
    public ExecuteResult<Boolean> addDictionaryGroup(DictionaryGroupVo dictionaryGroup) {
        // 控制code不能重复
        DictionaryGroupVo dbGroup = dictionaryGroupRepository.getGroupByName(dictionaryGroup.getName());
        Check.isTrue(dbGroup != null, new AppException(""));
        dictionaryGroupRepository.addGroup(dictionaryGroup);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updateDictionaryGroup(DictionaryGroupVo dictionaryGroup) {
        DictionaryGroupVo dbGroup = dictionaryGroupRepository.getGroup(dictionaryGroup.getUid());
        Check.notNull(dbGroup, new AppException(""));
        // 控制无法修改属性
        dictionaryGroup.setCode(dbGroup.getCode());
        dictionaryGroup.setType(dbGroup.getType());
        dictionaryGroupRepository.updateGroup(dictionaryGroup);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> deleteDictionaryGroup(String groupId) {

        DictionaryGroupVo dbGroup = dictionaryGroupRepository.getGroup(groupId);
        Check.notNull(dbGroup, new AppException(""));
        // 移除关联字典项
        if (dbGroup.getType() == DictionaryGroupType.ONE) {
            dictionaryItemRepository.deleteItemByGroup(groupId);
        } else {
            dictionarySelectRepository.deleteItemByGroup(groupId);
        }
        dictionaryGroupRepository.deleteGroup(groupId);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> addDictionaryGroupItems(String groupId, List<DictionaryItemVo> items) {
        DictionaryGroupVo dbGroup = dictionaryGroupRepository.getGroup(groupId);
        Check.notNull(dbGroup, new AppException(""));
        // 获取字典组的自定义，控制字典项不能出现重复
        List<DictionaryItemVo> dbItems = dictionaryItemRepository.getItemByGroup(groupId);
        Map<String, DictionaryItemVo> maps = dbItems.stream()
            .collect(Collectors.toMap(DictionaryItemVo::getValue, dictionaryItemVo -> dictionaryItemVo));
        // 逐步添加字典项
        items.forEach(item -> {
            if (maps.containsKey(item.getValue())) {
                throw new AppException("");
            }
            item.setGroupId(groupId);
            dictionaryItemRepository.addItem(item);
        });
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> addDictionaryItem(DictionaryItemVo item) {
        List<DictionaryItemVo> items = new ArrayList<>();
        items.add(item);
        return addDictionaryGroupItems(item.getGroupId(), items);
    }

    @Override
    public ExecuteResult<Boolean> updateDictionaryItem(DictionaryItemVo item) {
        DictionaryItemVo dbItem = dictionaryItemRepository.getItem(item.getUid());
        Check.notNull(dbItem, new AppException(""));
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

    @Override
    public ExecuteResult<Boolean> addDictionarySelect(DictionarySelectVo item) {
        DictionaryGroupVo dbGroup = dictionaryGroupRepository.getGroup(item.getGroupId());
        Check.notNull(dbGroup, new AppException(""));
        // 手动分配id，便于计算parentIds属性
        String id = IdWorker.getIdStr();
        item.setUid(id);
        String parentId = item.getParentId();
        if (parentId != null) {
            // 控制上级名称
            DictionarySelectVo parent = dictionarySelectRepository.getItem(parentId);
            Check.notNull(parent, new AppException(""));
            item.setParentName(parent.getName());
            // 控制同级不能出现相同value
            List<DictionarySelectVo> sameItems = dictionarySelectRepository.getChildrenItem(parent.getUid());
            Map<String, DictionarySelectVo> maps = sameItems.stream()
                .collect(Collectors.toMap(DictionarySelectVo::getValue, dictionarySelectVo -> dictionarySelectVo));
            Check.isTrue(maps.containsKey(item.getValue()), new AppException(""));
            // 计算parentIds
            String parentIds = String.format("%s.%s", parent.getParentIds(), id);
            item.setParentIds(parentIds);
        } else {
            item.setParentId(id);
        }
        dictionarySelectRepository.addItem(item);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updateDictionarySelect(DictionarySelectVo item) {
        DictionarySelectVo dbItem = dictionarySelectRepository.getItem(item.getUid());
        Check.notNull(dbItem, new AppException(""));
        // 控制无法修改属性
        item.setGroupId(dbItem.getGroupId());
        item.setParentId(dbItem.getParentId());
        // 控制同级不能出现相同value
        if (dbItem.getParentId() != null && !Objects.equals(item.getValue(), dbItem.getValue())) {
            List<DictionarySelectVo> sameItems = dictionarySelectRepository.getChildrenItem(dbItem.getParentId());
            Map<String, DictionarySelectVo> maps = sameItems.stream()
                .collect(Collectors.toMap(DictionarySelectVo::getValue, dictionarySelectVo -> dictionarySelectVo));
            Check.isTrue(maps.containsKey(item.getValue()), new AppException(""));
        }
        dictionarySelectRepository.updateItem(item);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> deleteDictionarySelect(String itemId) {
        DictionarySelectVo dbItem = dictionarySelectRepository.getItem(itemId);
        Check.notNull(dbItem, new AppException(""));
        // 同时删除下级
        List<DictionarySelectVo> sameItems = dictionarySelectRepository.getChildrenItem(itemId);
        if (sameItems.size() > 0) {
            sameItems.forEach(dictionarySelectVo -> dictionarySelectRepository.deleteItem(dictionarySelectVo.getUid()));
        }
        dictionarySelectRepository.deleteItem(itemId);
        return ExecuteResult.success(true);
    }
}
