/*
 * @Author: 钟凯
 * @Date: 2021-02-28 11:26:30
 * @LastEditTime: 2021-03-01 18:07:01
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\database\scheme.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/base_controller');
const { Sequelize } = require('sequelize');

class SchemeController extends Controller {

  /**
   * @description:
   * @param {*}
   * @return {*}
   */
  async getDataBases() {
    const ctx = this.ctx;
    let result = [];

    // mssql
    const sequelize = new Sequelize({
      dialect: 'mssql',
      username: 'sa',
      password: '123qwe!@#',
      host: '127.0.0.1',
      timezone: '+08:00', // for writing to database
      dialectOptions: {
        ssl: {
          minVersion: 'TLSv1.2',
          rejectUnauthorized: true,
        },
      },
    });
    result = await sequelize.query(ctx.app.appCode.sql.mysql.database, { type: Sequelize.QueryTypes.SELECT });
    this.success(result);

  }
}

module.exports = SchemeController;
