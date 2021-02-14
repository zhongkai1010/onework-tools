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
      enable: 1, // 启用
      disable: 2, // 禁用
    },
    order: {
      defaluet: 0, // 默认
      desc: 1, // 降序
      asc: 2, // 升序
    },
    page: {
      maxlimit: 1000, // 分页最大显示个数
      minpage: 1, // 最小页数
    },
  },
  model: {
    itemType: { // 数据项类型
      string: 1, // 字符
      integer: 2, // 整型
      number: 3, // 数字
      boolean: 4, // 布尔
      date: 5, // 日期
      datetime: 6, // 时间
    },
    dataModelType: {
      clsss: 1, // 类
      abstract: 2, // 抽象
      interface: 3, // 接口
    },
    behaviorParamType: {
      no: 0, // 无
      value: 1, // 值
      object: 2, // 对象
    },
  },
};
module.exports = appCode;
