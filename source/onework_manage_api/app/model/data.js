/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:34:51
 * @LastEditTime: 2021-02-14 18:22:17
 * @LastEditors: 钟凯
 * @Description: Sequelize的数据模型Model文件
 * @FilePath: \onework_manage_api\app\model\data.js
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
    type: { type: DataTypes.INTEGER, allowNull: false, defaultValue: 1, comment: '数据项类型，1：类模型、2：抽象模型、3：接口模型' },
    status: { type: DataTypes.INTEGER, allowNull: false, defaultValue: AppCode.common.status.enable, comment: '状态，1：启用、2：禁用' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
    created_at: DataTypes.DATE,
    updated_at: DataTypes.DATE,
  }, {
    tableName: 'model_datas',
    paranoid: true,
  });

  return Data;
};
