/*
 * @Author: 钟凯
 * @Date: 2021-02-14 22:34:45
 * @LastEditTime: 2021-02-14 22:41:13
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\dataBehavior.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const AppCode = require('../core/appCode');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const DataBehavior = app.model.define('behavior', {
    id: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true },
    uid: { type: DataTypes.UUID, defaultValue: DataTypes.UUIDV4, allowNull: false },
    dataUid: { type: DataTypes.UUID, allowNull: false, comment: '数据模型唯一值' },
    behaviorName: { type: DataTypes.STRING, allowNull: true, comment: '行为名称' },
    behaviorCode: { type: DataTypes.STRING, allowNull: true, comment: '行为代码' },
    inputs: { type: DataTypes.JSON, allowNull: false, comment: '输入参数' },
    outputType: { type: DataTypes.INTEGER, allowNull: false, defaultValue: AppCode.model.behaviorParamType.no, comment: '输出参数类型，0：无、1：值，2：集合' },
    outputValue: { type: DataTypes.STRING, allowNull: true, comment: '精确度' },
    created_at: DataTypes.DATE,
    updated_at: DataTypes.DATE,
  }, {
    tableName: 'model_data_behaviors',
    paranoid: true,
  });

  return DataBehavior;
};
