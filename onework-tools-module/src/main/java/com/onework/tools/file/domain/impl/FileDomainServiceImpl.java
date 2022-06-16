package com.onework.tools.file.domain.impl;

import cn.hutool.core.convert.Convert;
import cn.hutool.core.util.ArrayUtil;
import com.baomidou.mybatisplus.core.toolkit.IdWorker;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.ExecuteResult;
import com.onework.tools.file.FileCategoryManager;
import com.onework.tools.file.FileDomainService;
import com.onework.tools.file.domain.event.FileCategoryEventPublisher;
import com.onework.tools.file.domain.repository.FileAttachmentRepository;
import com.onework.tools.file.domain.repository.FileCategoryRepository;
import com.onework.tools.file.domain.repository.FileRepository;
import com.onework.tools.file.domain.vo.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月26日 10:24
 */
@Service
public class FileDomainServiceImpl implements FileDomainService {

    private FileCategoryRepository fileCategoryRepository;

    private FileRepository fileRepository;

    private FileAttachmentRepository fileAttachmentRepository;

    private FileCategoryEventPublisher fileCategoryEventPublisher;

    public FileDomainServiceImpl() {

    }

    @Autowired
    public FileDomainServiceImpl(FileCategoryRepository fileCategoryRepository, FileRepository fileRepository,
       FileAttachmentRepository fileAttachmentRepository,
        FileCategoryEventPublisher fileCategoryEventPublisher) {
        this.fileRepository = fileRepository;
        this.fileAttachmentRepository = fileAttachmentRepository;
        this.fileCategoryEventPublisher = fileCategoryEventPublisher;
        this.fileCategoryRepository = fileCategoryRepository;
    }

    @Override
    public ExecuteResult<FileCategoryVo> getCategoryAsSave(FileCategoryVo fileCategory) {
        FileCategoryVo fileCategoryVo = fileCategoryRepository.findFileCategoryByCode(fileCategory.getCode());
        if (fileCategoryVo == null) {
            fileCategoryRepository.addFileCategory(fileCategory);
            return ExecuteResult.success(fileCategory);
        }
        return ExecuteResult.success(fileCategoryVo);
    }

    @Transactional(rollbackFor = Exception.class)
    @Override
    public ExecuteResult<Boolean> addCategory(FileCategoryVo fileCategory, Map<FileCategoryConfigType, String> config) {
        Check.notNull(fileCategory.getCode(), new AppException("add category code is null"));
        // 控制文件类别code不能出现重复
        FileCategoryVo dbFileCategory = fileCategoryRepository.findFileCategoryByCode(fileCategory.getCode());
        Check.isTrue(dbFileCategory != null,
            new AppException(String.format("add category code is repeat code is %s", fileCategory.getCode())));
        // 添加文件类别，设置默认值，获得id
        fileCategory.setUid(IdWorker.getIdStr());
        fileCategory.setFileCount(0);
        fileCategoryRepository.addFileCategory(fileCategory);
        // 添加配置
        if (config != null) {
            config.forEach((k, v) -> {
                FileCategoryConfigVo categoryConfig = new FileCategoryConfigVo();
                categoryConfig.setCategoryId(fileCategory.getUid());
                categoryConfig.setValue(v);
                categoryConfig.setType(k);
                fileCategoryRepository.addCategoryConfig(categoryConfig);
            });
        }
        // 发布变动
        fileCategoryEventPublisher.publishFileCategory(fileCategory);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updateCategoryConfig(String categoryId, Map<FileCategoryConfigType, String> config) {
        // 验证是否存在
        FileCategoryVo fileCategory = fileCategoryRepository.getFileCategory(categoryId);
        // 更新配置
        Map<FileCategoryConfigType, String> fileCategoryConfigs = fileCategoryRepository.getCategoryConfig(categoryId);
        config.forEach((k, v) -> {
            if (fileCategoryConfigs.containsKey(k)) {
                fileCategoryRepository.updateCategoryConfigValue(categoryId, k, v);
            } else {
                fileCategoryRepository.addCategoryConfigValue(categoryId, k, v);
            }
        });
        // 发布变动
        fileCategoryEventPublisher.publishFileCategory(fileCategory);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> updateCategoryConfig(String categoryId, FileCategoryConfigType configType,
        String value) {
        HashMap<FileCategoryConfigType, String> map = new HashMap<>(1);
        map.put(configType, value);
        return updateCategoryConfig(categoryId, map);
    }

    @Override
    public ExecuteResult<Boolean> deleteCategory(String categoryId) {
        // 验证是否存在
        FileCategoryVo fileCategory = fileCategoryRepository.getFileCategory(categoryId);
        // 控制删除文件类别前，需要处理所属文件类别下的文件
        Check.isTrue(fileCategory.getFileCount() > 0, new AppException(""));
        // 删除配置
        fileCategoryRepository.deleteFileCategoryConfig(categoryId);
        fileCategoryRepository.deleteFileCategory(categoryId);
        // 发布变动
        fileCategoryEventPublisher.publishFileCategory(fileCategory);
        return ExecuteResult.success(true);
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public ExecuteResult<Boolean> addFile(FileVo file) {
        // 验证文件类别是否存在
        FileCategoryVo fileCategory = fileCategoryRepository.getFileCategory(file.getCategoryId());
        Check.notNull(fileCategory, new AppException(""));
        //根据文件类别配置，验证文件是否合法
        Map<FileCategoryConfigType, String> configMap = FileCategoryManager.Configs.get(fileCategory.getCode());
        configMap.forEach((k, v) -> {
            switch (k) {
                case FILE_SIZE:
                    long fileSize = Convert.convert(long.class, v);
                    Check.isTrue(file.getSize() > fileSize, new AppException(""));
                    break;
                case FILE_EXT:
                    String[] exts = v.split("\\|");
                    Check.isTrue(!ArrayUtil.contains(exts, file.getExt()), new AppException(""));
                    break;
                default:
                    break;
            }
        });
        //添加文件，文件类别中累计+1
        fileRepository.addFile(file);
        fileCategoryRepository.plusFileCount(fileCategory.getUid());
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deleteFile(String fileId) {
        // 验证处理文件是否存在
        FileVo file = fileRepository.getFile(fileId);
        Check.notNull(file, new AppException(""));
        // 验证文件类别是否存在
        FileCategoryVo fileCategory = fileCategoryRepository.getFileCategory(file.getCategoryId());
        Check.notNull(fileCategory, new AppException(""));
        // 验证文件是否关联附件
        List<FileAttachmentVo> fileAttachmentVos = fileAttachmentRepository.getFileAttachmentByFile(fileId);
        Check.isTrue(fileAttachmentVos.size() > 0, new AppException(""));
        // 删除文件，计数-1
        fileRepository.deleteFile(fileId);
        fileCategoryRepository.subFileCount(fileCategory.getUid());

        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> addFileAttachment(String fileId, String objectId) {
        FileAttachmentVo fileAttachment = new FileAttachmentVo();
        // 验证处理文件是否存在
        FileVo file = fileRepository.getFile(fileId);
        Check.notNull(file, new AppException(""));
        FileCategoryVo fileCategory = fileCategoryRepository.getFileCategory(file.getCategoryId());
        // 控制关联值
        fileAttachment.setFileName(file.getName());
        fileAttachment.setCategoryId(fileCategory.getUid());
        fileAttachment.setObjectId(objectId);
        // 计算版本
        List<FileAttachmentVo> fileAttachmentVos = fileAttachmentRepository.getFileAttachmentByObject(objectId);
        if (fileAttachmentVos.size() > 0) {
            int max = fileAttachmentVos.stream().mapToInt(FileAttachmentVo::getVersion).max().getAsInt();
            fileAttachment.setVersion(max + 1);
        } else {
            fileAttachment.setVersion(1);
        }
        fileAttachmentRepository.addFileAttachment(fileAttachment);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deleteFileAttachment(String attachmentId) {
        FileAttachmentVo fileAttachment = fileAttachmentRepository.getFileAttachment(attachmentId);
        Check.notNull(fileAttachment, new AppException(""));
        // 删除关联文件
        internalDeleteAttachment(fileAttachment.getFileId());
        // 删除附件
        fileAttachmentRepository.deleteFileAttachment(attachmentId);
        return ExecuteResult.success(true);
    }

    @Override
    public ExecuteResult<Boolean> deleteAttachment(String objectId) {
        ExecuteResult<Boolean> executeResult = ExecuteResult.failure();
        List<FileAttachmentVo> fileAttachmentVos = fileAttachmentRepository.getFileAttachmentByObject(objectId);
        for (FileAttachmentVo fileAttachmentVo : fileAttachmentVos) {
            // 删除关联文件
            internalDeleteAttachment(fileAttachmentVo.getFileId());
            // 删除附件
            fileAttachmentRepository.deleteFileAttachment(fileAttachmentVo.getUid());
        }
        return executeResult;
    }

    private void internalDeleteAttachment(String fileId) {
        // 验证处理文件是否存在
        FileVo file = fileRepository.getFile(fileId);
        Check.notNull(file, new AppException(""));
        // 验证文件类别是否存在
        FileCategoryVo fileCategory = fileCategoryRepository.getFileCategory(file.getCategoryId());
        Check.notNull(fileCategory, new AppException(""));
        // 删除文件，计数-1
        fileRepository.deleteFile(fileId);
        fileCategoryRepository.subFileCount(fileCategory.getUid());
    }
}
