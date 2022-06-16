package com.onework.tools.dictionary.domain.repository.impl;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.util.EnumUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.dictionary.domain.repository.DictionaryGroupRepository;
import com.onework.tools.dictionary.domain.vo.DictionaryGroupType;
import com.onework.tools.dictionary.domain.vo.DictionaryGroupVo;
import com.onework.tools.dictionary.entity.DictionaryGroup;
import com.onework.tools.dictionary.mapper.DictionaryGroupMapper;
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
public class DefaultDictionaryGroupRepository implements DictionaryGroupRepository {

    private final DictionaryGroupMapper dictionaryGroupMapper;

    public DefaultDictionaryGroupRepository(DictionaryGroupMapper dictionaryGroupMapper) {
        this.dictionaryGroupMapper = dictionaryGroupMapper;
    }

    @Override
    public DictionaryGroupVo findGroupByCode(String code) {
        DictionaryGroup dictionaryGroup =
            new LambdaQueryChainWrapper<>(dictionaryGroupMapper).eq(DictionaryGroup::getCode, code).last("limit 1")
                .one();
        if (dictionaryGroup == null) {
            return null;
        }
        return getDictionaryGroup(dictionaryGroup);
    }

    @Override
    public DictionaryGroupVo getGroup(String groupId) {
        DictionaryGroup dictionaryGroup = dictionaryGroupMapper.selectById(groupId);
        Check.notNull(dictionaryGroup, new AppException(String.format("get dictionary group id %s not find", groupId)));
        return getDictionaryGroup(dictionaryGroup);
    }

    @Override
    public void insertGroup(DictionaryGroupVo dictionaryGroupVo) {
        DictionaryGroup dictionaryGroup = BeanUtil.copyProperties(dictionaryGroupVo, DictionaryGroup.class, "type");
        dictionaryGroup.setType(dictionaryGroupVo.getType().name());
        int count = dictionaryGroupMapper.insert(dictionaryGroup);
        Check.isTrue(count == 0, new AppException("insert dictionary group is error"));
    }

    @Override
    public void updateGroup(DictionaryGroupVo dictionaryGroupVo) {
        DictionaryGroup dictionaryGroup = BeanUtil.copyProperties(dictionaryGroupVo, DictionaryGroup.class, "type");
        dictionaryGroup.setType(dictionaryGroupVo.getType().name());
        int count = dictionaryGroupMapper.updateById(dictionaryGroup);
        Check.isTrue(count == 0, new AppException("update dictionary group is error"));
    }

    @Override
    public void deleteGroup(String groupId) {
        int count = dictionaryGroupMapper.deleteById(groupId);
        Check.isTrue(count == 0, new AppException("delete dictionary group is error"));
    }

    @Override
    public List<DictionaryGroupVo> getAllGroupChildren(String id) {
        String ids = String.format("%s.", id);
        List<DictionaryGroup> dictionaryGroups =
            new LambdaQueryChainWrapper<>(dictionaryGroupMapper).like(DictionaryGroup::getParentIds, ids).list();
        List<DictionaryGroupVo> vos = new ArrayList<>(dictionaryGroups.size());
        dictionaryGroups.forEach(item -> {
            DictionaryGroupVo vo = getDictionaryGroup(item);
            vos.add(vo);
        });
        return vos;
    }

    private DictionaryGroupVo getDictionaryGroup(DictionaryGroup dictionaryGroup) {
        DictionaryGroupVo dictionaryGroupVo = BeanUtil.copyProperties(dictionaryGroup, DictionaryGroupVo.class, "type");
        dictionaryGroupVo.setType(EnumUtil.fromString(DictionaryGroupType.class, dictionaryGroup.getType()));
        return dictionaryGroupVo;
    }
}
