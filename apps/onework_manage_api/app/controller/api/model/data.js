/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:06:26
 * @LastEditTime: 2021-02-28 09:45:47
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\model\data.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/base_controller');

/**
 * @description: 数据模型服务
 * @param {*}
 * @return {*}
 */
class DataController extends Controller {

  /**
   * @description: 构建uid获取数据模型
   * @param {*}
   * @return {*}
   */
  async get() {
    const ctx = this.ctx;
    const data = await ctx.service.model.data.get(ctx.request.query);
    this.success(data);
  }

  /**
   * @description: 添加数据模型
   * @param {*}
   * @return {*}
   */
  async insert() {
    const ctx = this.ctx;
    const app = this.app;
    const rule = {
      name: 'string',
      code: 'string',
      use: Object.values(app.appCode.model.modelUse),
      items: { type: 'array', min: 1, required: true, itemType: 'object', rule: {
        name: 'string',
        code: 'string',
        itemType: Object.values(app.appCode.model.itemType),
        isNull: 'boolean?',
        isUnique: 'boolean?',
      } },
      behaviors: { type: 'array', required: false, itemType: 'object', rule: {
        name: 'string',
        code: 'string',
        description: 'string?',
        operationType: Object.values(app.appCode.model.behaviorType),
      } },
      description: 'string?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.data.add(ctx.request.body);
    this.success(data);
  }

  /**
   * @description: 获取数据模型列表（分页、排序、关键字）
   * @param {*}
   * @return {*}
   */
  async getlist() {
    const ctx = this.ctx;
    const app = this.app;
    const rule = {
      status: {
        type: 'array',
        required: false,
        itemType: 'enum',
        rule: {
          values: Object.values(app.appCode.common.status),
        },
      },
      use: {
        type: 'array',
        required: false,
        itemType: 'enum',
        rule: {
          values: Object.values(app.appCode.model.modelUse),
        },
      },
    };
    const data = await this.execPageService(
      ctx.request.body,
      rule,
      ctx.service.model.data.query
    );
    this.success(data);
  }

  /**
   * @description: 修改数据模型
   * @param {*}
   * @return {*}
   */
  async update() {
    const ctx = this.ctx;
    const app = this.app;
    const rule = {
      uid: 'string',
      name: 'string',
      code: 'string',
      use: Object.values(app.appCode.model.modelUse),
      items: { type: 'array', min: 1, required: true, itemType: 'object', rule: {
        name: 'string',
        code: 'string',
        itemType: Object.values(app.appCode.model.itemType),
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
   * @description: 删除数据模型
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
    const data = await ctx.service.model.data.remove(ctx.request.body);
    this.success(data);
  }

  /**
   * @description: 检索数据模型（关键字、限制10条）
   * @param {*}
   * @return {*}
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
