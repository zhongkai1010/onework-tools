/*
 * @Author: 钟凯
 * @Date: 2021-02-11 19:22:50
 * @LastEditTime: 2021-04-15 10:34:28
 * @LastEditors: 钟凯
 * @description
 * @FilePath: \egg_ts\app\controller\api\model\item.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { BaseController, AppCode, Router } from '../../../core';

export default class ItemController extends BaseController {
  /**
   * @description  添加数据项
   */
  @Router.post('/api/model/item/insert')
  async insert() {
    const ctx = this.ctx;
    const rule = {
      name: 'string',
      code: 'string',
      type: Object.values(AppCode.model.itemType),
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.item.add(ctx.request.body);
    this.success(data);
  }

  /**
   * @description   获取数据项列表（分页、排序、关键字）
   */
  @Router.post('/api/model/item/getlist')
  async getlist() {
    const ctx = this.ctx;
    const typeRule = Object.values(AppCode.model.itemType);
    const rule = {
      type: {
        type: 'array',
        required: false,
        itemType: 'enum',
        rule: {
          values: typeRule,
        },
      },
    };

    const pageParams = this.validatePage();
    const bodyParams = ctx.request.body;
    ctx.validate(rule, bodyParams);
    const result = await ctx.service.model.item.query(pageParams, bodyParams);
    this.success(result);
  }

  /**
   * @description   修改数据项（单条）
   */
  @Router.patch('/api/model/item/update')
  async update() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      name: 'string',
      code: 'string',
      type: Object.values(AppCode.model.itemType),
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.item.update(ctx.request.body);
    this.success(data);
  }

  /**
   * @description   保存数据项（新增或修改）
   */
  @Router.post('/api/model/item/save')
  async save() {
    const ctx = this.ctx;
    const rule = {
      params: {
        type: 'array',
        required: true,
        itemType: 'object',
        rule: {
          uid: 'string?',
          name: 'string',
          code: 'string',
          type: Object.values(AppCode.model.itemType),
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
   * @description  删除数据项
   */
  @Router.post('/api/model/item/remove')
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
   * @description  检索数据项（关键字、限制10条）
   */
  @Router.post('/api/model/item/search')
  async search() {
    const ctx = this.ctx;
    const rule = {
      keyword: 'string',
    };
    ctx.validate(rule, ctx.request.query);
    const data = await ctx.service.model.item.search(ctx.request.query as any);
    this.success(data);
  }
}

module.exports = ItemController;
