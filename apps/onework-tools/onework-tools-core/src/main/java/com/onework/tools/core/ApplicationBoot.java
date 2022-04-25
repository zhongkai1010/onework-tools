package com.onework.tools.core;

import org.springframework.stereotype.Component;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.core
 * @className: ApplictionBoot
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/4/24 21:33
 * @version: 1.0
 */
@Component
public interface ApplicationBoot {

    /**
     * 应用启动初始化
     */
    void init();
}
