/*
 * @Author: 钟凯
 * @Date: 2021-03-06 19:39:54
 * @LastEditTime: 2021-03-06 20:11:27
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\database\table.js
 * 可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/crud_controller');

class TableController extends Controller {
  constructor(ctx) {
    super(ctx);
    this.currentService = this.ctx.service.database.table;
  }

  // async get() {
  //   this.failure();
  // }
}

module.exports = TableController;
