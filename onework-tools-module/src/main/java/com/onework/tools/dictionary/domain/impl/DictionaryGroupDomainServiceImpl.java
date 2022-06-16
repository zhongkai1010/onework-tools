package com.onework.tools.dictionary.domain.impl;

import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.dictionary.domain.DictionaryGroupDomainService;
import com.onework.tools.dictionary.domain.repository.DictionaryGroupRepository;
import com.onework.tools.dictionary.domain.repository.DictionaryItemRepository;
import com.onework.tools.dictionary.domain.repository.DictionarySelectRepository;
import com.onework.tools.dictionary.domain.vo.DictionaryGroupType;
import com.onework.tools.dictionary.domain.vo.DictionaryGroupVo;
import com.onework.tools.domain.tree.TreeNameNodeHandler;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.dictionary.domain.impl
 * @Description: 描述
 * @date Date : 2022年06月16日 9:18
 */
@Service
public class DictionaryGroupDomainServiceImpl extends TreeNameNodeHandler<DictionaryGroupVo>
    implements DictionaryGroupDomainService {

    private final DictionaryGroupRepository dictionaryGroupRepository;

    protected final DictionaryItemRepository dictionaryItemRepository;

    protected final DictionarySelectRepository dictionarySelectRepository;

    public DictionaryGroupDomainServiceImpl(DictionaryGroupRepository dictionaryGroupRepository,
        DictionaryItemRepository dictionaryItemRepository, DictionarySelectRepository dictionarySelectRepository) {
        this.dictionaryGroupRepository = dictionaryGroupRepository;
        this.dictionaryItemRepository = dictionaryItemRepository;
        this.dictionarySelectRepository = dictionarySelectRepository;
    }

    @Override
    public ExecuteResult<Boolean> addGroup(DictionaryGroupVo dictionaryGroup) {
        // 控制code不能重复
        String code = dictionaryGroup.getCode();
        Check.notNull(code, new AppException("add dictionary group  code is null"));
        DictionaryGroupVo dbGroup = dictionaryGroupRepository.findGroupByCode(code);
        Check.isTrue(dbGroup != null, new AppException("add dictionary group is code exist"));
        // 添加字典组
        addNode(dictionaryGroup);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updateGroup(DictionaryGroupVo dictionaryGroup) {
        DictionaryGroupVo dbGroup = dictionaryGroupRepository.getGroup(dictionaryGroup.getUid());
        // 控制无法修改属性
        dictionaryGroup.setCode(dbGroup.getCode());
        dictionaryGroup.setType(dbGroup.getType());
        updateNode(dbGroup);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deleteGroup(String groupId) {
        deleteNode(groupId);
        return ExecuteResult.success(true);
    }

    @Override
    protected void updateChildNode(DictionaryGroupVo childNode) {
        dictionaryGroupRepository.updateGroup(childNode);
    }

    @Override
    protected DictionaryGroupVo getNode(String id) {
        return dictionaryGroupRepository.getGroup(id);
    }

    @Override
    protected List<DictionaryGroupVo> getAllChildrenNode(String id) {
        return dictionaryGroupRepository.getAllGroupChildren(id);
    }

    @Override
    protected void saveNode(DictionaryGroupVo node, Boolean isNew) {
        if (isNew) {
            dictionaryGroupRepository.insertGroup(node);
        } else {
            dictionaryGroupRepository.updateGroup(node);
        }
    }

    @Override
    protected void afterDeleteNode(DictionaryGroupVo node) {
        DictionaryGroupType dictionaryGroupType = node.getType();
        if (dictionaryGroupType.equals(DictionaryGroupType.ONE)) {
            dictionaryItemRepository.deleteItemByGroup(node.getUid());
        } else {
            dictionarySelectRepository.deleteItemByGroup(node.getUid());
        }
        dictionaryGroupRepository.deleteGroup(node.getUid());
    }
}
