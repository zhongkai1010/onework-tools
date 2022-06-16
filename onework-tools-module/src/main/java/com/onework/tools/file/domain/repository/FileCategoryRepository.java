package com.onework.tools.file.domain.repository;

import com.onework.tools.file.domain.vo.FileCategoryConfigType;
import com.onework.tools.file.domain.vo.FileCategoryConfigVo;
import com.onework.tools.file.domain.vo.FileCategoryVo;

import java.util.List;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月26日 10:30
 */
public interface FileCategoryRepository {

    /**
     * 根据code查询文件类别
     *
     * @param code
     * @return
     */
    FileCategoryVo findFileCategoryByCode(String code);

    /**
     *
     * @param fileCategory
     */
    void addFileCategory(FileCategoryVo fileCategory);

    /**
     *
     * @param categoryConfig
     */
    void addCategoryConfig(FileCategoryConfigVo categoryConfig);

    /**
     *
     * @param categoryId
     * @return
     */
    FileCategoryVo getFileCategory(String categoryId);

    /**
     *
     * @param categoryId
     * @return
     */
    Map<FileCategoryConfigType, String> getCategoryConfig(String categoryId);

    /**
     *
     * @param categoryId
     * @param k
     * @param v
     */
    void updateCategoryConfigValue(String categoryId, FileCategoryConfigType k, String v);

    /**
     *
     * @param categoryId
     * @param k
     * @param v
     */
    void addCategoryConfigValue(String categoryId, FileCategoryConfigType k, String v);

    void deleteFileCategory(String categoryId);

    List<FileCategoryVo> getAllFileCategory();

    List<FileCategoryConfigVo> getAllFileCategoryConfig();

    void plusFileCount(String uid);

    void subFileCount(String uid);

    void deleteFileCategoryConfig(String categoryId);
}
