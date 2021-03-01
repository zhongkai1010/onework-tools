/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:58:53
 * @LastEditTime: 2021-03-01 14:59:59
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\database\columns.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('../base');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Column = app.model.define('column', {
    ...baseModel,
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_columns',
    paranoid: true,
  });


  return Column;
};
