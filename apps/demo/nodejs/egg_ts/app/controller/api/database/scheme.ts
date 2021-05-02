/*
 * @Author: 钟凯
 * @Date: 2021-02-28 11:26:30
 * @LastEditTime: 2021-03-31 15:30:13
 * @LastEditors: 钟凯
 * @description
 * @FilePath: \egg_ts\app\controller\api\database\scheme.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { BaseController, Router } from '../../../core';

export default class SchemeController extends BaseController {

  /**
   * @description
   */
  @Router.get('/api/database/scheme/getData')
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
  @Router.get('/api/database/scheme/getDatabases')
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
  @Router.get('/api/database/scheme/getTables')
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

  @Router.get('/api/database/scheme/syncDataBase')
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
  @Router.get('/api/database/scheme/getTableColumns')
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

