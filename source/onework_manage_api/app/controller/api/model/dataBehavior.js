/*
 * @Author: 钟凯
 * @Date: 2021-02-24 21:55:40
 * @LastEditTime: 2021-02-25 14:13:30
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\model\dataBehavior.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('egg').Controller;

class DataBehaviorController extends Controller {

  /**
   * @description: 新增数据模型行为
   * @param {*}
   * @return {*}
   */
  async insert() {
    this.failure();
  }

  /**
   * @description: 查询数据模型行为
   * @param {*}
   * @return {*}
   */
  async getList() {
    const ctx = this.ctx;
    const pageParams = this.validatePage();
    const data = await this.service.model.data.queryBehavior(pageParams, ctx.body);
    this.success(data);
  }

  /**
   * @description: 修改数据模型行为
   * @param {*}
   * @return {*}
   */
  async update() {
    this.failure();
  }

  /**
   * @description: 移除数据模型行为
   * @param {*}
   * @return {*}
   */
  async remove() {
    this.failure();
  }
}

module.exports = DataBehaviorController;
