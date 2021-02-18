/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:34:51
 * @LastEditTime: 2021-02-18 18:43:26
 * @LastEditors: 钟凯
 * @Description: Sequelize的数据模型Model文件
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\model\data.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const AppCode = require('../core/appCode');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Data = app.model.define('data', {
    id: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true },
    uid: { type: DataTypes.UUID, defaultValue: DataTypes.UUIDV4, allowNull: false },
    name: { type: DataTypes.STRING, allowNull: false, comment: '数据项名称，唯一' },
    code: { type: DataTypes.STRING, allowNull: false, comment: '代码值' },
    type: { type: DataTypes.STRING, allowNull: false, defaultValue: AppCode.model.dataModelType.clsss, comment: '数据项类型' },
    status: { type: DataTypes.STRING, allowNull: false, defaultValue: AppCode.common.status.enable, comment: '状态' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'model_datas',
    paranoid: true,
  });

  return Data;
};
