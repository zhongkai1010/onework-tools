/*
 * @Author: 钟凯
 * @Date: 2021-03-06 19:37:16
 * @LastEditTime: 2021-03-09 11:47:15
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\core\crud_controller.ts
 * 可以输入预定的版权声明、个性签名、空行等
 */

import BaseController from './base_controller';
import { ModelCtor } from 'sequelize';
import appCode from '../core/appCode';

export default abstract class CrudControllerController extends BaseController {

  protected abstract get model() : ModelCtor <any>;

  public async get() {
    const params = this.ctx.request.query;
    this.ctx.validate({ uid: 'string' }, params);
    const result = this.model.findOne({ where: {
      uid: params.uid,
    } });
    if (result == null) this.failure(); else this.success(result);
  }

  public async getList() {
    // 参数初始化
    const pageParams = this.getPageParmas();
    const bodyParams = this.ctx.request.body;
    const queryParmas = {
      order: [[ 'createdAt', 'desc' ]],
      offset: pageParams.limit * (pageParams.page - 1),
      limit: pageParams.limit,
      where: {},
    };
    // 排序
    const sort = pageParams.sort === appCode.common.order.desc ? 'DESC' : 'ASC';
    if (pageParams.order) {
      queryParmas.order = [[ pageParams.order, sort ]];
    }
    // 条件
    for (const key in bodyParams) {
      if (Object.hasOwnProperty.call(bodyParams, key)) {
        const value = bodyParams[key];
        if (value) {
          queryParmas.where[key] = bodyParams[key];
        }
      }
    }
    // 查询
    const { count, rows } = await this.model.findAndCountAll({
      where: queryParmas.where,
      order: [[ pageParams.order || 'createdAt', pageParams.sort || 'DESC' ]],
    });
    this.success({ total: count, rows });
  }

  public async insert() {
    this.failure();
  }

  public async update() {
    this.failure();
  }

  public async remove() {
    this.failure();
  }
}

