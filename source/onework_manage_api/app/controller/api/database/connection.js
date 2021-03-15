/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:08:45
 * @LastEditTime: 2021-03-15 12:03:15
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\controller\api\database\connection.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/base_controller');

class ConnectionController extends Controller {

  /**
   * @description: 添加数据库连接
   * @param {*}
   * @return {*}
   */
  async insert() {
    const ctx = this.ctx;
    const rule = {
      name: 'string',
      dbType: [ 'mysql', 'mariadb', 'postgres', 'mssql' ],
      database: 'string?',
      username: 'string',
      password: 'string',
      host: 'string',
      port: 'int',
      config: 'string?',
      description: 'string?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.database.connection.add(ctx.request.body);
    this.success(data);
  }

  /**
   * @description:  获取数据库连接列表（分页、排序、关键字）
   * @param {*}
   * @return {*}
   */
  async getlist() {
    // TODO 需要将数据库密码屏蔽下，不能直接返回
    const ctx = this.ctx;
    const data = await ctx.service.database.connection.getList();
    this.success(data);
  }

  /**
   * @description:  修改数据库连接（单条）
   * @param {*}
   * @return {*}
   */
  async update() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      name: 'string',
      dbType: [ 'mysql', 'mariadb', 'postgres', 'mssql' ],
      database: 'string?',
      username: 'string',
      password: 'string',
      host: 'string',
      port: 'int',
      config: 'string?',
      description: 'string?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.database.connection.update(ctx.request.body);
    this.success(data);
  }


  /**
   * @description: 删除数据库连接
   * @param {*}
   * @return {*}
   */
  async remove() {
    const ctx = this.ctx;
    const rule = {
      params: {
        type: 'array',
        required: true,
        itemType: 'string',
      },
    };
    ctx.validate(rule, {
      params: ctx.request.body,
    });
    const data = await ctx.service.database.connection.remove(ctx.request.body);
    this.success(data);
  }
}

module.exports = ConnectionController;
