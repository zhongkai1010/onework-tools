package com.onework.tools;

import lombok.extern.slf4j.Slf4j;
import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.context.ApplicationContext;
import org.springframework.stereotype.Component;

import java.util.Map;

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

    private final ApplicationContext applicationContext;

    public InitApplicationRunner(ApplicationContext applicationContext) {
        this.applicationContext = applicationContext;
    }

    @Override
    public void run(ApplicationArguments args) throws Exception {
        Map<String, ApplicationBoot> applicationBootMap = applicationContext.getBeansOfType(ApplicationBoot.class);
        applicationBootMap.forEach((s, applicationBoot) -> {
            log.info("--------------- start application boot init {}---------------------", s);
            applicationBoot.init();
            log.info("--------------- end application boot init {}---------------------", s);
        });
    }
}
