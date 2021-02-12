/*
 * @Author: 钟凯
 * @Date: 2021-02-13 07:06:13
 * @LastEditTime: 2021-02-13 07:16:21
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\controller\api\model\set.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Controller = require('../../../core/base_controller');

class SetController extends Controller {
  /**
   * @description: 添加数据集
   * @param {*}
   * @return {*}
   */
  async insert() {
    this.failure();

  }
  /**
   * @description: 获取数据集列表（分页、排序、关键字）
   * @param {*}
   * @return {*}
   */
  async getlist() {
    this.failure();

  }
  /**
   * @description: 修改数据集
   * @param {*}
   * @return {*}
   */
  async update() {
    this.failure();

  }
  /**
   * @description: 检索数据集合（关键字、限制10条）
   * @param {*}
   * @return {*}
   */
  async search() {

    this.failure();
  }
  /**
   * @description: 删除数据集
   * @param {*}
   * @return {*}
   */
  async remove() {
    this.failure();

  }
}

module.exports = SetController;
