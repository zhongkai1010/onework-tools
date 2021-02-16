/*
 * @Author: 钟凯
 * @Date: 2021-02-16 09:55:59
 * @LastEditTime: 2021-02-16 09:58:53
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\swagger.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('egg').Controller;

class SwaggerController extends Controller {

  /**
   * @description: 输出swagger文档
   * @param {*}
   */
  index() {
    const { ctx } = this;
    const swagger_config = require('./swaggerApi.json');
    ctx.body = swagger_config;
  }
}

module.exports = SwaggerController;
