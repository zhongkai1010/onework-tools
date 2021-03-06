/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-10-15 02:56:11
 * @LastEditors: 钟凯
 * @LastEditTime: 2021-03-07 01:11:43
 * @description
 * @FilePath: \egg_ts\app\core\base_controller.ts
 */


import { Controller } from 'egg';


export default class BaseController extends Controller {

  /**
   * @description 处理分页请求
   * @param {object} parmas 请求参数
   * @param {object} rule 自定义验证规则
   * @param {Promise} service 具体处理服务
   * @return {object} 返回结果
   */
  async execPageService(parmas = {}, rule = {}, service) {
    const temp_parmas = {
      ...this.getPageParmas(),
      ...parmas,
    };
    const temp_rule = {
      page: { type: 'int', required: true, min: this.app.appCode.common.page.minpage },
      limit: { type: 'int', required: true, min: 1, max: this.app.appCode.common.page.maxlimit },
      keyword: 'string?',
      order: 'string?',
      sort: Object.values(this.app.appCode.common.order),
      ...rule,
    };
    this.ctx.validate(temp_rule, temp_parmas);
    const reult = await service.call(this, temp_parmas);
    return reult;
  }

  /**
   * @description 获取分页参数
   * @return {*} 12
   */
  getPageParmas() {
    const { page, limit, keyword, order, sort } = this.ctx.request.query;
    const params = {
      page: this.toDefaultInt(page, 0),
      limit: this.toDefaultInt(limit, 0),
      keyword,
      order,
      sort,
    };
    return params;
  }

  /**
   * @description  验证分页参数
   * @param {Object} rule 自定义验证规则
   * @return {Object} 分页参数
   */
  validatePage(rule = {}) {
    const defaultPageRule = {
      page: { type: 'int', required: true, min: this.app.appCode.common.page.minpage },
      limit: { type: 'int', required: true, min: 1, max: this.app.appCode.common.page.maxlimit },
      keyword: 'string?',
      order: 'string?',
      sort: Object.values(this.app.appCode.common.order),
    };
    const params = this.getPageParmas();
    const temp_rule = { ...defaultPageRule, ...rule };
    this.ctx.validate(temp_rule, params);
    return params;
  }

  /**
   * @description  请求成功
   * @param {Object} data 响应数据
   */
  success(data: any = null) {
    this.ctx.body = this.ctx.helper.getRequestWrapper(data, true, null);
  }

  /**
   * @description  请求失败
   * @param {*} error 异常详情
   */
  failure(error:any) {
    this.ctx.body = this.ctx.helper.getRequestWrapper(null, false, error);
  }
  /**
   * @description  字符串参数转数字类型，当值为null或undefined时直接返回参数
   * @param {string} str 字符串参数
   * @return {number} 值
   */
  toInt(str:string): number {
    if (typeof str === 'number') return str;
    if (!str) throw new Error('参数异常');
    return parseInt(str, 10) || 0;
  }
  /**
   * @description 字符串参数转数字类型，当值为null或undefined时直接返回默认值
   * @param {string} str 字符串参数
   * @param {number} defalutValue 默认值：0
   * @return {number} 值
   */
  toDefaultInt(str: string, defalutValue: number): number {
    if (typeof str === 'number') return str;
    if (!str) return defalutValue;
    return parseInt(str, 10) || 0;
  }
}

