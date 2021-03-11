/*
 * @Author: 钟凯
 * @Date: 2021-03-01 20:16:52
 * @LastEditTime: 2021-03-11 10:26:37
 * @LastEditors: 钟凯
 * @description:
 * @FilePath: \egg_ts\app\service\database\scheme.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { Service } from 'egg';
import AppError from '../../core/appError';
import AppCode from '../../core/appCode';
import { Sequelize, QueryTypes } from 'sequelize';

export default class SchemeService extends Service {
  protected ConnectionModel = this.ctx.model.Database.Connection;
  protected TableModel = this.ctx.model.Database.Table;
  protected ColumnModel = this.ctx.model.Database.Column;

  /**
   * @description  执行原始sql获取数据库结构
   * @param {*} connection 连接
   * @param {*} schemeType database、table、column
   * @param {*} dbName 数据库名称
   * @param {*} tbName 表名称
   * @return {*} 原sql执行结果
   */
  public async getSchemeData(connection:Egg.Sequelize.Database.Connection, schemeType:'database'|'table'|'column', dbName:string, tbName:string):Promise<any> {
    // 初始化对象
    const sequelize = this.createSequelize(connection);
    // 查询数据
    let sql = AppCode.sql[connection.dbType][schemeType];
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
      type: QueryTypes.SELECT,
    });
    await sequelize.close();
    // 返回结果
    return data;
  }

  /**
   * @description  获取连接下所有数据库
   * @param {*} connection 连接信息
   * @return {*} 数据库列表
   */
  public async getDataBase(connection:Egg.Sequelize.Database.Connection):Promise<any> {
    // 初始化对象
    const sequelize = this.createSequelize(connection);
    const sql = AppCode.sql[connection.dbType].database;
    const data = await sequelize.query(sql, { type: QueryTypes.SELECT });
    await sequelize.close();
    return data;
  }

  /**
   * @description 获取连接下指定的数据库所有表
   * @param {*} connection 连接信息
   * @param {*} dbName 数据库名称
   * @return {*} 数据库表数据
   */
  public async getTables(connection:Egg.Sequelize.Database.Connection, dbName:string): Promise<any> {
    const tables = await this.TableModel.findAll({ where: {
      cnUid: connection.uid,
      dbName,
    } });
    return tables;
  }

  /**
   * @description   获取表数据，包括字段信息
   * @param {string} uid 表uid
   * @return {Egg.Sequelize.Database.Table} 返回表信息
   */
  public async getTable(uid:string):Promise<Egg.Sequelize.Database.Table> {
    const table = await this.TableModel.findByPk(uid);
    if (table == null) {
      throw new AppError('该数据库表数据不存在，无法获取详情信息');
    }
    const columns = await this.ColumnModel.findAll({ where: { tbUid: table.uid } });
    table.columns = columns;
    return table;
  }

  /**
   * @description  同步数据库
   * @param {*} connection 数据库连接
   * @param {*} dbName 数据库名称
   * @return {*} 同步结果
   */
  async asyncDataBase(connection:Egg.Sequelize.Database.Connection, dbName:string): Promise<Egg.Sequelize.Database.Table[] > {
    // 初始化对象
    if (connection == null) {
      throw new AppError('该数据库连接信息不存在，无法同步数据库结构');
    }
    if (dbName == null) {
      throw new AppError('请指定数据名称');
    }
    // 创建连接
    const sequelize = this.createSequelize(connection);
    const result:Egg.Sequelize.Database.Table[] = [];
    // 查询表
    let tabSql = AppCode.sql[connection.dbType].table;
    tabSql = tabSql.replace('${database}', dbName);
    const dbTables = await sequelize.query<Egg.Ow.DbTable>(tabSql, { type: QueryTypes.SELECT });
    for (let i = 0; i < dbTables.length; i++) {
      const dbTable = dbTables[i];
      // 删除历史数据表
      this.TableModel.destroy({ where: {
        cnUid: connection.uid,
        dbName,
      } });
      // 创建表
      const table = await this.TableModel.create({
        name: dbTable.name,
        code: dbTable.code,
        cnUid: connection.uid,
        dbName,
        description: dbTable.name,
      });
      const columns = [] as Egg.Sequelize.Database.Column[];
      table.setAttributes('columns', columns);
      // 查询字段
      let columnSql = AppCode.sql[connection.dbType].column;
      columnSql = columnSql.replace('${database}', dbName);
      columnSql = columnSql.replace('${table}', table.code);
      const dbColumns = await sequelize.query<Egg.Ow.DbColumn>(columnSql, { type: QueryTypes.SELECT });
      for (let j = 0; j < dbColumns.length; j++) {
        const dbColumn = dbColumns[j];
        const column = await this.ColumnModel.create({
          cnUid: connection.uid,
          tbUid: table.uid,
          name: dbColumn.name,
          code: dbColumn.code,
          dbName: table.dbName,
          type: dbColumn.type,
          isNull: dbColumn.isNull === 1,
          isUnique: dbColumn.isUnique === 1,
          length: dbColumn.length,
          precision: dbColumn.precision,
          oredr: dbColumn.order,
          defaultValue: dbColumn.defaultValue,
          description: dbColumn.name,
        });
        columns.push(column);
      }
      // table.;
      result.push({ ...table.dataValues, columns });
    }
    // 关闭连接
    await sequelize.close();
    // 返回结果
    return result;
  }

  /**
   * @description  建立不同数据库类型的连接,执行完操作，请关闭连接
   * @param {*} connection  数据库连接
   * @param {*} database 数据库
   * @return {Sequelize} Sequelize对象
   */
  private createSequelize(connection:Egg.Sequelize.Database.Connection, database?:string): Sequelize {
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
      config,
    );
    return sequelize;
  }
}

