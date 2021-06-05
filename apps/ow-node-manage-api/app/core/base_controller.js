/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-10-15 02:56:11
 * @LastEditors: 钟凯
 * @LastEditTime: 2021-03-14 09:29:42
 * @description
 * @FilePath: \egg_ts\app\core\base_controller.ts
 */
'use strict';

const Controller = require('egg').Controller;
const appCode = require('./app_code');

class BaseController extends Controller {

  async execPageService({ params = {}, rule = {}, service }) {
    const temp_parmas = {
      ...this.getPageParmas(),
      ...params,
    };
    const temp_rule = {
      page: { type: 'int', required: true, min: appCode.common.page.minpage },
      limit: { type: 'int', required: true, min: 1, max: appCode.common.page.maxlimit },
      keyword: 'string?',
      order: 'string?',
      sort: Object.values(appCode.common.order),
      ...rule,
    };
    this.ctx.validate(temp_rule, temp_parmas);
    const reult = await service(temp_parmas);
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
   */
  validatePage(rule) {
    const defaultPageRule = {
      page: { type: 'int', required: true, min: appCode.common.page.minpage },
      limit: { type: 'int', required: true, min: 1, max: appCode.common.page.maxlimit },
      keyword: 'string?',
      order: 'string?',
      sort: Object.values(appCode.common.order),
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
  success(data) {
    this.ctx.body = this.ctx.helper.getRequestWrapper(data, true, null);
  }

  /**
   * @description  请求失败
   * @param {*} error 异常详情
   */
  failure(error) {
    this.ctx.body = this.ctx.helper.getRequestWrapper(null, false, error);
  }

  /**
   * @description  字符串参数转数字类型，当值为null或undefined时直接返回参数
   * @param {string} str 字符串参数
   * @return {number} 值
   */
  toInt(str) {
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
  toDefaultInt(str, defalutValue) {
    if (typeof str === 'number') return str;
    if (!str) return defalutValue;
    return parseInt(str, 10) || 0;
  }

}

module.exports = BaseController;
