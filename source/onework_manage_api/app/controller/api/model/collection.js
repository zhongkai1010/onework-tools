/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:06:13
 * @LastEditTime: 2021-02-18 14:17:55
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\controller\api\model\collection.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/base_controller');

class CollectionController extends Controller {

  /**
   * @description: 添加数据集
   * @param {*}
   * @return {*}
   */
  async insert() {
    const ctx = this.ctx;
    const rule = {
      name: 'string',
      code: 'string',
      items: { type: 'array', itemType: 'string' },
      description: 'string?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.collection.add(ctx.request.body);
    this.success(data);
  }

  /**
   * @description: 获取数据集列表（分页、排序、关键字）
   * @param {*}
   * @return {*}
   */
  async getlist() {
    const ctx = this.ctx;
    const rule = {};
    const data = await this.execPageService(
      ctx.request.body,
      rule,
      ctx.service.model.collection.query
    );
    this.success(data);
  }

  /**
   * @description: 修改数据集
   * @param {*}
   * @return {*}
   */
  async update() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      name: 'string',
      code: 'string',
      items: { type: 'array', rule: 'string' },
      description: 'string?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.collection.update(ctx.request.body);
    this.success(data);

  }

  /**
   * @description: 检索数据集合（关键字、限制10条）
   * @param {*}
   * @return {*}
   */
  async search() {
    const ctx = this.ctx;
    const rule = {
      keyword: 'string',
    };
    ctx.validate(rule, ctx.request.query);
    const data = await ctx.service.model.collection.search(ctx.request.query);
    this.success(data);
  }

  /**
   * @description: 删除数据集
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
    const data = await ctx.service.model.collection.remove(ctx.request.body);
    this.success(data);
  }
}

module.exports = CollectionController;
