/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:14:42
 * @LastEditTime: 2021-03-31 15:38:03
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\database\connection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const BaseModel = require('../base');


module.exports = app => {
  const { STRING, INTEGER, JSON } = app.Sequelize;

  const Connection = app.model.define('connection', {
    ...BaseModel,
    name: { type: STRING, allowNull: true, comment: '连接名称' },
    dbType: { type: STRING, allowNull: false, comment: '数据库类型' },
    database: { type: STRING, allowNull: true, comment: '默认数据库' },
    username: { type: STRING, allowNull: false, comment: '连接用户名' },
    password: { type: STRING, allowNull: false, comment: '连接密码' },
    host: { type: STRING, allowNull: false, comment: '主机地址' },
    port: { type: INTEGER, allowNull: false, comment: '端口' },
    config: { type: JSON, allowNull: true, comment: '其它配置' },
    description: { type: STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_connections',
    paranoid: true,
  });

  return Connection;
};
