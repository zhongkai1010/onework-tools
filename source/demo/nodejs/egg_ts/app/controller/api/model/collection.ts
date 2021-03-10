/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:06:13
 * @LastEditTime: 2021-03-10 23:46:22
 * @LastEditors: 钟凯
 * @description
 * @FilePath: \egg_ts\app\controller\api\model\collection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */

import Controller from '../../../core/base_controller';
export default class CollectionController extends Controller {

  /**
   * @description  添加数据集
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
   * @description  获取数据集列表（分页、排序、关键字）
   */
  async getlist() {
    const ctx = this.ctx;
    const rule = {};
    const data = await this.execPageService({
      params: ctx.request.body,
      rule,
      service: ctx.service.model.collection.query,
    });
    this.success(data);
  }

  /**
   * @description  修改数据集
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
   * @description  检索数据集合（关键字、限制10条）
   */
  async search() {
    const ctx = this.ctx;
    const rule = {
      keyword: 'string',
    };
    ctx.validate(rule, ctx.request.query);
    const data = await ctx.service.model.collection.search(ctx.request.query as any);
    this.success(data);
  }

  /**
   * @description  删除数据集
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
