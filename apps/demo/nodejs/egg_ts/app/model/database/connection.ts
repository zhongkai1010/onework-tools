/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:14:42
 * @LastEditTime: 2021-03-11 09:16:29
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\model\database\connection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { Application, Ow, Sequelize } from 'egg';
import { DataTypes } from 'sequelize';

import baseModel from '../base';


export default (app:Application) => {

  const Connection = app.model.define<Sequelize.Database.Connection, Ow.Database.Connection>('connection', {
    ...baseModel,
    name: { type: DataTypes.STRING, allowNull: true, comment: '连接名称' },
    dbType: { type: DataTypes.STRING, allowNull: false, comment: '数据库类型' },
    database: { type: DataTypes.STRING, allowNull: true, comment: '默认数据库' },
    username: { type: DataTypes.STRING, allowNull: false, comment: '连接用户名' },
    password: { type: DataTypes.STRING, allowNull: false, comment: '连接密码' },
    host: { type: DataTypes.STRING, allowNull: false, comment: '主机地址' },
    port: { type: DataTypes.INTEGER, allowNull: false, comment: '端口' },
    config: { type: DataTypes.JSON, allowNull: true, comment: '其它配置' },
    description: { type: DataTypes.STRING, allowNull: true, comment: '描述' },
  }, {
    tableName: 'ow_database_connections',
    paranoid: true,
  });


  return Connection;
};
