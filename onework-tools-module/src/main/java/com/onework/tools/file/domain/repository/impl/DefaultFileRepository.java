package com.onework.tools.file.domain.repository.impl;

import com.onework.tools.file.domain.repository.FileRepository;
import com.onework.tools.file.domain.vo.FileVo;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.file.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:41
 */
@Repository
public class DefaultFileRepository implements FileRepository {

    @Override
    public void addFile(FileVo file) {

    }

    @Override
    public FileVo getFile(String fileId) {
        return null;
    }

    @Override
    public void deleteFile(String fileId) {

    }
}
