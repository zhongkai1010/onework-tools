/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:34:51
 * @LastEditTime: 2021-02-21 15:08:38
 * @LastEditors: 钟凯
 * @Description: Sequelize的数据模型Model文件
 * @FilePath: \onework_manage_api\app\model\data.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const AppCode = require('../../core/appCode');
const baseModel = require('../base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Data = app.model.define('data', {
    ...baseModel,
    use: { type: DataTypes.STRING, allowNull: false, defaultValue: AppCode.model.modelUse.universal, comment: '用途' },
    status: { type: DataTypes.STRING, allowNull: false, defaultValue: AppCode.common.status.enable, comment: '状态' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_model_datas',
    paranoid: true,
  });

  return Data;
};
