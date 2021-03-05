/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:57:44
 * @LastEditTime: 2021-03-05 15:07:02
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\model\database\db.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const baseModel = require('../base_name_code');

module.exports = app => {
  const { DataTypes } = app.Sequelize;

  const Db = app.model.define('db', {
    ...baseModel,
    cnUid: { type: DataTypes.STRING, allowNull: true, comment: '连接uid' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_dbs',
    paranoid: true,
  });


  return Db;
};
