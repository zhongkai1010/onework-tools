/*
 * @Author: 钟凯
 * @Date: 2021-03-01 20:16:52
 * @LastEditTime: 2021-03-19 10:28:48
 * @LastEditors: 钟凯
 * @description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\demo\nodejs\egg_ts\app\service\database\scheme.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { Service } from 'egg';
import { AppError, AppCode } from '../../core/index';
import { Sequelize, QueryTypes } from 'sequelize';

export default class SchemeService extends Service {
  protected ConnectionModel = this.ctx.model.Database.Connection;
  protected TableModel = this.ctx.model.Database.Table;
  protected ColumnModel = this.ctx.model.Database.Column;
  protected DatabaseModel = this.ctx.model.Database.Database;
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
  public async getConnectionDataBases(connection:Egg.Sequelize.Database.Connection):Promise<Egg.Sequelize.Database.Database[]> {
    // 初始化对象
    let datas = [] as Egg.Sequelize.Database.Database[];
    try {
      const sequelize = this.createSequelize(connection);
      const sql = AppCode.sql[connection.dbType].database;
      const dbDatabases = await sequelize.query(sql, { type: QueryTypes.SELECT }) as { name:string}[];
      const databases = await this.DatabaseModel.findAll({ where: { cnUid: connection.uid } });
      await sequelize.close();
      if (dbDatabases.length === 0) {
        datas = await this.DatabaseModel.findAll({ where: { cnUid: connection.uid } });
        datas = datas.map(t => { return { ...t.dataValues, isOnline: false }; });
      } else {
        // 装载连接正常返回的数据库
        for (let i = 0; i < dbDatabases.length; i += 1) {
          const dbDatabase = dbDatabases[i] as { name:string};
          let database = databases.find(t => t.name === dbDatabase.name);
          if (database) {
            // 数据库中有与连接数据库匹配，就返回数据库中的数据
            datas.push({ ...database.dataValues, isOnline: true });
          } else {
            // 创建连接中返回的数据库，写入数据库
            database = await this.DatabaseModel.create({
              name: dbDatabase.name,
              code: dbDatabase.name,
              cnUid: connection.uid,
              isSync: false,
            });
            datas.push({ ...database.dataValues, isOnline: true });
          }
        }
        // 装载离线数据库
        const dbNames = dbDatabases.map(t => t.name);
        let offlineDb = databases.filter(t => !dbNames.includes(t.name));
        offlineDb = offlineDb.map(t => { return { ...t.dataValues, isOnline: true }; });
        datas.push(...offlineDb);
      }
    } catch (error) {
      datas = await this.DatabaseModel.findAll({ where: { cnUid: connection.uid } });
      datas = datas.map(t => { return { ...t.dataValues, isOnline: false }; });
    }
    return datas;
  }

  /**
   * @description 获取连接下指定的数据库所有表
   * @param {*} connection 连接信息
   * @param {*} dbName 数据库名称
   * @return {*} 数据库表数据
   */
  public async getDatabaseTables(connection:Egg.Sequelize.Database.Connection, dbName:string): Promise<any> {
    const tables = await this.TableModel.findAll({ where: {
      cnUid: connection.uid,
      dbName,
    }, order: [[ 'code', 'desc' ]] });
    return tables;
  }

  /**
   * @description   获取表数据，包括字段信息
   * @param {string} uid 表uid
   * @return {Egg.Sequelize.Database.Table} 返回表信息
   */
  public async getTableColumns(uid:string):Promise<Egg.Sequelize.Database.Column[]> {
    const table = await this.TableModel.findByPk(uid);
    if (table == null) {
      throw new AppError('该数据库表数据不存在，无法获取详情信息');
    }
    return await this.ColumnModel.findAll({ where: { tbUid: table.uid } });
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
    const sequelize = this.createSequelize(connection, dbName);
    // 测试连接是否正常
    try {
      await sequelize.authenticate({
        transaction: undefined,
      });
    } catch (error) {
      if (this.ctx.app.env === 'local') {
        throw error;
      }
      throw new AppError(`无法连接${connection.name}数据库，同步失败`);
    }
    // 验证数据库
    let database = await this.DatabaseModel.findOne({
      where: {
        cnUid: connection.uid,
        name: dbName,
      },
    });
    if (database === null) {
      throw new AppError(`${dbName}数据库不存在，无法进行同步结构`);
    }
    // 删除历史数据表
    await this.TableModel.destroy({ where: {
      cnUid: connection.uid,
      dbUid: database.uid,
    } });
    // 删除所属数据库的所有字段
    await this.ColumnModel.destroy({ where: {
      cnUid: connection.uid,
      dbUid: database.uid,
    } });
    // 查询表
    let tabSql = AppCode.sql[connection.dbType].table;
    tabSql = tabSql.replace('${database}', dbName);
    const dbTables = await sequelize.query<Egg.Ow.DbTable>(tabSql, { type: QueryTypes.SELECT });

    const addTables = [] as Egg.Ow.Database.Table[];
    for (let i = 0; i < dbTables.length; i++) {
      const dbTable = dbTables[i];
      addTables.push({
        name: dbTable.name,
        code: dbTable.code,
        cnUid: connection.uid,
        dbUid: database.uid,
        dbName,
        description: dbTable.name,
      });
    }
    const result:Egg.Sequelize.Database.Table[] = [];
    // 批量插入表数据
    const tables = await this.TableModel.bulkCreate(addTables);
    const addColumns = [] as Egg.Ow.Database.Column[];
    for (let i = 0; i < tables.length; i += 1) {
      const table = tables[i].dataValues;
      let columnSql = AppCode.sql[connection.dbType].column;
      columnSql = columnSql.replace('${database}', dbName);
      columnSql = columnSql.replace('${table}', table.code);
      const dbColumns = await sequelize.query<Egg.Ow.DbColumn>(columnSql, { type: QueryTypes.SELECT });
      for (let j = 0; j < dbColumns.length; j++) {
        const dbColumn = dbColumns[j];
        addColumns.push({
          cnUid: connection.uid,
          tbUid: table.uid,
          dbUid: database.uid,
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
      }
    }
    // 批量插入字段数据
    const columns = await this.ColumnModel.bulkCreate(addColumns);
    // 关闭连接
    await sequelize.close();
    // 标记数据库同步状态
    database.isSync = true;
    database.lastSyncDate = new Date().toDateString();
    database = await database.save();
    // 组织返回结果
    for (let i = 0; i < tables.length; i++) {
      const table = tables[i].dataValues;
      table.columns = columns.filter(t => t.tbUid === table.uid);
      result.push(table);
    }
    // 返回结果
    return { ...database.dataValues, isOnline: true, tables: result };
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
    return new Sequelize(
      config.database,
      config.username,
      config.password,
      config,
    );

  }
}

