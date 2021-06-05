/*
 * @Author: 钟凯
 * @Date: 2021-03-17 10:52:38
 * @LastEditTime: 2021-03-31 15:38:14
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\database\database.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const NameCodeModel = require('../base_name_code');


module.exports = app => {
  const { STRING, DATE, BOOLEAN } = app.Sequelize;

  const Database = app.model.define('database', {
    ...NameCodeModel,
    cnUid: { type: STRING, allowNull: false, comment: '连接uid' },
    isSync: { type: BOOLEAN, defaultValue: false, allowNull: false, comment: '是否同步' },
    lastSyncDate: { type: DATE, allowNull: true, comment: '最后同步时间' },
    description: { type: STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_dbs',
    paranoid: true,
  });

  return Database;
};
