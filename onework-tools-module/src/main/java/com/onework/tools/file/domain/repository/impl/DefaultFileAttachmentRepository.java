package com.onework.tools.file.domain.repository.impl;

import com.onework.tools.file.domain.repository.FileAttachmentRepository;
import com.onework.tools.file.domain.vo.FileAttachmentVo;
import org.springframework.stereotype.Repository;

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

    @Override
    public List<FileAttachmentVo> getFileAttachmentByFile(String fileId) {
        return null;
    }

    @Override
    public List<FileAttachmentVo> getFileAttachmentByObject(String objectId) {
        return null;
    }

    @Override
    public void addFileAttachment(FileAttachmentVo fileAttachment) {

    }

    @Override
    public FileAttachmentVo getFileAttachment(String attachmentId) {
        return null;
    }

    @Override
    public void deleteFileAttachment(String attachmentId) {

    }
}
