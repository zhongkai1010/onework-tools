/*
 * @Author: 钟凯
 * @Date: 2021-02-11 22:37:45
 * @LastEditTime: 2021-02-28 11:23:02
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\collection.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('./base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Collection = app.model.define('collection', {
    ...baseModel,
    items: { type: DataTypes.JSON, allowNull: false, defaultValue: [], comment: '数据项集合' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_model_collections',
    paranoid: true,
  });

  return Collection;
};
