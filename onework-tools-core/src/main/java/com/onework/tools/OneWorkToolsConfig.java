package com.onework.tools;

import com.onework.tools.domain.module.DefaultModuleStore;
import com.onework.tools.domain.module.ModuleStore;
import org.springframework.boot.autoconfigure.condition.ConditionalOnMissingBean;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools
 * @Description: 描述
 * @date Date : 2022年05月24日 17:52
 */
@Configuration

public class OneWorkToolsConfig {

    @Bean
    @ConditionalOnMissingBean(ModuleStore.class)
    public ModuleStore getModuleStore() {
        return new DefaultModuleStore();
    }
}
