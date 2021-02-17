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
  model: {
    itemType: { // 数据项类型
      character: 'character', // 字符
      integer: 'integer', // 整型
      digital: 'digital', // 数字
      boolean: 'boolean', // 布尔
      date: 'enumerate', // 日期
      datetime: 'date', // 时间
    },
    dataModelType: {
      clsss: 'clsss', // 类
      abstract: 'abstract', // 抽象
      interface: 'interface', // 接口
    },
    behaviorParamType: {
      void: 'void', // 无
      value: 'value', // 值
      object: 'object', // 对象
    },
  },
};
module.exports = appCode;
