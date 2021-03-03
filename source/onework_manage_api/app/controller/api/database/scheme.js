/*
 * @Author: 钟凯
 * @Date: 2021-02-28 11:26:30
 * @LastEditTime: 2021-03-03 15:28:46
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
  async getList() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      type: [ 'database', 'table', 'column' ],
      database: 'string?',
      table: 'string?',
    };
    ctx.validate(rule, ctx.request.query);
    const data = await ctx.service.database.scheme.getSchemeData(ctx.request.query);
    this.success(data);


    // // mssql
    // const sequelize = new Sequelize({
    //   dialect: 'mssql',
    //   database: 'v3',
    //   username: 'sa',
    //   password: '123qwe!@#',
    //   host: '127.0.0.1',
    //   logging: (sql, timing) => { console.log(sql, timing); },
    // });
    // // await sequelize.authenticate();
    // result = await sequelize.query(ctx.app.appCode.sql.mssql.table, { type: Sequelize.QueryTypes.SELECT });
    // await sequelize.close();
    // this.success(result);
  }
}

module.exports = SchemeController;
