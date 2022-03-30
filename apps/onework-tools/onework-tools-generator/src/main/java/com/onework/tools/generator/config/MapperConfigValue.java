package com.onework.tools.generator.config;

import com.baomidou.mybatisplus.generator.function.ConverterFileName;
import lombok.Data;
import lombok.experimental.Accessors;
import org.apache.ibatis.cache.Cache;

/**
 * superClass(Class<?>)	设置父类	BaseMapper.class <br/>
 * superClass(String)	设置父类	com.baomidou.global.BaseMapper <br/>
 * enableMapperAnnotation	开启 @Mapper 注解	默认值:false <br/>
 * enableBaseResultMap	启用 BaseResultMap 生成	默认值:false <br/>
 * enableBaseColumnList	启用 BaseColumnList	默认值:false <br/>
 * cache(Class<? extends Cache>)	设置缓存实现类	MyMapperCache.class <br/>
 * convertMapperFileName(ConverterFileName)	转换 mapper 类文件名称 <br/>
 * convertXmlFileName(ConverterFileName)	转换 xml 文件名称 <br/>
 * formatMapperFileName(String)	格式化 mapper 文件名称 <br/>
 * formatXmlFileName(String)	格式化 xml 实现类文件名称 <br/>
 *
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: MapperConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 21:15
 * @version: 1.0
 */
@Data
@Accessors(chain = true)
public class MapperConfigValue {

    /**
     * 设置父类	BaseMapper.class
     */
    private String superClass;

    /**
     * 开启 @Mapper 注解	默认值:false
     */
    private Boolean enableMapperAnnotation;
    /**
     * 启用 BaseResultMap 生成	默认值:false
     */
    private Boolean enableBaseResultMap;
    /**
     * 启用 BaseColumnList	默认值:false
     */
    private Boolean enableBaseColumnList;
    /**
     * 设置缓存实现类	MyMapperCache.class
     */
    private Class<? extends Cache> cache;
    /**
     * 转换 mapper 类文件名称
     */
    private ConverterFileName convertMapperFileName;
    /**
     * 转换 xml 文件名称
     */
    private ConverterFileName convertXmlFileName;
    /**
     * 格式化 mapper 文件名称
     */
    private String formatMapperFileName;
    /**
     * 格式化 xml 实现类文件名称
     */
    private String formatXmlFileName;
}
