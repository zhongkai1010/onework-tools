/*
 * @Author: 钟凯
 * @Date: 2021-02-28 11:26:30
 * @LastEditTime: 2021-02-28 15:21:20
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
    let result = [];

    // mssql
    const sequelize = new Sequelize('master', 'sa', '123qwe!@#', {
      host: '127.0.0.1',
      dialect: 'mssql',
    });
    result = await sequelize.query('SELECT Name FROM Master..SysDatabases ORDER BY Name', { type: Sequelize.QueryTypes.SELECT });

    // mysql
    // const sequelize = new Sequelize(null, 'onework_dev', 'akT7RCmZ26PCEy7L', {
    //   host: '101.37.81.183',
    //   port: 8806,
    //   dialect: 'mysql',
    // });
    // result = await sequelize.query('SELECT SCHEMA_NAME AS `Name` FROM INFORMATION_SCHEMA.SCHEMATA;', { type: Sequelize.QueryTypes.SELECT });

    this.success(result);
  }
}

module.exports = SchemeController;
