/*
 * @Author: 钟凯
 * @Date: 2021-02-24 21:55:32
 * @LastEditTime: 2021-03-31 15:32:51
 * @LastEditors: 钟凯
 * @description
 * @FilePath: \egg_ts\app\controller\api\model\dataItem.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const { BaseController } = require('../../../core/index');

class DataItemController extends BaseController {

  /**
   * @description   查询数据模型数据项
   */

  async getList() {
    const ctx = this.ctx;
    const pageParams = this.validatePage();
    const data = await this.service.model.dataItem.query(pageParams, ctx.request.body);
    this.success(data);
  }

  /**
   * @description  新增数据模型数据项
   */

  async insert() {
    const ctx = this.ctx;
    const rule = {
      dataUid: 'string',
      name: 'string',
      code: 'string',
      itemType: 'string',
      typeValue: 'string?',
      arrayType: 'string?',
      objectRef: 'string?',
      defaultValue: 'string?',
      isNull: 'boolean?',
      length: 'int?',
      precision: 'int?',
      isUnique: 'boolean?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.dataItem.add(ctx.request.body);
    this.success(data);
  }

  /**
   * @description  修改数据模型数据项
   */

  async update() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      name: 'string',
      code: 'string',
      itemType: 'string',
      typeValue: 'string?',
      arrayType: 'string?',
      objectRef: 'string?',
      defaultValue: 'string?',
      isNull: 'boolean?',
      length: 'int?',
      precision: 'int?',
      isUnique: 'boolean?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.dataItem.update(ctx.request.body);
    this.success(data);
  }

  /**
   * @description  移除数据模型数据项
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
    const data = await ctx.service.model.dataItem.remove(ctx.request.body);
    this.success(data);
  }
}

module.exports = DataItemController;
