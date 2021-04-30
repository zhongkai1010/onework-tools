/*
 * @Author: 钟凯
 * @Date: 2021-03-06 19:37:16
 * @LastEditTime: 2021-03-06 20:01:00
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\core\crud_controller.js
 * 可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('./base_controller');

class CrudControllerController extends Controller {
  async get() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
    };
    const params = ctx.request.query;
    ctx.validate(rule, params);
    const data = await this.currentService.get(params.uid);
    this.success(data);
  }
}

module.exports = CrudControllerController;
