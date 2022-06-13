package com.onework.tools.application.service.impl;

import com.onework.tools.application.entity.Application;
import com.onework.tools.application.mapper.ApplicationMapper;
import com.onework.tools.application.service.IApplicationService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2022-06-13
 */
@Service
public class ApplicationServiceImpl extends ServiceImpl<ApplicationMapper, Application> implements IApplicationService {

}
