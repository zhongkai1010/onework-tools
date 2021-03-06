/*
 * @Author: 钟凯
 * @Date: 2021-03-01 20:16:52
 * @LastEditTime: 2021-03-06 18:59:45
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\service\database\scheme.js
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
    this.TableModel = this.ctx.model.Database.Table;
    this.ColumnModel = this.ctx.model.Database.Column;
  }

  /**
   * @description: 执行原始sql获取数据库结构
   * @param {*} connection 连接
   * @param {*} schemeType database、table、column
   * @param {*} dbName 数据库名称
   * @param {*} tbName 表名称
   * @return {*}
   */
  async getSchemeData(connection, schemeType, dbName, tbName) {
    // 初始化对象
    const ctx = this.ctx;
    const sequelize = this.createSequelize(connection);
    // 查询数据
    let sql = ctx.app.appCode.sql[connection.dbType][schemeType];
    if (schemeType === 'table') {
      if (!dbName) {
        throw new AppError('未指定数据库名，无法查询数据');
      }
      sql = sql.replace('${database}', dbName);
    }
    if (schemeType === 'column') {
      if (!dbName) {
        throw new AppError('未指定数据库名，无法查询数据');
      }
      sql = sql.replace('${database}', dbName);
      if (!tbName) {
        throw new AppError('未指定数据表名，无法查询数据');
      }
      sql = sql.replace('${table}', tbName);
    }
    const data = await sequelize.query(sql, {
      type: Sequelize.QueryTypes.SELECT,
    });
    await sequelize.close();
    // 返回结果
    return data;
  }

  /**
   * @description: 获取数据连接下所有数据库
   * @param {*} connection
   * @return {*}
   */
  async getDataBase(connection) {
    // 初始化对象
    const ctx = this.ctx;
    const sequelize = this.createSequelize(connection);
    const sql = ctx.app.appCode.sql[connection.dbType].database;
    const data = await sequelize.query(sql, { type: Sequelize.QueryTypes.SELECT });
    await sequelize.close();
    return data;
  }

  /**
   * @description:
   * @param {*} connection
   * @param {*} dbName
   * @return {*}
   */
  async getTables(connection, dbName) {
    const tables = await this.TableModel.findAll({ where: {
      cnUid: connection.uid,
      dbName,
    } });
    return tables.map(t => t.dataValues);
  }

  /**
   * @description:  获取表数据，包括字段信息
   * @param {*} uid 表uid
   * @return {*}
   */
  async getTable(uid) {
    const table = await this.TableModel.findByPk(uid);
    if (table == null) {
      throw AppError('该数据库表数据不存在，无法获取详情信息');
    }
    const data = table.dataValues;
    const columns = await this.ColumnModel.findAll({ where: { tbUid: data.uid } });
    data.columns = columns.map(t => t.dataValues);
    return data;
  }

  /**
   * @description: 同步数据库
   * @param {*} connection 数据库连接
   * @param {*} dbName 数据库名称
   * @return {*}
   */
  async asyncDataBase(connection, dbName) {
    // 初始化对象
    const ctx = this.ctx;
    if (connection == null) {
      throw AppError('该数据库连接信息不存在，无法同步数据库结构');
    }
    if (dbName == null) {
      throw AppError('请指定数据名称');
    }
    // 创建连接
    const sequelize = this.createSequelize(connection);
    const result = [];
    // 查询表
    let tabSql = ctx.app.appCode.sql[connection.dbType].table;
    tabSql = tabSql.replace('${database}', dbName);
    const tables = await sequelize.query(tabSql, { type: Sequelize.QueryTypes.SELECT });
    for (let i = 0; i < tables.length; i++) {
      let table = tables[i];
      // 删除历史数据表
      this.TableModel.destroy({ where: {
        cnUid: connection.uid,
        dbName,
      } });
      // 创建表
      table = await this.TableModel.create({
        name: table.name,
        code: table.code,
        cnUid: connection.uid,
        dbName,
        description: table.name,
      });
      const temp_table = table.dataValues;
      temp_table.columns = [];
      // 查询字段
      let columnSql = ctx.app.appCode.sql[connection.dbType].column;
      columnSql = columnSql.replace('${database}', dbName);
      columnSql = columnSql.replace('${table}', table.code);
      const columns = await sequelize.query(columnSql, { type: Sequelize.QueryTypes.SELECT });
      for (let j = 0; j < columns.length; j++) {
        let column = columns[j];
        column = await this.ColumnModel.create({
          cnUid: connection.uid,
          tbUid: table.uid,
          name: column.name,
          code: column.code,
          dbName: table.dbName,
          type: column.type,
          isNull: column.isNull === 1,
          isUnique: column.isUnique === 1,
          length: column.length,
          precision: column.precision,
          oredr: column.oredr,
          defaultValue: table.defaultValue,
          description: column.name,
        });
        temp_table.columns.push(column.dataValues);
      }
      result.push(temp_table);
    }

    // 关闭连接
    await sequelize.close();

    return result;
  }

  /**
   * @description: 建立不同数据库类型的连接,执行完操作，请关闭连接
   * @param {*} connection  数据库连接
   * @param {*} database 数据库
   * @return {*}
   */
  createSequelize(connection, database) {
    const config = {
      ...connection.config,
      dialect: connection.dbType,
      database:
      typeof database === 'string' ? database : connection.database || '',
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
    const sequelize = new Sequelize(
      config.database,
      config.username,
      config.password,
      config
    );
    return sequelize;
  }
}

module.exports = SchemeService;
