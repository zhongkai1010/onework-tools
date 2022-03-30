package com.onework.tools.generator.config;

import com.baomidou.mybatisplus.generator.config.po.LikeTable;
import lombok.Data;

/**
 * enableCapitalMode	开启大写命名	默认值:false <br/>
 * enableSkipView	开启跳过视图	默认值:false <br/>
 * disableSqlFilter	禁用 sql 过滤	默认值:true，语法不能支持使用 sql 过滤表的话，可以考虑关闭此开关 <br/>
 * enableSchema	启用 schema	默认值:false，多 schema 场景的时候打开 <br/>
 * likeTable(LikeTable)	模糊表匹配(sql 过滤)	likeTable 与 notLikeTable 只能配置一项 <br/>
 * notLikeTable(LikeTable)	模糊表排除(sql 过滤)	likeTable 与 notLikeTable 只能配置一项 <br/>
 * addInclude(String...)	增加表匹配(内存过滤)	include 与 exclude 只能配置一项 <br/>
 * addExclude(String...)	增加表排除匹配(内存过滤)	include 与 exclude 只能配置一项 <br/>
 * addTablePrefix(String...)	增加过滤表前缀 <br/>
 * addTableSuffix(String...)	增加过滤表后缀 <br/>
 * addFieldPrefix(String...)	增加过滤字段前缀 <br/>
 * addFieldSuffix(String...)	增加过滤字段后缀 <br/>
 * entityBuilder	实体策略配置 <br/>
 * controllerBuilder	controller 策略配置 <br/>
 * mapperBuilder	mapper 策略配置 <br/>
 * serviceBuilder	service 策略配置 <br/>
 *
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: StrategyConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 21:09
 * @version: 1.0
 */
@Data
public class StrategyConfigValue {

    /**
     * 开启大写命名	默认值:false
     */
    private Boolean enableCapitalMode = false;

    /**
     * 开启跳过视图	默认值:false
     */
    private Boolean enableSkipView = false;

    /**
     * 禁用 sql 过滤	默认值:true，语法不能支持使用 sql 过滤表的话，可以考虑关闭此开关
     */
    private Boolean disableSqlFilter = true;

    /**
     * 启用 schema	默认值:false，多 schema 场景的时候打开
     */
    private Boolean enableSchema = false;

    /**
     * 模糊表匹配(sql 过滤)	likeTable 与 notLikeTable 只能配置一项
     */
    private LikeTable likeTable = null;

    /**
     * 模糊表排除(sql 过滤)	likeTable 与 notLikeTable 只能配置一项
     */
    private LikeTable notLikeTable = null;

    /**
     * 增加表匹配(内存过滤)	include 与 exclude 只能配置一项
     */
    private String[] addInclude = null;

    /**
     * 增加表排除匹配(内存过滤)	include 与 exclude 只能配置一项
     */
    private String[] addExclude = null;

    /**
     * 增加过滤表前缀
     */
    private String[] addTablePrefix = null;

    /**
     * 增加过滤表后缀
     */
    private String[] addTableSuffix = null;

    /**
     * 增加过滤字段前缀
     */
    private String[] addFieldPrefix = null;

    /**
     * 增加过滤字段后缀
     */
    private String[] addFieldSuffix = null;

    /**
     * 实体策略配置
     */
    private EntityConfigValue entityBuilder = null;

    /**
     * controller 策略配置
     */
    private ControllerConfigValue controllerBuilder = null;

    /**
     * mapper 策略配置
     */
    private MapperConfigValue mapperBuilder = null;

    /**
     * service 策略配置
     */
    private ServiceConfigValue serviceBuilder = null;

}
