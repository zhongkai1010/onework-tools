/*
 * @Author: 钟凯
 * @Date: 2021-02-21 15:29:15
 * @LastEditTime: 2021-02-21 15:37:08
 * @LastEditors: 钟凯
 * @Description: 系统模块
 * @FilePath: \onework_manage_api\app\model\systemModule.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('./base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const SystemModule = app.model.define('systemModule', {
    ...baseModel,
    systemUid: { type: DataTypes.UUID, allowNull: false, comment: '系统uid' },
    moduleUid: { type: DataTypes.UUID, allowNull: false, comment: '模块uid' },
  }, {
    tableName: 'system_modules',
    paranoid: true,
  });


  return SystemModule;
};
