/*
 * @Author: 钟凯
 * @Date: 2021-03-01 14:08:45
 * @LastEditTime: 2021-04-10 09:08:11
 * @LastEditors: 钟凯
 * @description
 * @FilePath: \egg_ts\app\controller\api\database\connection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const { BaseController } = require('../../../core/index');

class ConnectionController extends BaseController {

  /**
   * @description 添加数据库连接
   */
  async insert() {
    const ctx = this.ctx;
    const data = await ctx.service.database.connection.add(ctx.request.body);
    this.success(data);
  }

  /**
   * @description   获取数据库连接列表（分页、排序、关键字）
   */
  async getlist() {
    const ctx = this.ctx;
    const data = await ctx.service.database.connection.getList();
    const result = data.map(t => {
      const temp = t;
      return temp;
    });
    this.success(result);

  }

  /**
   * @description   修改数据库连接（单条）
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
   * @description  删除数据库连接
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
