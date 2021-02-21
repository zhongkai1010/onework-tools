/*
 * @Author: 钟凯
 * @Date: 2021-02-21 15:28:47
 * @LastEditTime: 2021-02-21 15:30:38
 * @LastEditors: 钟凯
 * @Description: 模块的数据模型
 * @FilePath: \onework_manage_api\app\model\moduleModel.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('./base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const ModuleModel = app.model.define('moduleModel', {
    ...baseModel,
    modelUid: { type: DataTypes.UUID, allowNull: false, comment: '数据模型uid' },
    moduleUid: { type: DataTypes.UUID, allowNull: false, comment: '模块uid' },
  }, {
    tableName: 'module_models',
    paranoid: true,
  });


  return ModuleModel;
};
