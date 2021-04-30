/*
 * Filename: d:\projects\wmsq_api\app\extend\appCode.js
 * Path: d:\projects\wmsq_api
 * Created Date: Wednesday, July 31st 2019, 10:08:45 am
 * Author: zk
 * 用于存储系统状态值
 * Copyright (c) 2019 Your Company
 */
'use strict';

const appCode = {
  common: {
    status: {
      enable: 'enable', // 启用
      disable: 'disable', // 禁用
    },
    order: {
      desc: 'desc', // 降序
      asc: 'asc', // 升序
    },
    page: {
      maxlimit: 1000, // 分页最大显示个数
      minpage: 1, // 最小页数
    },
  },
  sql: {
    /**
     *  -- 获取数据库
     *  SELECT name FROM Master..SysDatabases ORDER BY name
     *
     *  -- 获取表
     *  SELECT name FROM sysobjects WHERE type = 'U' ORDER BY name
     *
     *  -- 获取字段 name：字段名称、type：类型、isUnique：主键、length：长度
     *  SELECT
     *     a. colorder AS 'order',a.name AS 'code',b.name AS 'type' ,
     *    case when exists( SELECT 1 FROM sysobjects where xtype ='PK' and name in (
     *      SELECT name FROM sysindexes WHERE indid in(
     *      SELECT indid FROM sysindexkeys WHERE id = a .id AND colid =a. colid
     *    ))) then 1 else 0 end AS 'isUnique',
     *    COLUMNPROPERTY( a.id ,a. name,'PRECISION' ) AS 'length',
     *    isnull( COLUMNPROPERTY(a .id, a.name ,'Scale'), 0) AS 'precision',
     *    case when a .isnullable= 1 then 1 else 0 end AS 'isNull',
     *    isnull( e.text ,'') AS 'name',
     *    isnull( g.[value] ,'') AS 'defaultValue'
     *  FROM syscolumns AS a
     *    LEFT JOIN systypes b on a.xusertype=b.xusertype
     *    LEFT JOIN syscomments e on a.cdefault=e.id
     *    LEFT JOIN sys. extended_properties g on a.id =g.major_id and a.colid =g.minor_id
     *  WHERE
     *    a.id = OBJECT_ID('PRP_Device_Additio1')
    **/
    mssql: {
      // name：数据库名称
      database: "SELECT name as 'name', name as 'code' FROM Master..SysDatabases ORDER BY name", // ok
      // code：表名、name：注释
      table: "SELECT a.name AS 'code',  ISNULL(g.[value], a.name)  AS 'name' FROM sys.tables a LEFT JOIN sys.extended_properties g ON( a.object_id = g.major_id AND g.minor_id = 0) ORDER BY a.name",
      // order：顺序、 code：字段名称、type：类型、isUnique：主键、length：长度、precision：精度、isNull：是否未空、name：字段描述、defaultValue：默认值
      column: "SELECT a.colorder AS 'order', a.name AS 'code', b.name AS 'type', CASE WHEN EXISTS( SELECT 1 FROM sysobjects WHERE xtype = 'PK' AND name IN ( SELECT name FROM sysindexes WHERE indid IN ( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid) ) ) THEN 1 ELSE 0 END AS 'isUnique', COLUMNPROPERTY( a.id , a.name, 'PRECISION' ) AS 'length', isnull( COLUMNPROPERTY( a.id, a.name , 'Scale' ), 0 ) AS 'precision', CASE WHEN a.isnullable= 1 THEN 1 ELSE 0 END AS 'isNull', isnull( e.text , '' ) AS 'name', isnull( g.[value], '' ) AS 'defaultValue' FROM syscolumns AS a LEFT JOIN systypes b ON a.xusertype= b.xusertype LEFT JOIN syscomments e ON a.cdefault= e.id LEFT JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id WHERE a.id = OBJECT_ID( '${table}' );",
    },
    /**
     *
     *  SELECT
     *  a.COLUMN_NAME as code,
     *   a.COLUMN_TYPE as type,
     *   a.COLUMN_KEY as  isUnique,
     *   a.CHARACTER_MAXIMUM_LENGTH as length,
     *   a.NUMERIC_PRECISION as 'precision',
     *   a.IS_NULLABLE as isNull,
     *   a.COLUMN_COMMENT as name,
     *   a.COLUMN_DEFAULT as defaultValue
     * FROM
     *  INFORMATION_SCHEMA.COLUMNS a
     *  WHERE
     *   a.TABLE_NAME = '${table}' AND a.TABLE_SCHEMA = '${database}'
     */
    mysql: {
      // name：数据库名称
      database: 'SELECT SCHEMA_NAME AS `name`,SCHEMA_NAME AS `code` FROM INFORMATION_SCHEMA.SCHEMATA ORDER BY name;',
      // code：表名、name：注释
      table: "SELECT a.TABLE_NAME AS 'name', CASE a.TABLE_COMMENT WHEN '' THEN a.TABLE_NAME ELSE a.TABLE_COMMENT END AS 'code' FROM information_schema.TABLES AS a WHERE a.TABLE_SCHEMA = '${database}';",
      // order：顺序、 code：字段名称、type：类型、isUnique：主键、length：长度、precision：精度、isNull：是否未空、name：字段描述、defaultValue：默认值
      column: "SELECT a.ORDINAL_POSITION AS 'order', a.COLUMN_NAME AS 'code', a.COLUMN_TYPE AS type, a.COLUMN_KEY AS isUnique, a.CHARACTER_MAXIMUM_LENGTH AS length, a.NUMERIC_PRECISION AS 'precision', a.IS_NULLABLE AS isNull, a.COLUMN_COMMENT AS 'name', a.COLUMN_DEFAULT AS defaultValue FROM INFORMATION_SCHEMA.COLUMNS a WHERE a.TABLE_NAME = '${table}' AND a.TABLE_SCHEMA = '${database}';",
    },
  },
  model: {
    itemType: { // 数据项类型
      string: 'string', // 文本
      number: 'number', // 数字
      array: 'array', // 数组
      object: 'object', // 对象
      boolean: 'boolean', // 布尔
      integer: 'integer', // 整数
      other: 'other', // 其他
    },
    modelUse: {
      universal: 'universal', // 通用
      input: 'input', // 输出
      output: 'output', // 输入
    },
    behaviorType: { // 行为类型
      read: 'read',
      add: 'add',
      update: 'update',
      delete: 'delete',
    },
  },
};
module.exports = appCode;
