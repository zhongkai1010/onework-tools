package com.onework.tools.file.domain.repository.impl;

import com.onework.tools.file.domain.repository.FileCategoryRepository;
import com.onework.tools.file.domain.vo.FileCategoryConfigType;
import com.onework.tools.file.domain.vo.FileCategoryConfigVo;
import com.onework.tools.file.domain.vo.FileCategoryVo;
import org.springframework.stereotype.Repository;

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

    @Override
    public FileCategoryVo getFileCategorByCode(String code) {
        return null;
    }

    @Override
    public void addFileCategory(FileCategoryVo fileCategory) {

    }

    @Override
    public void addCategoryConfig(FileCategoryConfigVo categoryConfig) {

    }

    @Override
    public FileCategoryVo getFileCategory(String categoryId) {
        return null;
    }

    @Override
    public Map<FileCategoryConfigType, String> getCategoryConfig(String categoryId) {
        return null;
    }

    @Override
    public void updateCategoryConfigValue(String categoryId, FileCategoryConfigType k, String v) {

    }

    @Override
    public void addCategoryConfigValue(String categoryId, FileCategoryConfigType k, String v) {

    }

    @Override
    public void deleteFileCategory(String categoryId) {

    }

    @Override
    public List<FileCategoryVo> getAllFileCategory() {
        return null;
    }

    @Override
    public List<FileCategoryConfigVo> getAllFileCategoryConfig() {
        return null;
    }

    @Override
    public void plusFileCount(String uid) {

    }

    @Override
    public void subFileCount(String uid) {

    }
}
