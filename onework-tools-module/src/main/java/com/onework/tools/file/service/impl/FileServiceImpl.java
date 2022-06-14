package com.onework.tools.file.service.impl;

import com.onework.tools.file.entity.File;
import com.onework.tools.file.mapper.FileMapper;
import com.onework.tools.file.service.IFileService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-06-14
 */
@Service
public class FileServiceImpl extends ServiceImpl<FileMapper, File> implements IFileService {

}
