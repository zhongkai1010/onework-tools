package com.onework.tools.dictionary.domain.impl;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.dictionary.domain.DictionarySelectDomainService;
import com.onework.tools.dictionary.domain.repository.DictionaryGroupRepository;
import com.onework.tools.dictionary.domain.repository.DictionarySelectRepository;
import com.onework.tools.dictionary.domain.vo.DictionaryGroupVo;
import com.onework.tools.dictionary.domain.vo.DictionarySelectVo;
import com.onework.tools.domain.tree.TreeNameNodeHandler;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.stream.Collectors;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.dictionary.domain.impl
 * @Description: 描述
 * @date Date : 2022年06月16日 9:50
 */
@Service
public class DictionarySelectDomainServiceImpl extends TreeNameNodeHandler<DictionarySelectVo>
    implements DictionarySelectDomainService {

    private final DictionarySelectRepository dictionarySelectRepository;

    private final DictionaryGroupRepository dictionaryGroupRepository;

    public DictionarySelectDomainServiceImpl(DictionarySelectRepository dictionarySelectRepository,
        DictionaryGroupRepository dictionaryGroupRepository) {
        this.dictionarySelectRepository = dictionarySelectRepository;
        this.dictionaryGroupRepository = dictionaryGroupRepository;
    }

    @Override
    public ExecuteResult<Boolean> addSelectItem(DictionarySelectVo item) {
        // 验证字典组是否正确
        DictionaryGroupVo dbGroup = dictionaryGroupRepository.getGroup(item.getGroupId());
        item.setGroupId(dbGroup.getUid());
        // 验证统计不能出现相同value
        String parentId = item.getParentId();
        if (parentId != null) {
            // 控制同级不能出现相同value
            List<DictionarySelectVo> sameItems = dictionarySelectRepository.getChildrenItem(parentId);
            Map<String, DictionarySelectVo> maps = sameItems.stream()
                .collect(Collectors.toMap(DictionarySelectVo::getValue, dictionarySelectVo -> dictionarySelectVo));
            Check.isTrue(maps.containsKey(item.getValue()),
                new AppException(String.format("add dictionary select item value %s repeat", item.getValue())));
        }
        addNode(item);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> updateSelectItem(DictionarySelectVo item) {
        DictionarySelectVo dbItem = dictionarySelectRepository.getItem(item.getUid());
        // 控制无法修改属性
        item.setGroupId(dbItem.getGroupId());
        // 控制同级不能出现相同value
        String parentId = item.getParentId();
        if (parentId != null && !Objects.equals(parentId, dbItem.getParentId())) {
            List<DictionarySelectVo> sameItems = dictionarySelectRepository.getChildrenItem(dbItem.getParentId());
            Map<String, DictionarySelectVo> maps = sameItems.stream()
                .collect(Collectors.toMap(DictionarySelectVo::getValue, dictionarySelectVo -> dictionarySelectVo));
            Check.isTrue(maps.containsKey(item.getValue()),
                new AppException(String.format("update dictionary select item value %s repeat", item.getValue())));
        }
        updateNode(item);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> deleteSelectItem(String itemId) {
        deleteNode(itemId);
        return ExecuteResult.success(true);
    }

    @Override
    protected void updateChildNode(DictionarySelectVo childNode) {
        dictionarySelectRepository.updateItem(childNode);
    }

    @Override
    protected DictionarySelectVo getNode(String id) {
        return dictionarySelectRepository.getItem(id);
    }

    @Override
    protected List<DictionarySelectVo> getAllChildrenNode(String id) {
        return dictionarySelectRepository.getAllChildrenItem(id);
    }

    @Override
    protected void saveNode(DictionarySelectVo node, Boolean isNew) {
        if (isNew) {
            dictionarySelectRepository.insertItem(node);
        } else {
            dictionarySelectRepository.updateItem(node);
        }
    }

    @Override
    protected void afterDeleteNode(DictionarySelectVo node) {
        dictionarySelectRepository.deleteItem(node.getUid());
    }
}
