/*
 * @Author: 钟凯
 * @Date: 2021-03-02 14:37:02
 * @LastEditTime: 2021-03-02 16:13:30
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\service\database\connection.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Service = require('egg').Service;
const AppError = require('../../core/appError');

class ConnectionService extends Service {
  constructor(ctx) {
    super(ctx);
    this.ConnectionModel = this.ctx.model.Database.Connection;
  }

  /**
   * @description: 添加数据库连接
   * @param {*} params
   * @return {*}
   */
  async add(params) {
    // 初始化参数
    const ConnectionModel = this.ConnectionModel;
    // 验证数据
    let connection = await ConnectionModel.findOne({ where: {
      name: params.name,
    } });
    if (connection !== null) { throw new AppError('该数据连接名称已经存在，无法添加'); }
    // 处理数据
    connection = {
      name: params.name,
      dbType: params.dbType,
      database: params.database,
      username: params.username,
      password: params.password,
      host: params.host,
      port: params.port,
      config: params.config,
      description: params.description,
    };
    connection = await ConnectionModel.create(connection);
    // 返回结果
    return connection.dataValues;
  }

  /**
   * @description: 修改数据库连接
   * @param {*} params
   * @return {*}
   */
  async update(params) {
    // 初始化参数
    const ConnectionModel = this.ConnectionModel;
    const Op = this.ctx.app.Sequelize.Op;
    // 验证数据
    let connection = await ConnectionModel.findByPk(params.uid);
    if (connection === null) { throw new AppError('该数据连接数据不存在，无法修改'); }
    const count = await ConnectionModel.count({ where: {
      name: params.name,
      id: {
        [Op.ne]: connection.uid,
      },
    } });
    if (count > 0) { throw new AppError('该数据连接名称已经存在，无法修改'); }
    // 处理数据
    connection.name = params.name;
    connection.dbType = params.dbType;
    connection.database = params.database;
    connection.username = params.username;
    connection.password = params.password;
    connection.host = params.host;
    connection.port = params.port;
    connection.config = params.config;
    connection.description = params.description;
    connection = await connection.save();
    // 返回结果
    return connection.dataValues;
  }

  /**
   * @description:
   * @param {*} params
   * @return {*}
   */
  async getList() {
    // 初始化参数
    const ConnectionModel = this.ConnectionModel;
    // 处理数据
    const result = await ConnectionModel.findAll();
    // 返回结果
    return result.map(t => t.dataValues);
  }

  /**
   * @description:
   * @param {*} params
   * @return {*}
   */
  async remove(params) {
    // 初始化参数
    const ConnectionModel = this.ConnectionModel;
    const Op = this.ctx.app.Sequelize.Op;
    // 查询需要删除数据
    const datas = await ConnectionModel.findAll({ where: {
      uid: {
        [Op.in]: params,
      },
    } });
    if (params.length !== datas.length) { throw new AppError('删除数据中存在错误参数值，无法进行删除'); }
    // 删除数据
    for (let i = 0; i < datas.length; i++) {
      const element = datas[i];
      await element.destroy();
    }
  }
}

module.exports = ConnectionService;
