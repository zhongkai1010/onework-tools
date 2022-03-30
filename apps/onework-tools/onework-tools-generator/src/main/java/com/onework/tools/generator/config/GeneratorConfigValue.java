package com.onework.tools.generator.config;

import lombok.Data;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.config
 * @Description: 描述
 * @date Date : 2022年03月30日 15:00
 */
@Data
public class GeneratorConfigValue {

    private GlobalConfigValue globalConfigValue;

    private PackageConfigValue packageConfigValue;

    private TemplateConfigValue templateConfigValue;

    private StrategyConfigValue strategyConfigValue;
}
