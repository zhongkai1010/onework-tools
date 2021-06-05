/*
 * @Author: 钟凯
 * @Date: 2021-03-19 11:14:36
 * @LastEditTime: 2021-03-31 15:39:16
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\tool\comparison.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const NameCodeModel = require('../base_name_code');

module.exports = app => {
  const { STRING, JSON } = app.Sequelize;

  const Comparison = app.model.define('comparison', {
    ...NameCodeModel,
    defaultValue: { type: STRING, allowNull: false, comment: '缺省值' },
    datas: { type: JSON, defaultValue: [], allowNull: false, comment: '对照数据' },
  }, {
    tableName: 'ow_tool_comparisons',
    paranoid: true,
  });

  return Comparison;
};
