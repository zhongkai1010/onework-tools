/*
 * @Author: 钟凯
 * @Github: https://github.com/zhongkai1010
 * @Date: 2019-10-15 02:56:11
 * @LastEditors: 钟凯
 * @LastEditTime: 2021-02-24 17:42:42
 * @Description:
 * @FilePath: \onework_manage_api\app\core\base_controller.js
 */
'use strict';

const { Controller } = require('egg');
const appCode = require('../core/appCode');


class BaseController extends Controller {

  /**
   * @description: 处理分页请求
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
      page: { type: 'int', required: true, min: appCode.common.page.minpage },
      limit: { type: 'int', required: true, min: 1, max: appCode.common.page.maxlimit },
      keyword: 'string?',
      order: 'string?',
      sort: Object.values(appCode.common.order),
      ...rule,
    };
    this.ctx.validate(temp_rule, temp_parmas);
    const reult = await service.call(this, temp_parmas);
    return reult;
  }

  /**
   * @description: 获取分页参数
   * @param {*}
   * @return {*}
   */
  getPageParmas() {
    const { page, limit, keyword, order, sort } = this.ctx.request.query;
    const params = {
      page: this.toDefaultInt(page),
      limit: this.toDefaultInt(limit),
      keyword,
      order,
      sort,
    };
    return params;
  }

  /**
   * @description: 验证分页参数
   * @param {Object} rule 自定义验证规则
   * @returns {Object} 分页参数
   */
  validatePage(rule = {}) {
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
   * @description: 请求成功
   * @param {Object} data 响应数据
   */
  success(data) {
    this.ctx.body = this.ctx.helper.getRequestWrapper(data, true);
  }

  /**
   * @description: 请求失败
   * @param {*} error 异常详情
   */
  failure(error) {
    this.ctx.body = this.ctx.helper.getRequestWrapper(null, false, error);
  }
  /**
   * @description: 字符串参数转数字类型，当值为null或undefined时直接返回参数
   * @param {string} str 字符串参数
   * @return {number} 值
   */
  toInt(str) {
    if (typeof str === 'number') return str;
    if (!str) return str;
    return parseInt(str, 10) || 0;
  }
  /**
   * @description:字符串参数转数字类型，当值为null或undefined时直接返回默认值
   * @param {string} str 字符串参数
   * @param {number} defalutValue 默认值：0
   * @return {number} 值
   */
  toDefaultInt(str, defalutValue = 0) {
    if (typeof str === 'number') return str;
    if (!str) return defalutValue;
    return parseInt(str, 10) || 0;
  }
}
module.exports = BaseController;
