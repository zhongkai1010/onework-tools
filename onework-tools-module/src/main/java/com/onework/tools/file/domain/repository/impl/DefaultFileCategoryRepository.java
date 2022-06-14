package com.onework.tools.file.domain.repository.impl;

import cn.hutool.core.bean.BeanUtil;
import cn.hutool.core.util.EnumUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.baomidou.mybatisplus.extension.conditions.update.LambdaUpdateChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.file.domain.repository.FileCategoryRepository;
import com.onework.tools.file.domain.vo.FileCategoryConfigType;
import com.onework.tools.file.domain.vo.FileCategoryConfigVo;
import com.onework.tools.file.domain.vo.FileCategoryVo;
import com.onework.tools.file.entity.FileCategory;
import com.onework.tools.file.entity.FileCategoryConfig;
import com.onework.tools.file.mapper.FileCategoryConfigMapper;
import com.onework.tools.file.mapper.FileCategoryMapper;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.file.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:40
 */
@Repository
public class DefaultFileCategoryRepository implements FileCategoryRepository {

    private final FileCategoryMapper fileCategoryMapper;

    private final FileCategoryConfigMapper fileCategoryConfigMapper;

    public DefaultFileCategoryRepository(FileCategoryMapper fileCategoryMapper,
        FileCategoryConfigMapper fileCategoryConfigMapper) {
        this.fileCategoryMapper = fileCategoryMapper;
        this.fileCategoryConfigMapper = fileCategoryConfigMapper;
    }

    @Override
    public FileCategoryVo findFileCategoryByCode(String code) {
        FileCategory fileCategory =
            new LambdaQueryChainWrapper<>(fileCategoryMapper).eq(FileCategory::getCode, code).last("limit 1").one();
        if (fileCategory == null) {
            return null;
        }
        return BeanUtil.copyProperties(fileCategory, FileCategoryVo.class);
    }

    @Override
    public void addFileCategory(FileCategoryVo fileCategory) {
        FileCategory dbFileCategory = BeanUtil.copyProperties(fileCategory, FileCategory.class);
        int count = fileCategoryMapper.insert(dbFileCategory);
        Check.isTrue(count == 0, new AppException("add file category error"));
        BeanUtil.copyProperties(dbFileCategory, fileCategory);
    }

    @Override
    public void addCategoryConfig(FileCategoryConfigVo categoryConfig) {
        FileCategoryConfig dbFileCategoryConfig =
            BeanUtil.copyProperties(categoryConfig, FileCategoryConfig.class, "type");
        dbFileCategoryConfig.setType(categoryConfig.getType().name());
        int count = fileCategoryConfigMapper.insert(dbFileCategoryConfig);
        Check.isTrue(count == 0, new AppException("add file category config error"));
        BeanUtil.copyProperties(dbFileCategoryConfig, categoryConfig, "type");
    }

    @Override
    public FileCategoryVo getFileCategory(String categoryId) {
        FileCategory dbFileCategory = fileCategoryMapper.selectById(categoryId);
        Check.notNull(dbFileCategory,
            new AppException(String.format("get file category not find id is %s", categoryId)));
        return BeanUtil.copyProperties(dbFileCategory, FileCategoryVo.class);
    }

    @Override
    public Map<FileCategoryConfigType, String> getCategoryConfig(String categoryId) {
        List<FileCategoryConfig> fileCategoryConfigs =
            new LambdaQueryChainWrapper<>(fileCategoryConfigMapper).eq(FileCategoryConfig::getCategoryId, categoryId)
                .list();
        Map<FileCategoryConfigType, String> map = new HashMap<>(fileCategoryConfigs.size());
        fileCategoryConfigs.forEach(fileCategoryConfig -> {
            FileCategoryConfigType fileCategoryConfigType =
                EnumUtil.fromString(FileCategoryConfigType.class, fileCategoryConfig.getType());
            map.put(fileCategoryConfigType, fileCategoryConfig.getValue());
        });
        return map;
    }

    @Override
    public void updateCategoryConfigValue(String categoryId, FileCategoryConfigType type, String value) {
        FileCategoryConfig fileCategoryConfig =
            new LambdaQueryChainWrapper<>(fileCategoryConfigMapper).eq(FileCategoryConfig::getCategoryId, categoryId)
                .eq(FileCategoryConfig::getType, type.name()).last("limit 1").one();
        Check.notNull(fileCategoryConfig, new AppException(
            String.format("update file category config not find type is %s category id %s", type.name(), categoryId)));
        fileCategoryConfig.setValue(value);
        boolean success =
            new LambdaUpdateChainWrapper<>(fileCategoryConfigMapper).eq(FileCategoryConfig::getCategoryId, categoryId)
                .eq(FileCategoryConfig::getType, type.name()).update(fileCategoryConfig);
        Check.isTrue(!success, new AppException("update file category config error"));
    }

    @Override
    public void addCategoryConfigValue(String categoryId, FileCategoryConfigType type, String value) {
        FileCategoryConfig fileCategoryConfig = new FileCategoryConfig();
        fileCategoryConfig.setCategoryId(categoryId);
        fileCategoryConfig.setType(type.name());
        fileCategoryConfig.setValue(value);
        int count = fileCategoryConfigMapper.insert(fileCategoryConfig);
        Check.isTrue(count == 0, new AppException("add file category config error"));
    }

    @Override
    public void deleteFileCategory(String categoryId) {
        int count = fileCategoryMapper.deleteById(categoryId);
        Check.isTrue(count == 0,
            new AppException(String.format("delete file category config error id is %s", categoryId)));
    }

    @Override
    public List<FileCategoryVo> getAllFileCategory() {
        List<FileCategory> fileCategories = fileCategoryMapper.selectList(null);
        List<FileCategoryVo> fileCategoryVos = new ArrayList<>(fileCategories.size());
        fileCategories.forEach(fileCategory -> {
            FileCategoryVo fileCategoryVo = BeanUtil.copyProperties(fileCategory, FileCategoryVo.class);
            fileCategoryVos.add(fileCategoryVo);
        });
        return fileCategoryVos;
    }

    @Override
    public List<FileCategoryConfigVo> getAllFileCategoryConfig() {
        List<FileCategoryConfig> fileCategoryConfigs = fileCategoryConfigMapper.selectList(null);
        List<FileCategoryConfigVo> fileCategoryConfigVos = new ArrayList<>(fileCategoryConfigs.size());
        fileCategoryConfigs.forEach(fileCategoryConfig -> {
            FileCategoryConfigVo fileCategoryConfigVo =
                BeanUtil.copyProperties(fileCategoryConfig, FileCategoryConfigVo.class);
            fileCategoryConfigVos.add(fileCategoryConfigVo);
        });
        return fileCategoryConfigVos;
    }

    @Override
    public void plusFileCount(String id) {
        FileCategory fileCategory = fileCategoryMapper.selectById(id);
        int total = fileCategory.getFileCount();
        total += 1;
        fileCategory.setFileCount(total);
        int count = fileCategoryMapper.updateById(fileCategory);
        Check.isTrue(count == 0, new AppException("plus file category count error"));
    }

    @Override
    public void subFileCount(String id) {
        FileCategory fileCategory = fileCategoryMapper.selectById(id);
        int total = fileCategory.getFileCount();
        total -= 1;
        fileCategory.setFileCount(total);
        int count = fileCategoryMapper.updateById(fileCategory);
        Check.isTrue(count == 0, new AppException("sub file category count error"));
    }

    @Override
    public void deleteFileCategoryConfig(String categoryId) {

    }
}
