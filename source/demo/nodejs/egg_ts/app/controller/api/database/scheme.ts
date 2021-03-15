/*
 * @Author: 钟凯
 * @Date: 2021-02-28 11:26:30
 * @LastEditTime: 2021-03-15 16:59:11
 * @LastEditors: 钟凯
 * @description
 * @FilePath: \onework_manage_webd:\github\OneWork\source\demo\nodejs\egg_ts\app\controller\api\database\scheme.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import Controller from '../../../core/base_controller';

export default class SchemeController extends Controller {

  /**
   * @description
   */
  async getSchemeData() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      type: [ 'database', 'table', 'column' ],
      database: 'string?',
      table: 'string?',
    };
    ctx.validate(rule, ctx.request.query);
    const params = ctx.request.query;
    const { connection, scheme } = ctx.service.database;
    const conn = await connection.get(params.uid);
    const data = await scheme.getSchemeData(conn, params.type as any, params.database, params.table);
    this.success(data);
  }

  /**
   * @description
   */
  async getDatabases() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
    };
    ctx.validate(rule, ctx.request.query);
    const params = ctx.request.query;
    const { connection, scheme } = ctx.service.database;
    const conn = await connection.get(params.uid);
    const data = await scheme.getConnectionDataBases(conn);
    this.success(data);
  }

  /**
   * @description
   */
  async getTables() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      database: 'string',
    };
    ctx.validate(rule, ctx.request.query);
    const params = ctx.request.query;
    const { connection, scheme } = ctx.service.database;
    const conn = await connection.get(params.uid);
    const data = await scheme.getDatabaseTables(conn, params.database);
    this.success(data);
  }

  async syncDataBase() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      database: 'string',
    };
    const params = ctx.request.body;
    ctx.validate(rule, params);
    const { connection, scheme } = ctx.service.database;
    const conn = await connection.get(params.uid);
    const data = await scheme.asyncDataBase(conn, params.database);
    this.success(data);
  }

  /**
   * @description
   */
  async getTableColumns() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
    };
    ctx.validate(rule, ctx.request.query);
    const params = ctx.request.query;
    const { scheme } = ctx.service.database;
    const data = await scheme.getTableColumns(params.uid);
    this.success(data);
  }
}

