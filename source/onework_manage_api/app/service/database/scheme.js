/*
 * @Author: 钟凯
 * @Date: 2021-03-01 20:16:52
 * @LastEditTime: 2021-03-05 15:26:48
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\service\database\scheme.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Service = require('egg').Service;
const AppError = require('../../core/appError');
const { Sequelize } = require('sequelize');

class SchemeService extends Service {
  constructor(ctx) {
    super(ctx);
    this.ConnectionModel = this.ctx.model.Database.Connection;
  }

  /**
   * @description: 构建连接uid获取连接下所有的数据库
   * @param {*} params
   * @return {*}
   */
  async getSchemeData(params) {
    // 初始化对象
    const ctx = this.ctx;
    // 查询数据
    const result = this._connectionExecute(params.uid, params.database, async (connection, sequelize) => {
      let sql = ctx.app.appCode.sql[connection.dbType][params.type];
      if (params.type === 'table') {
        if (!params.database) { throw new AppError('未指定数据库名，无法查询数据'); }
        sql = sql.replace('${database}', params.database);
      }
      if (params.type === 'column') {
        if (!params.database) { throw new AppError('未指定数据库名，无法查询数据'); }
        sql = sql.replace('${database}', params.database);
        if (!params.table) { throw new AppError('未指定数据表名，无法查询数据'); }
        sql = sql.replace('${table}', params.table);
      }
      const data = await sequelize.query(sql, { type: Sequelize.QueryTypes.SELECT });
      return data;
    });
    // 返回结果
    return result;
  }

  /**
   * @description:
   * @param {*} connUid
   * @param {*} database
   * @param {*} callbackFun
   * @return {*}
   */
  async _connectionExecute(connUid, database, callbackFun) {
    // 验证数据
    const connection = await this.ConnectionModel.findByPk(connUid);
    if (connection == null) {
      throw new AppError('该连接信息不存在，无法获取数据库信息');
    }
    // TODO TLS版本
    // Connection lost - 3540:error:1425F102:SSL routines:ssl_choose_client_version:unsupported protocol:c:\ws\deps\openssl\openssl\ssl\statem\statem_lib.c:1922:
    // 需要设置  encrypt: false,
    const config = {
      ...connection.config,
      dialect: connection.dbType,
      database: typeof (database) === 'string' ? database : (connection.database || ''),
      username: connection.username,
      password: connection.password,
      host: connection.host,
      port: connection.port,
      dialectOptions: {
        options: {
          encrypt: false,
        },
      },
    };
    // 查询数据
    const sequelize = new Sequelize(config.database, config.username, config.password, config);
    let result;
    if (typeof (database) === 'function') {
      result = await database(connection, sequelize);
    }
    if (typeof (callbackFun) === 'function') {
      result = await callbackFun(connection, sequelize);
    }
    sequelize.close();
    return result;
  }
}

module.exports = SchemeService;
