/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-10-15 02:56:11
 * @LastEditors: 钟凯
 * @LastEditTime: 2019-11-01 14:34:32
 * @Description:
 * @FilePath: \wmsq_api\app\core\base_controller.js
 */
'use strict';

const { Controller } = require('egg');

class BaseController extends Controller {

  success(result) {
    this.ctx.body = this.ctx.helper.getRequestWrapper(result, true);
  }

  failure(error) {
    this.ctx.body = this.ctx.helper.getRequestWrapper(null, false, error);
  }

  toInt(str) {
    if (typeof str === 'number') return str;
    if (!str) return str;
    return parseInt(str, 10) || 0;
  }
}
module.exports = BaseController;
