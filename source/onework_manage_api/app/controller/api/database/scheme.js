/*
 * @Author: 钟凯
 * @Date: 2021-02-28 11:26:30
 * @LastEditTime: 2021-03-06 18:50:20
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\database\scheme.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/base_controller');
class SchemeController extends Controller {

  /**
   * @description:
   * @param {*}
   * @return {*}
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
    const data = await scheme.getSchemeData(conn, params.type, params.database, params.table);
    this.success(data);
  }

  /**
   * @description:
   * @param {*}
   * @return {*}
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
    const data = await scheme.getDataBase(conn);
    this.success(data);
  }

  /**
   * @description:
   * @param {*}
   * @return {*}
   */
  async getTables() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      database: 'string?',
    };
    ctx.validate(rule, ctx.request.query);
    const params = ctx.request.query;
    const { connection, scheme } = ctx.service.database;
    const conn = await connection.get(params.uid);
    const data = await scheme.getTables(conn, params.database);
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
   * @description:
   * @param {*}
   * @return {*}
   */
  async getTable() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
    };
    ctx.validate(rule, ctx.request.query);
    const params = ctx.request.query;
    const { scheme } = ctx.service.database;
    const data = await scheme.getTable(params.uid);
    this.success(data);
  }
}

module.exports = SchemeController;
