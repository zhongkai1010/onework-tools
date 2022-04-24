package com.onework.tools;

import com.onework.tools.core.error.ExceptionEnum;
import com.onework.tools.core.module.ModuleManager;
import lombok.extern.slf4j.Slf4j;
import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools
 * @Description: 描述
 * @date Date : 2022年04月24日 10:38
 */
@Slf4j
@Component
public class InitApplicationRunner implements ApplicationRunner {

    @Override
    public void run(ApplicationArguments args) throws Exception {
        ModuleManager.Modules.forEach((s, baseModule) -> {
            log.info("---------------------{}------------------------", baseModule.getModuleInfo().getName());
        });
    }
}
