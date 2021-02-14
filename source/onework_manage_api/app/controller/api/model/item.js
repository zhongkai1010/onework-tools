/*
 * @Author: 钟凯
 * @Date: 2021-02-11 19:22:50
 * @LastEditTime: 2021-02-14 18:24:58
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\model\item.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/base_controller');

class ItemController extends Controller {
  /**
   * @description: 添加数据项
   * @param {*}
   * @return {*}
   */
  async insert() {
    const ctx = this.ctx;
    const app = this.app;
    const rule = {
      name: 'string',
      code: 'string',
      type: Object.values(app.appCode.model.itemType),
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.item.add(ctx.request.body);
    this.success(data);
  }

  /**
   * @description:  获取数据项列表（分页、排序、关键字）
   * @param {*}
   * @return {*}
   */
  async getlist() {
    const ctx = this.ctx;
    const app = this.app;
    const typeRule = Object.values(app.appCode.model.itemType);
    const statusRule = Object.values(app.appCode.common.status);
    const rule = {
      order: [ 0, ...typeRule ],
      status: {
        type: 'array',
        required: false,
        itemType: 'enum',
        rule: {
          values: statusRule,
        },
      },
      type: {
        type: 'array',
        required: false,
        itemType: 'enum',
        rule: {
          values: typeRule,
        },
      },
    };
    const data = await this.execPageService(
      ctx.request.body,
      rule,
      ctx.service.model.item.query
    );
    this.success(data);
  }

  /**
   * @description:  修改数据项（单条）
   * @param {*}
   * @return {*}
   */
  async update() {
    const ctx = this.ctx;
    const app = this.app;
    const rule = {
      uid: 'string',
      name: 'string',
      status: Object.values(app.appCode.common.status),
      code: 'string',
      type: Object.values(app.appCode.model.itemType),
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.item.update(ctx.request.body);
    this.success(data);
  }

  /**
   * @description:  保存数据项（新增或修改）
   * @param {*}
   * @return {*}
   */
  async save() {
    const ctx = this.ctx;
    const app = this.app;
    const rule = {
      params: {
        type: 'array',
        required: true,
        itemType: 'object',
        rule: {
          uid: 'string?',
          name: 'string',
          code: 'string',
          status: Object.values(app.appCode.common.status),
          type: Object.values(app.appCode.model.itemType),
        },
      },
    };
    ctx.validate(rule, {
      params: ctx.request.body,
    });
    const data = await ctx.service.model.item.save(ctx.request.body);
    this.success(data);
  }

  /**
   * @description: 删除数据项
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
    const data = await ctx.service.model.item.remove(ctx.request.body);
    this.success(data);
  }

  /**
   * @description: 检索数据项（关键字、限制10条）
   * @param {*}
   * @return {*}
   */
  async search() {
    const ctx = this.ctx;
    const rule = {
      keyword: 'string',
    };
    ctx.validate(rule, ctx.request.query);
    const data = await ctx.service.model.item.search(ctx.request.query);
    this.success(data);
  }


}

module.exports = ItemController;
