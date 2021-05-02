/*
 * @Author: 钟凯
 * @Date: 2021-02-11 22:37:45
 * @LastEditTime: 2021-02-28 11:20:36
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\system.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('../base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const System = app.model.define('system', {
    ...baseModel,
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_systems',
    paranoid: true,
  });


  return System;
};
