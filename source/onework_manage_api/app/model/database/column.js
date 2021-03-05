/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:58:53
 * @LastEditTime: 2021-03-05 15:52:21
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\model\database\column.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('../base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;
  const Column = app.model.define('column', {
    ...baseModel,
    cnUid: { type: DataTypes.STRING, allowNull: true, comment: '连接uid' },
    dbUid: { type: DataTypes.STRING, allowNull: true, comment: '数据库uid' },
    tbUid: { type: DataTypes.STRING, allowNull: true, comment: '数据库表uid' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_columns',
    paranoid: true,
  });
  return Column;
};
