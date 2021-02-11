/*
 * @Author: 钟凯
 * @Date: 2021-02-11 22:37:45
 * @LastEditTime: 2021-02-12 01:03:39
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\set.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Set = app.model.define('set', {
    id: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true },
    uuid: { type: DataTypes.UUID, defaultValue: DataTypes.UUIDV4, allowNull: false },
    name: { type: DataTypes.STRING, allowNull: false, unique: true, comment: '数据集合名称，唯一' },
    code: { type: DataTypes.STRING, allowNull: false, comment: '代码值' },
    state: { type: DataTypes.INTEGER, allowNull: false, comment: '状态，1：启用 ，2：禁用' },
    items: { type: DataTypes.JSON, allowNull: false, defaultValue: [], comment: '数据项集合' },
    created_at: DataTypes.DATE,
    updated_at: DataTypes.DATE,
  }, {
    tableName: 'model_sets',
    paranoid: true,
  });

  return Set;
};
