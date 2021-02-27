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
