package com.onework.tools.generator.mybaits;

import lombok.Data;
import lombok.experimental.Accessors;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator.config
 * @Description: 描述
 * @date Date : 2022年03月30日 15:00
 */
@Data
@Accessors(chain = true)
public class GeneratorConfigValue {

    private GlobalConfigValue globalConfigValue = new GlobalConfigValue();

    private PackageConfigValue packageConfigValue = new PackageConfigValue();

    private TemplateConfigValue templateConfigValue = new TemplateConfigValue();

    private StrategyConfigValue strategyConfigValue = new StrategyConfigValue();

    //    public void setModuleName(String moduleName) {
    //        packageConfigValue.setModuleName(moduleName)
    //            .setEntity(String.format("%s.%s", moduleName, packageConfigValue.getEntity()))
    //            .setService(String.format("%s.%s", moduleName, packageConfigValue.getService()))
    //            .setServiceImpl(String.format("%s.%s", moduleName, packageConfigValue.getServiceImpl()))
    //            .setMapper(String.format("%s.%s", moduleName, packageConfigValue.getMapper()))
    //            .setXml(String.format("%s.%s", moduleName, packageConfigValue.getXml()))
    //            .setController(String.format("%s.%s", moduleName, packageConfigValue.getController()));
    //    }
}
