/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:14:42
 * @LastEditTime: 2021-03-01 14:36:14
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\database\connection.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('../base');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Connection = app.model.define('connection', {
    ...baseModel,
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },

  }, {
    tableName: 'ow_database_connections',
    paranoid: true,
  });


  return Connection;
};
