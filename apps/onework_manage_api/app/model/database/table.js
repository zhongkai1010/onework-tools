/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:58:18
 * @LastEditTime: 2021-03-06 09:45:36
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\model\database\table.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('../base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Table = app.model.define('table', {
    ...baseModel,
    cnUid: { type: DataTypes.STRING, allowNull: true, comment: '连接uid' },
    dbName: { type: DataTypes.STRING, allowNull: true, comment: '数据库名称' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_tables',
    paranoid: true,
  });


  return Table;
};
