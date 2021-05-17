/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:06:26
 * @LastEditTime: 2021-03-31 15:32:17
 * @LastEditors: 钟凯
 * @description
 * @FilePath: \egg_ts\app\controller\api\model\data.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';
const { BaseController, AppCode } = require('../../../core/index');

class DataController extends BaseController {

  /**
   * @description  构建uid获取数据模型
   */
  async get() {
    const ctx = this.ctx;
    const data = await ctx.service.model.data.get(ctx.request.query);
    this.success(data);
  }

  /**
   * @description  添加数据模型

  */
  async insert() {
    const ctx = this.ctx;
    const rule = {
      name: 'string',
      code: 'string',
      use: Object.values(AppCode.model.modelUse),
      items: { type: 'array', min: 1, required: true, itemType: 'object', rule: {
        name: 'string',
        code: 'string',
        itemType: Object.values(AppCode.model.itemType),
        isNull: 'boolean?',
        isUnique: 'boolean?',
      } },
      behaviors: { type: 'array', required: false, itemType: 'object', rule: {
        name: 'string',
        code: 'string',
        description: 'string?',
        operationType: Object.values(AppCode.model.behaviorType),
      } },
      description: 'string?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.data.add(ctx.request.body);
    this.success(data);
  }

  /**
   * @description  获取数据模型列表（分页、排序、关键字）
   */
  async getlist() {
    const ctx = this.ctx;
    const rule = {
      status: {
        type: 'array',
        required: false,
        itemType: 'enum',
        rule: {
          values: Object.values(AppCode.common.status),
        },
      },
      use: {
        type: 'array',
        required: false,
        itemType: 'enum',
        rule: {
          values: Object.values(AppCode.model.modelUse),
        },
      },
    };
    const pageParams = this.getPageParmas();
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.data.query({ ...pageParams, ...ctx.request.body });
    this.success(data);
  }

  /**
   * @description  修改数据模型

   */
  async update() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      name: 'string',
      code: 'string',
      use: Object.values(AppCode.model.modelUse),
      items: { type: 'array', min: 1, required: true, itemType: 'object', rule: {
        name: 'string',
        code: 'string',
        itemType: Object.values(AppCode.model.itemType),
      } },
      behaviors: { type: 'array', required: false, itemType: 'object', rule: {
        name: 'string',
        code: 'string',
        description: 'string?',
      } },
      description: 'string?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.data.update(ctx.request.body);
    this.success(data);
  }

  /**
   * @description  删除数据模型
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
    const data = await ctx.service.model.data.remove(ctx.request.body);
    this.success(data);
  }

  /**
   * @description  检索数据模型（关键字、限制10条）
   */
  async search() {
    const ctx = this.ctx;
    const rule = {
      keyword: 'string',
    };
    ctx.validate(rule, ctx.request.query);
    const data = await ctx.service.model.data.search(ctx.request.query);
    this.success(data);
  }
}

module.exports = DataController;
