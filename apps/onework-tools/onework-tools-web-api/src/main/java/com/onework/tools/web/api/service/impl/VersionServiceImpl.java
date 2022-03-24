package com.onework.tools.web.api.service.impl;

import com.onework.tools.web.api.entity.Version;
import com.onework.tools.web.api.mapper.VersionMapper;
import com.onework.tools.web.api.service.IVersionService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author 钟凯
 * @since 2022-03-24
 */
@Service
public class VersionServiceImpl extends ServiceImpl<VersionMapper, Version> implements IVersionService {

}
