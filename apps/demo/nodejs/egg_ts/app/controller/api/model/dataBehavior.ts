/*
 * @Author: 钟凯
 * @Date: 2021-02-24 21:55:40
 * @LastEditTime: 2021-03-31 15:32:32
 * @LastEditors: 钟凯
 * @description
 * @FilePath: \egg_ts\app\controller\api\model\dataBehavior.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { BaseController, AppCode, Router } from '../../../core';

export default class DataBehaviorController extends BaseController {
  /**
   * @description  新增数据模型行为
   */
  @Router.get('/api/model/data/behavior/insert')
  async insert() {
    const ctx = this.ctx;
    const rule = {
      dataUid: 'string',
      name: 'string',
      code: 'string',
      inputs: {
        type: 'array', required: false, itemType: 'object', rule: {
          type: Object.values(AppCode.model.itemType),
          arrayType: 'string?',
          value: 'string?',
        },
      },
      outputs: {
        type: 'object', required: false, rule: {
          type: Object.values(AppCode.model.itemType),
          arrayType: 'string?',
          value: 'string?',
        },
      },
      operationType: Object.values(AppCode.model.behaviorType),
      description: 'string?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.dataBehavior.add(ctx.request.body);
    this.success(data);
  }

  /**
   * @description  查询数据模型行为
   */
  @Router.post('/api/model/data/behavior/getList')
  async getList() {
    const ctx = this.ctx;
    const pageParams = this.validatePage();
    const data = await this.service.model.dataBehavior.query(pageParams, ctx.body);
    this.success(data);
  }

  /**
   * @description  修改数据模型行为
   */
  @Router.post('/api/model/data/behavior/update')
  async update() {
    const ctx = this.ctx;
    const rule = {
      uid: 'string',
      name: 'string',
      code: 'string',
      inputs: {
        type: 'array', required: false, itemType: 'object', rule: {
          type: Object.values(AppCode.model.itemType),
          arrayType: 'string?',
          value: 'string?',
        },
      },
      outputs: {
        type: 'object', required: false, rule: {
          type: Object.values(AppCode.model.itemType),
          arrayType: 'string?',
          value: 'string?',
        },
      },
      operationType: Object.values(AppCode.model.behaviorType),
      description: 'string?',
    };
    ctx.validate(rule, ctx.request.body);
    const data = await ctx.service.model.dataBehavior.update(ctx.request.body);
    this.success(data);
  }

  /**
   * @description  移除数据模型行为
   */
  @Router.post('/api/model/data/behavior/remove')
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
    const data = await ctx.service.model.dataBehavior.remove(ctx.request.body);
    this.success(data);
  }
}

module.exports = DataBehaviorController;
