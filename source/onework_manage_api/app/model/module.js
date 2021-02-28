/*
 * @Author: 钟凯
 * @Date: 2021-02-21 15:24:45
 * @LastEditTime: 2021-02-21 15:24:46
 * @LastEditors: 钟凯
 * @Description: 模块
 * @FilePath: \onework_manage_api\app\model\module.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('./base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Module = app.model.define('module', {
    ...baseModel,
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },

  }, {
    tableName: 'ow_modules',
    paranoid: true,
  });


  return Module;
};
