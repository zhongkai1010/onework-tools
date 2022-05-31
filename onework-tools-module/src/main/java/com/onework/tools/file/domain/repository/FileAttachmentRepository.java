package com.onework.tools.file.domain.repository;

import com.onework.tools.file.domain.vo.FileAttachmentVo;

import java.util.List;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月26日 14:04
 */
public interface FileAttachmentRepository {
    List<FileAttachmentVo> getFileAttachmentByFile(String fileId);

    List<FileAttachmentVo> getFileAttachmentByObject(String objectId);

    void addFileAttachment(FileAttachmentVo fileAttachment);

    FileAttachmentVo getFileAttachment(String attachmentId);

    void deleteFileAttachment(String attachmentId);
}
