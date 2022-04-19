package com.onework.tools.generator.mybaits;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.generator.IFill;
import com.baomidou.mybatisplus.generator.config.rules.NamingStrategy;
import com.baomidou.mybatisplus.generator.function.ConverterFileName;
import lombok.Data;
import lombok.experimental.Accessors;

/**
 * nameConvert(INameConvert)	名称转换实现 <br/>
 * superClass(Class<?>)	设置父类	BaseEntity.class <br/>
 * superClass(String)	设置父类	com.baomidou.global.BaseEntity <br/>
 * disableSerialVersionUID	禁用生成 serialVersionUID	默认值:true <br/>
 * enableColumnConstant	开启生成字段常量	默认值:false <br/>
 * enableChainModel	开启链式模型	默认值:false <br/>
 * enableLombok	开启 lombok 模型	默认值:false <br/>
 * enableRemoveIsPrefix	开启 Boolean 类型字段移除 is 前缀	默认值:false <br/>
 * enableTableFieldAnnotation	开启生成实体时生成字段注解	默认值:false <br/>
 * enableActiveRecord	开启 ActiveRecord 模型	默认值:false <br/>
 * versionColumnName(String)	乐观锁字段名(数据库) <br/>
 * versionPropertyName(String)	乐观锁属性名(实体) <br/>
 * logicDeleteColumnName(String)	逻辑删除字段名(数据库) <br/>
 * logicDeletePropertyName(String)	逻辑删除属性名(实体) <br/>
 * naming	数据库表映射到实体的命名策略	默认下划线转驼峰命名:NamingStrategy.underline_to_camel <br/>
 * columnNaming	数据库表字段映射到实体的命名策略	默认为 null，未指定按照 naming 执行 <br/>
 * addSuperEntityColumns(String...)	添加父类公共字段 <br/>
 * addIgnoreColumns(String...)	添加忽略字段 <br/>
 * addTableFills(IFill...)	添加表字段填充 <br/>
 * addTableFills(List<IFill>)	添加表字段填充 <br/>
 * idType(IdType)	全局主键类型 <br/>
 * convertFileName(ConverterFileName)	转换文件名称 <br/>
 * formatFileName(String)	格式化文件名称 <br/>
 *
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: EntityConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 21:14
 * @version: 1.0
 */
@Data
@Accessors(chain = true)
public class EntityConfigValue {

    /**
     * 名称转换实现
     */
    private String nameConvert;

    /**
     * 设置父类	com.baomidou.global.BaseEntity
     */
    private String superClass;

    /**
     * 禁用生成 serialVersionUID	默认值:true
     */
    private Boolean disableSerialVersionUID;

    /**
     * 开启生成字段常量	默认值:false
     */
    private Boolean enableColumnConstant;

    /**
     * 开启链式模型	默认值:false
     */
    private Boolean enableChainModel;

    /**
     * 开启 lombok 模型	默认值:false
     */
    private Boolean enableLombok;

    /**
     * 开启 Boolean 类型字段移除 is 前缀	默认值:false
     */
    private Boolean enableRemoveIsPrefix;

    /**
     * 开启生成实体时生成字段注解	默认值:false
     */
    private Boolean enableTableFieldAnnotation;

    /**
     * 开启 ActiveRecord 模型	默认值:false
     */
    private Boolean enableActiveRecord;

    /**
     * 乐观锁字段名(数据库)
     */
    private String versionColumnName;

    /**
     * 乐观锁属性名(实体)
     */
    private String versionPropertyName;

    /**
     * 逻辑删除字段名(数据库)
     */
    private String logicDeleteColumnName;

    /**
     * 逻辑删除属性名(实体)
     */
    private String logicDeletePropertyName;

    /**
     * 数据库表映射到实体的命名策略	默认下划线转驼峰命名:NamingStrategy.underline_to_camel
     */
    private NamingStrategy naming;

    /**
     * 数据库表字段映射到实体的命名策略	默认为 null，未指定按照 naming 执行
     */
    private NamingStrategy columnNaming;

    /**
     * 添加父类公共字段
     */
    private String[] addSuperEntityColumns;

    /**
     * 添加忽略字段
     */
    private String[] addIgnoreColumns;

    /**
     * 添加表字段填充
     */
    private IFill[] addTableFills;

    /**
     * 全局主键类型
     */
    private IdType idType;

    /**
     * 转换文件名称
     */
    private ConverterFileName convertFileName;

    /**
     * 格式化文件名称
     */
    private String formatFileName;
}
