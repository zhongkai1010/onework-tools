/*
 * @Author: 钟凯
 * @Date: 2021-03-06 19:00:40
 * @LastEditTime: 2021-03-06 19:59:19
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\service\database\table.js
 * 可以输入预定的版权声明、个性签名、空行等
 */
'use strict';


const BaseService = require('../../core/base_service');

class TableService extends BaseService {
  constructor(ctx) {
    super(ctx);
    this.currentModel = this.ctx.model.Database.Table;
  }
}

module.exports = TableService;
