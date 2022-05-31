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
    void addFile(FileVo file);

    FileVo getFile(String fileId);

    void deleteFile(String fileId);
}
