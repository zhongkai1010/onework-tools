/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:06:26
 * @LastEditTime: 2021-02-13 07:10:25
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\model\data.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/base_controller');

/**
 * @description: 数据模型服务
 * @param {*}
 * @return {*}
 */
class DataController extends Controller {

  /**
   * @description: 添加数据模型
   * @param {*}
   * @return {*}
   */
  async insert() {
    this.failure();
  }

  /**
   * @description: 获取数据模型列表（分页、排序、关键字）
   * @param {*}
   * @return {*}
   */
  async getlist() {
    this.failure();
  }

  /**
   * @description: 修改数据模型
   * @param {*}
   * @return {*}
   */
  async update() {
    this.failure();
  }

  /**
   * @description: 删除数据模型
   * @param {*}
   * @return {*}
   */
  async remove() {
    this.failure();
  }

  /**
   * @description: 检索数据模型（关键字、限制10条）
   * @param {*}
   * @return {*}
   */
  async search() {
    this.failure();
  }

  /**
   * @description: 数据模型JSON导入
   * @param {*}
   * @return {*}
   */
  async improt() {
    this.failure();
  }

}

module.exports = DataController;
