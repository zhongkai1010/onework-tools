/*
 * @Author: 钟凯
 * @Date: 2021-03-02 14:37:02
 * @LastEditTime: 2021-03-11 00:13:28
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\service\database\connection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { Service } from 'egg';
import AppError from '../../core/appError';

export default class ConnectionService extends Service {
  protected ConnectionModel = this.ctx.model.Database.Connection;
  protected TableModel = this.ctx.model.Database.Table;
  protected ColumnModel = this.ctx.model.Database.Column;
  /**
   * @description  根据uid获取数据库连接对象
   * @param {string} uid 连接唯一值
   * @return {*} 连接
   */
  async get(uid:string): Promise<Egg.Sequelize.Database.Connection> {
    const connection = await this.ConnectionModel.findByPk(uid);
    if (connection == null) { throw new AppError('该数据库连接信息不存在，操作失败'); }
    return connection;
  }

  /**
   * @description  添加数据库连接
   * @param {Egg} params 新增连接
   * @return {*} 连接
   */
  async add(params:Egg.Ow.Database.Connection): Promise<Egg.Sequelize.Database.Connection> {
    // 初始化参数
    const ConnectionModel = this.ConnectionModel;
    // 验证数据
    let connection = await ConnectionModel.findOne({ where: {
      name: params.name,
    } });
    if (connection !== null) { throw new AppError('该数据连接名称已经存在，无法添加'); }
    // 处理数据
    connection = await ConnectionModel.create({
      name: params.name,
      dbType: params.dbType,
      database: params.database,
      username: params.username,
      password: params.password,
      host: params.host,
      port: params.port,
      config: params.config,
      description: params.description,
    });
    // 返回结果
    return connection;
  }

  /**
   * @description 修改数据库连接
   * @param {Egg} params 修改连接数据
   * @return {*} 连接数据
   */
  async update(params:Egg.Ow.Database.Connection): Promise<Egg.Sequelize.Database.Connection> {
    // 初始化参数
    const ConnectionModel = this.ConnectionModel;
    const Op = this.ctx.app.Sequelize.Op;
    // 验证数据
    let connection = await ConnectionModel.findByPk(params.uid);
    if (connection === null) { throw new AppError('该数据连接数据不存在，无法修改'); }
    const count = await ConnectionModel.count({ where: {
      name: params.name,
      uid: {
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
    return connection;
  }

  /**
   * @description 获取连接列表数据
   * @return {*} 列表数据
   */
  async getList(): Promise<Egg.Sequelize.Database.Connection[]> {
    // 初始化参数
    const ConnectionModel = this.ConnectionModel;
    // 处理数据
    const result = await ConnectionModel.findAll();
    // 返回结果
    return result;
  }

  /**
   * @description 删除连接
   * @param {*} params 连接唯一值集合
   */
  async remove(params: string []): Promise<void> {
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
      await this.TableModel.destroy({ where: { cnUid: element.uid } });
      await this.ColumnModel.destroy({ where: { cnUid: element.uid } });
      await element.destroy();
    }
  }
}

