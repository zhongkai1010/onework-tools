package com.onework.tools.generator.mybaits;

import com.baomidou.mybatisplus.generator.config.po.LikeTable;
import lombok.Data;
import lombok.experimental.Accessors;

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
@Accessors(chain = true)
public class StrategyConfigValue {

    /**
     * 开启大写命名	默认值:false
     */
    private Boolean enableCapitalMode;

    /**
     * 开启跳过视图	默认值:false
     */
    private Boolean enableSkipView;

    /**
     * 禁用 sql 过滤	默认值:true，语法不能支持使用 sql 过滤表的话，可以考虑关闭此开关
     */
    private Boolean disableSqlFilter;

    /**
     * 启用 schema	默认值:false，多 schema 场景的时候打开
     */
    private Boolean enableSchema;

    /**
     * 模糊表匹配(sql 过滤)	likeTable 与 notLikeTable 只能配置一项
     */
    private LikeTable likeTable;

    /**
     * 模糊表排除(sql 过滤)	likeTable 与 notLikeTable 只能配置一项
     */
    private LikeTable notLikeTable;

    /**
     * 增加表匹配(内存过滤)	include 与 exclude 只能配置一项
     */
    private String[] addInclude;

    /**
     * 增加表排除匹配(内存过滤)	include 与 exclude 只能配置一项
     */
    private String[] addExclude;

    /**
     * 增加过滤表前缀
     */
    private String[] addTablePrefix;

    /**
     * 增加过滤表后缀
     */
    private String[] addTableSuffix;

    /**
     * 增加过滤字段前缀
     */
    private String[] addFieldPrefix;

    /**
     * 增加过滤字段后缀
     */
    private String[] addFieldSuffix;

    /**
     * 实体策略配置
     */
    private EntityConfigValue entityBuilder = new EntityConfigValue();

    /**
     * controller 策略配置
     */
    private ControllerConfigValue controllerBuilder = new ControllerConfigValue();

    /**
     * mapper 策略配置
     */
    private MapperConfigValue mapperBuilder = new MapperConfigValue();

    /**
     * service 策略配置
     */
    private ServiceConfigValue serviceBuilder = new ServiceConfigValue();

}
