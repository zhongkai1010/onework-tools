package com.onework.tools.generator.params;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.generator
 * @className: StrategyConfigParams
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/29 21:09
 * @version: 1.0
 * <p>
 * enableCapitalMode	开启大写命名	默认值:false
 * enableSkipView	开启跳过视图	默认值:false
 * disableSqlFilter	禁用 sql 过滤	默认值:true，语法不能支持使用 sql 过滤表的话，可以考虑关闭此开关
 * enableSchema	启用 schema	默认值:false，多 schema 场景的时候打开
 * likeTable(LikeTable)	模糊表匹配(sql 过滤)	likeTable 与 notLikeTable 只能配置一项
 * notLikeTable(LikeTable)	模糊表排除(sql 过滤)	likeTable 与 notLikeTable 只能配置一项
 * addInclude(String...)	增加表匹配(内存过滤)	include 与 exclude 只能配置一项
 * addExclude(String...)	增加表排除匹配(内存过滤)	include 与 exclude 只能配置一项
 * addTablePrefix(String...)	增加过滤表前缀
 * addTableSuffix(String...)	增加过滤表后缀
 * addFieldPrefix(String...)	增加过滤字段前缀
 * addFieldSuffix(String...)	增加过滤字段后缀
 * entityBuilder	实体策略配置
 * controllerBuilder	controller 策略配置
 * mapperBuilder	mapper 策略配置
 * serviceBuilder	service 策略配置
 * </p>
 */
public class StrategyConfigParams {
}
