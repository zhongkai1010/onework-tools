/*
 * @Author: 钟凯
 * @Date: 2021-02-11 22:37:45
 * @LastEditTime: 2021-02-14 18:23:32
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\collection.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Collection = app.model.define('collection', {
    id: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true },
    uid: { type: DataTypes.UUID, defaultValue: DataTypes.UUIDV4 },
    name: { type: DataTypes.STRING, allowNull: false, comment: '数据集合名称，唯一' },
    code: { type: DataTypes.STRING, allowNull: false, comment: '代码值' },
    items: { type: DataTypes.JSON, allowNull: false, defaultValue: [], comment: '数据项集合' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' }
  }, {
    tableName: 'model_collections',
    paranoid: true,
  });

  return Collection;
};
