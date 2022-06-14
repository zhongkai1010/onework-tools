package com.onework.tools.file.domain.repository.impl;

import cn.hutool.core.bean.BeanUtil;
import com.onework.tools.AppException;
import com.onework.tools.Check;
import com.onework.tools.file.domain.repository.FileRepository;
import com.onework.tools.file.domain.vo.FileVo;
import com.onework.tools.file.entity.File;
import com.onework.tools.file.mapper.FileMapper;
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

    private final FileMapper fileMapper;

    public DefaultFileRepository(FileMapper fileMapper) {
        this.fileMapper = fileMapper;
    }

    @Override
    public void addFile(FileVo file) {
        File dbFile = BeanUtil.copyProperties(file, File.class);
        int count = fileMapper.insert(dbFile);
        Check.isTrue(count == 0, new AppException("add file error"));
    }

    @Override
    public FileVo getFile(String fileId) {
        File file = fileMapper.selectById(fileId);
        Check.notNull(file, new AppException(String.format("get file is id %s not find", fileId)));
        FileVo fileVo = BeanUtil.copyProperties(file, FileVo.class);
        return fileVo;
    }

    @Override
    public void deleteFile(String fileId) {
        int count = fileMapper.deleteById(fileId);
        Check.isTrue(count == 0, new AppException("delete file error"));
    }
}
