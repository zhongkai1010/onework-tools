/*
 * @Author: 钟凯
 * @Date: 2021-02-11 19:22:50
 * @LastEditTime: 2021-03-10 23:55:26
 * @LastEditors: 钟凯
 * @description
 * @FilePath: \egg_ts\app\controller\api\model\item.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import Controller from '../../../core/base_controller';
import AppCode from '../../../core/appCode';

export default class ItemController extends Controller {
  /**
   * @description  添加数据项
   */
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
    const data = await this.execPageService(
      { params: ctx.request.body,
        rule,
        service: ctx.service.model.item.query },
    );
    this.success(data);
  }

  /**
   * @description   修改数据项（单条）
   */
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
