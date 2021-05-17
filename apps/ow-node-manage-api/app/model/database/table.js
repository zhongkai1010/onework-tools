/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:58:18
 * @LastEditTime: 2021-03-31 15:38:23
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\database\table.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const NameCodeModel = require('../base_name_code');


module.exports = app => {
  const { STRING, TEXT } = app.Sequelize;

  const Table = app.model.define('table', {
    ...NameCodeModel,
    cnUid: { type: STRING, allowNull: true, comment: '连接uid' },
    dbUid: { type: STRING, allowNull: true, comment: '数据库uid' },
    dbName: { type: STRING, allowNull: true, comment: '数据库名称' },
    description: { type: TEXT, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_tables',
    paranoid: true,
  });


  return Table;
};
