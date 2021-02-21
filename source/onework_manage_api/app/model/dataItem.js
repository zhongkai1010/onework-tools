/*
 * @Author: 钟凯
 * @Date: 2021-02-14 17:59:30
 * @LastEditTime: 2021-02-21 15:13:16
 * @LastEditors: 钟凯
 * @Description: 数据模型
 * @FilePath: \onework_manage_api\app\model\dataItem.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const AppCode = require('../core/appCode');
const baseModel = require('./base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const DataItem = app.model.define('dataItem', {
    ...baseModel,
    dataUid: { type: DataTypes.UUID, allowNull: false, comment: '数据模型uid' },
    itemUid: { type: DataTypes.UUID, allowNull: false, comment: '数据项uid' },
    itemType: { type: DataTypes.STRING, allowNull: false, defaultValue: AppCode.model.itemType.string, comment: '数据项类型' },
    typeValue: { type: DataTypes.STRING, allowNull: true, comment: '数据项类型值' },
    subType: { type: DataTypes.STRING, allowNull: true, defaultValue: AppCode.model.itemType.string, comment: '数组类型子类型' },
    objectRef: { type: DataTypes.STRING, allowNull: true, comment: '对象类型引用值' },
    defaultValue: { type: DataTypes.STRING, allowNull: true, comment: '默认值' },
    isNull: { type: DataTypes.BOOLEAN, allowNull: true, comment: '是否为空' },
    length: { type: DataTypes.INTEGER, allowNull: true, comment: '长度' },
    precision: { type: DataTypes.INTEGER, allowNull: true, comment: '精确度' },
    isUnique: { type: DataTypes.BOOLEAN, allowNull: true, comment: '是否唯一' },
  }, {
    tableName: 'model_data_items',
    paranoid: true,
  });

  return DataItem;
};
