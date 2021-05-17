/*
 * @Author: 钟凯
 * @Date: 2021-02-21 15:28:47
 * @LastEditTime: 2021-03-31 15:38:41
 * @LastEditors: 钟凯
 * @Description: 模块的数据模型
 * @FilePath: \egg_ts\app\model\module\moduleModel.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const BaseModel = require('../base');

module.exports = app => {
  const { UUID } = app.Sequelize;

  const ModuleModel = app.model.define('moduleModel', {
    ...BaseModel,
    modelUid: { type: UUID, allowNull: false, comment: '数据模型uid' },
    moduleUid: { type: UUID, allowNull: false, comment: '模块uid' },
  }, {
    tableName: 'ow_module_models',
    paranoid: true,
  });


  return ModuleModel;
};
