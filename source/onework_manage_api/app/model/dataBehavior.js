/*
 * @Author: 钟凯
 * @Date: 2021-02-14 22:34:45
 * @LastEditTime: 2021-02-18 18:43:32
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\model\dataBehavior.js
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
    outputType: { type: DataTypes.STRING, allowNull: false, defaultValue: AppCode.model.behaviorParamType.void, comment: '输出参数类型' },
    outputValue: { type: DataTypes.STRING, allowNull: true, comment: '输出值' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'model_data_behaviors',
    paranoid: true,
  });

  return DataBehavior;
};
