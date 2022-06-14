package com.onework.tools.file.domain.repository;

import com.onework.tools.file.domain.vo.FileVo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file.domain.impl
 * @Description: 描述
 * @date Date : 2022年05月26日 10:51
 */
public interface FileRepository {
    /**
     * 添加文件
     *
     * @param file
     */
    void addFile(FileVo file);

    /**
     * 根据id获取文件
     *
     * @param fileId
     * @return
     */
    FileVo getFile(String fileId);

    /**
     * 删除文件
     *
     * @param fileId
     */
    void deleteFile(String fileId);
}
