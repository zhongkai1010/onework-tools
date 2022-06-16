package com.onework.tools.file;

import com.onework.tools.ExecuteResult;
import com.onework.tools.file.domain.vo.FileCategoryConfigType;
import com.onework.tools.file.domain.vo.FileCategoryVo;
import com.onework.tools.file.domain.vo.FileVo;
import org.springframework.stereotype.Component;

import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file.domain
 * @Description: 描述
 * @date Date : 2022年05月26日 10:05
 */
@Component
public interface FileDomainService {

    /**
     * 获取文件类别，有则根据code返回，反之新增文件类别
     * @param fileCategory
     * @return
     */
    ExecuteResult<FileCategoryVo> getCategoryAsSave(FileCategoryVo fileCategory);

    /**
     * 添加文件类别
     *
     * @param fileCategory
     * @param config
     * @return
     */
    ExecuteResult<Boolean> addCategory(FileCategoryVo fileCategory, Map<FileCategoryConfigType, String> config);

    /**
     * 更新文件类别配置
     *
     * @param categoryId
     * @param config
     * @return
     */
    ExecuteResult<Boolean> updateCategoryConfig(String categoryId, Map<FileCategoryConfigType, String> config);

    /**
     * 更新文件类别配置
     *
     * @param categoryId
     * @param configType
     * @param value
     * @return
     */
    ExecuteResult<Boolean> updateCategoryConfig(String categoryId, FileCategoryConfigType configType, String value);

    /**
     * 删除文件类别
     *
     * @param categoryId
     * @return
     */
    ExecuteResult<Boolean> deleteCategory(String categoryId);

    /**
     * 添加文件
     *
     * @param file
     * @return
     */
    ExecuteResult<Boolean> addFile(FileVo file);

    /**
     * 删除文件
     *
     * @param fileId
     * @return
     */
    ExecuteResult<Boolean> deleteFile(String fileId);

    /**
     * 添加文件附件，判断同类别与关联id，将计算版本
     *
     * @param fileId
     * @param objectId
     * @return
     */
    ExecuteResult<Boolean> addFileAttachment(String fileId, String objectId);

    /**
     * 删除文件附件
     *
     * @param attachmentId
     * @return
     */
    ExecuteResult<Boolean> deleteFileAttachment(String attachmentId);

    /**
     * 删除文件附件
     *
     * @param objectId
     * @return
     */
    ExecuteResult<Boolean> deleteAttachment(String objectId);
}
