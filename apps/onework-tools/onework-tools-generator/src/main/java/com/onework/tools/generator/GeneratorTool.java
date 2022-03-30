package com.onework.tools.generator;

import cn.hutool.core.util.ReflectUtil;
import com.baomidou.mybatisplus.generator.FastAutoGenerator;
import com.baomidou.mybatisplus.generator.config.GlobalConfig;
import com.baomidou.mybatisplus.generator.config.PackageConfig;
import com.baomidou.mybatisplus.generator.config.StrategyConfig;
import com.baomidou.mybatisplus.generator.config.TemplateConfig;
import com.baomidou.mybatisplus.generator.config.builder.Controller;
import com.baomidou.mybatisplus.generator.config.builder.Entity;
import com.baomidou.mybatisplus.generator.config.builder.Mapper;
import com.baomidou.mybatisplus.generator.config.builder.Service;
import com.onework.tools.generator.config.*;

import java.lang.reflect.Field;
import java.util.ArrayList;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.generator
 * @Description: 描述
 * @date Date : 2022年03月30日 14:58
 */
public class GeneratorTool {

    private final FastAutoGenerator fastAutoGenerator;
    private final GeneratorConfigValue generatorConfigValue;

    public GeneratorTool(FastAutoGenerator fastAutoGenerator, GeneratorConfigValue generatorConfigValue) {
        this.fastAutoGenerator = fastAutoGenerator;
        this.generatorConfigValue = generatorConfigValue;
    }

    public void execute() {

        fastAutoGenerator.globalConfig(
                builder -> setGlobalConfig(builder, this.generatorConfigValue.getGlobalConfigValue()))
            .packageConfig(builder -> setPackageConfig(builder, this.generatorConfigValue.getPackageConfigValue()))
            .templateConfig(builder -> setTemplateConfig(builder, this.generatorConfigValue.getTemplateConfigValue()))
            .strategyConfig(builder -> setStrategyConfig(builder, this.generatorConfigValue.getStrategyConfigValue()))
            .execute();
    }

    /**
     * 通过反射设置对象值
     *
     * @param value       配置值
     * @param objectValue 对象值
     */
    private static void setValue(Field[] fields, Object value, Object objectValue) {
        for (Field field : fields) {

            String fieldName = field.getName();
            Object fieldValue = ReflectUtil.getFieldValue(value, field);
            if (fieldValue != null) {
                Class<?> type = fieldValue.getClass();
                if (type.equals(Boolean.class)) {
                    boolean blValue = Boolean.getBoolean(fieldValue.toString());
                    if (blValue) {
                        ReflectUtil.invoke(objectValue, fieldName);
                    }
                } else {
                    ReflectUtil.invoke(objectValue, fieldName, fieldValue);
                }
            }
        }
    }

    /**
     * 设置全局配置(GlobalConfig)
     *
     * @param builder
     * @param value
     */
    private static void setGlobalConfig(GlobalConfig.Builder builder, GlobalConfigValue value) {
        if (value == null) {
            return;
        }
        //        builder.fileOverride()
        //        builder.disableOpenDir()
        //        builder.outputDir()
        //        builder.author()
        //        builder.enableKotlin()
        //        builder.enableSwagger()
        //        builder.dateType()
        //        builder.commentDate()
        Field[] field = ReflectUtil.getFields(GlobalConfigValue.class);
        setValue(field, value, builder);
    }

    private static void setPackageConfig(PackageConfig.Builder builder, PackageConfigValue value) {
        if (value == null) {
            return;
        }
        //        builder.parent()
        //        builder.moduleName()
        //        builder.entity()
        //        builder.service()
        //        builder.serviceImpl()
        //        builder.xml()
        //        builder.controller()
        //        builder.other()
        //        builder.pathInfo()
        Field[] field = ReflectUtil.getFields(PackageConfigValue.class);
        setValue(field, value, builder);
    }

    private static void setTemplateConfig(TemplateConfig.Builder builder, TemplateConfigValue value) {
        if (value == null) {
            return;
        }
        //        builder.entity()
        //        builder.entityKt()
        //        builder.service()
        //        builder.serviceImpl()
        //        builder.mapper()
        //        builder.mapperXml()
        //        builder.controller()
        Field[] field = ReflectUtil.getFields(TemplateConfigValue.class);
        setValue(field, value, builder);
    }

    private static void setStrategyConfig(StrategyConfig.Builder builder, StrategyConfigValue value) {
        if (value == null) {
            return;
        }

        //        builder.enableCapitalMode()
        //        builder.enableSkipView()
        //        builder.disableSqlFilter()
        //        builder.enableSchema()
        //        builder.likeTable()
        //        builder.notLikeTable()
        //        builder.addInclude()
        //        builder.addTablePrefix()
        //        builder.addTableSuffix()
        //        builder.addFieldPrefix()
        //        builder.addFieldSuffix()

        Field[] fields = ReflectUtil.getFields(StrategyConfigValue.class);
        ArrayList<String> replaceFileds = new ArrayList<>();
        replaceFileds.add("entityBuilder");
        replaceFileds.add("controllerBuilder");
        replaceFileds.add("mapperBuilder");
        replaceFileds.add("serviceBuilder");
        Field[] tempFields = replaceFields(fields, replaceFileds);
        setValue(tempFields, value, builder);

        if (value.getEntityBuilder() != null) {
            setEntityConfig(builder.entityBuilder(), value.getEntityBuilder());
        }
        if (value.getControllerBuilder() != null) {
            setControllerConfig(builder.controllerBuilder(), value.getControllerBuilder());
        }
        if (value.getMapperBuilder() != null) {
            setMapperConfig(builder.mapperBuilder(), value.getMapperBuilder());
        }
        if (value.getServiceBuilder() != null) {
            setServiceConfig(builder.serviceBuilder(), value.getServiceBuilder());
        }
    }

    private static void setEntityConfig(Entity.Builder builder, EntityConfigValue value) {
        if (value == null) {
            return;
        }
        //        builder.nameConvert()
        //        builder.superClass()
        //        -- builder.superClassPackageName()
        //        builder.disableSerialVersionUID()
        //        builder.enableColumnConstant()
        //        builder.enableChainModel()
        //        builder.enableLombok()
        //        builder.enableRemoveIsPrefix()
        //        builder.enableTableFieldAnnotation()
        //        builder.enableActiveRecord()
        //        builder.versionColumnName()
        //        builder.versionPropertyName()
        //        builder.logicDeleteColumnName()
        //        builder.logicDeletePropertyName()
        //        builder.naming()
        //        builder.columnNaming()
        //        builder.addSuperEntityColumns()
        //        builder.addIgnoreColumns()
        //        builder.addTableFills()
        //        builder.idType()
        //        builder.convertFileName()
        //        builder.formatFileName()

        Field[] fields = ReflectUtil.getFields(EntityConfigValue.class);
        setValue(fields, value, builder);
    }

    private static void setControllerConfig(Controller.Builder builder, ControllerConfigValue value) {
        if (value == null) {
            return;
        }

        //        builder.superClass()
        //        -- builder.superClassPackageName()
        //        builder.enableHyphenStyle()
        //        builder.enableRestStyle()
        //        builder.convertFileName()
        //        builder.formatFileName()

        Field[] fields = ReflectUtil.getFields(ControllerConfigValue.class);
        setValue(fields, value, builder);
    }

    private static void setMapperConfig(Mapper.Builder builder, MapperConfigValue value) {
        if (value == null) {
            return;
        }

        //        builder.superClass()
        //        builder.enableMapperAnnotation()
        //        builder.enableBaseResultMap()
        //        builder.enableBaseColumnList()
        //        builder.cache()
        //        builder.convertMapperFileName()
        //        builder.convertXmlFileName()
        //        builder.formatMapperFileName()
        //        builder.formatXmlFileName()

        Field[] fields = ReflectUtil.getFields(MapperConfigValue.class);
        setValue(fields, value, builder);
    }

    private static void setServiceConfig(Service.Builder builder, ServiceConfigValue value) {
        if (value == null) {
            return;
        }

        //        builder.superServiceClass()
        //        builder.superServiceImplClass()
        //        builder.convertServiceFileName()
        //        builder.convertServiceImplFileName()
        //        builder.formatServiceFileName()
        //        builder.formatServiceImplFileName()

        Field[] fields = ReflectUtil.getFields(ServiceConfigValue.class);
        setValue(fields, value, builder);
    }

    private static Field[] replaceFields(Field[] source, ArrayList<String> replaceFileds) {
        ArrayList<Field> newFields = new ArrayList<>();
        for (Field filed : source) {
            if (!replaceFileds.contains(filed.getName())) {
                newFields.add(filed);
            }
        }
        Field[] tempFields = new Field[newFields.size()];
        return newFields.toArray(tempFields);
    }
}
