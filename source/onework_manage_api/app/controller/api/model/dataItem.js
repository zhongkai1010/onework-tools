/*
 * @Author: 钟凯
 * @Date: 2021-02-24 21:55:32
 * @LastEditTime: 2021-02-25 14:12:53
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\model\dataItem.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('egg').Controller;

class DataItemController extends Controller {
  /**
   * @description:  查询数据模型数据项
   * @param {*}
   * @return {*}
   */
  async getList() {
    const ctx = this.ctx;
    const pageParams = this.validatePage();
    const data = await this.service.model.data.queryItem(pageParams, ctx.body);
    this.success(data);
  }

  /**
   * @description: 新增数据模型数据项
   * @param {*}
   * @return {*}
   */
  async insert() {
    const ctx = this.ctx;
    const rule = {
      dataUid: 'string',
      name: 'string',
      code: 'string',
      itemType: 'string',
      typeValue: 'string?',
      subType: 'string?',
      objectRef: 'string?',
      defaultValue: 'string?',
      isNull: 'boolean?',
      length: 'int?',
      precision: 'int?',
      isUnique: 'boolean?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.data.addItem(ctx.request.body);
    this.success(data);
  }

  /**
   * @description: 修改数据模型数据项
   * @param {*}
   * @return {*}
   */
  async update() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      name: 'string',
      code: 'string',
      itemType: 'string',
      typeValue: 'string?',
      subType: 'string?',
      objectRef: 'string?',
      defaultValue: 'string?',
      isNull: 'boolean?',
      length: 'int?',
      precision: 'int?',
      isUnique: 'boolean?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.data.updateBehavior(ctx.request.body);
    this.success(data);
  }

  /**
   * @description: 移除数据模型数据项
   * @param {*}
   * @return {*}
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
    const data = await ctx.service.model.data.removeItem(ctx.request.body);
    this.success(data);
  }
}

module.exports = DataItemController;
