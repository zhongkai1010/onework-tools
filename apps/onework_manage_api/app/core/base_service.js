/*
 * @Author: 钟凯
 * @Date: 2021-03-06 19:18:06
 * @LastEditTime: 2021-03-06 20:00:26
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\core\base_service.js
 * 可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Service = require('egg').Service;
const AppError = require('./appError');

class BaseService extends Service {

  async get(uid) {
    const model = await this.currentModel.findByPk(uid);
    if (model == null) { throw new AppError('该数据不存在，操作失败'); }
    return model.dataValues;
  }

  async add(params) {
    console.log(params);
    throw new AppError();
  }

  async getList(pageParams, bodyParams) {
    console.log(pageParams, bodyParams);
    throw new AppError();
  }
  async update(params) {
    console.log(params);
    throw new AppError();
  }
  async remove(params) {
    console.log(params);
    throw new AppError();
  }
}

module.exports = BaseService;
