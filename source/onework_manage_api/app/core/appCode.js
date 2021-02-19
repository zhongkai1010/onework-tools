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
      string: 'string', // 文本
      number: 'number', // 数字
      array: 'array', // 数组
      object: 'object', // 对象
      boolean: 'boolean', // 布尔
      integer: 'integer', // 整数
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
