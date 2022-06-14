package com.onework.tools.file.domain.repository.impl;

import cn.hutool.core.bean.BeanUtil;
import com.baomidou.mybatisplus.extension.conditions.query.LambdaQueryChainWrapper;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.file.domain.repository.FileAttachmentRepository;
import com.onework.tools.file.domain.vo.FileAttachmentVo;
import com.onework.tools.file.entity.FileAttachment;
import com.onework.tools.file.mapper.FileAttachmentMapper;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.file.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:40
 */
@Repository
public class DefaultFileAttachmentRepository implements FileAttachmentRepository {

    private final FileAttachmentMapper fileAttachmentMapper;

    public DefaultFileAttachmentRepository(FileAttachmentMapper fileAttachmentMapper) {
        this.fileAttachmentMapper = fileAttachmentMapper;
    }

    @Override
    public List<FileAttachmentVo> getFileAttachmentByFile(String fileId) {
        List<FileAttachment> fileAttachments =
            new LambdaQueryChainWrapper<>(fileAttachmentMapper).eq(FileAttachment::getFileId, fileId).list();
        List<FileAttachmentVo> fileAttachmentVos = new ArrayList<>(fileAttachments.size());
        fileAttachments.forEach(fileAttachment -> {
            FileAttachmentVo fileAttachmentVo = BeanUtil.copyProperties(fileAttachment, FileAttachmentVo.class);
            fileAttachmentVos.add(fileAttachmentVo);
        });
        return fileAttachmentVos;
    }

    @Override
    public List<FileAttachmentVo> getFileAttachmentByObject(String objectId) {
        List<FileAttachment> fileAttachments =
            new LambdaQueryChainWrapper<>(fileAttachmentMapper).eq(FileAttachment::getObjectId, objectId).list();
        List<FileAttachmentVo> fileAttachmentVos = new ArrayList<>(fileAttachments.size());
        fileAttachments.forEach(fileAttachment -> {
            FileAttachmentVo fileAttachmentVo = BeanUtil.copyProperties(fileAttachment, FileAttachmentVo.class);
            fileAttachmentVos.add(fileAttachmentVo);
        });
        return fileAttachmentVos;
    }

    @Override
    public void addFileAttachment(FileAttachmentVo fileAttachment) {
        FileAttachment dbFileAttachment = BeanUtil.copyProperties(fileAttachment, FileAttachment.class);
        int count = fileAttachmentMapper.insert(dbFileAttachment);
        Check.isTrue(count == 0, new AppException("add file attachment error"));
    }

    @Override
    public FileAttachmentVo getFileAttachment(String attachmentId) {
        FileAttachment dbFileAttachment = fileAttachmentMapper.selectById(attachmentId);
        Check.notNull(dbFileAttachment, new AppException("get file attachment is not find"));
        return BeanUtil.copyProperties(dbFileAttachment, FileAttachmentVo.class);
    }

    @Override
    public void deleteFileAttachment(String attachmentId) {
        int count = fileAttachmentMapper.deleteById(attachmentId);
        Check.isTrue(count == 0, new AppException("delete file attachment error"));
    }
}
