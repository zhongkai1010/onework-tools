/*
 * @Author: 钟凯
 * @Date: 2021-02-13 21:01:23
 * @LastEditTime: 2021-02-21 15:45:33
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\service\model\item.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Service = require('egg').Service;
const AppError = require('../../core/appError');
// const AppCode = require('../../core/appCode');

class ItemService extends Service {

  /**
   * @description: 添加数据项
   * @param {*} params
   * @return {*}
   */
  async add(params) {
    const ctx = this.ctx;
    const ItemModel = ctx.model.Item;
    let item = { ...params };
    // 名称重复验证
    const amount = await ItemModel.count({
      where: {
        name: item.name,
      },
    });
    if (amount > 0) {
      throw new AppError(`${params.name},已存在无法进行添加！`);
    }
    item = await ItemModel.create(item);
    return item.dataValues;
  }

  /**
   * @description: 查询数据项
   * @param {*} params
   * @return {*}
   */
  async query(params) {
    // 初始化参数
    const ctx = this.ctx;
    const ItemModel = ctx.model.Item;
    const Op = ctx.app.Sequelize.Op;
    const queryParmas = {
      order: [[ 'id', 'desc' ]],
      offset: params.limit * (params.page - 1),
      limit: params.limit,
      where: {},
    };
    // 排序
    const sort = params.sort === ctx.app.appCode.common.order.desc ? 'DESC' : 'ASC';
    if (params.order) {
      queryParmas.order = [[ params.order, sort ]];
    }
    // 条件
    if (params.keyword) {
      queryParmas.where = {
        ...queryParmas.where,
        [Op.or]: [{
          name: {
            [Op.substring]: params.keyword,
          } }, {
          code: {
            [Op.substring]: params.keyword,
          } }],
      };
    }
    if (params.type && params.type.length > 0) {
      queryParmas.where.type = {
        [Op.in]: params.type,
      };
    }
    if (params.status && params.status.length > 0) {
      queryParmas.where.status = {
        [Op.in]: params.status,
      };
    }
    // 查询
    const result = await ItemModel.findAndCountAll(queryParmas);
    return { total: result.count, rows: result.rows.map(t => t.dataValues) };
  }

  /**
   * @description: 修改数据项
   * @param {*} 修改数据
   * @return {*}
   */
  async update(params) {
    // 初始化参数
    const ctx = this.ctx;
    const ItemModel = ctx.model.Item;
    const Op = ctx.app.Sequelize.Op;
    // 验证数据
    let item = await ItemModel.findOne({ where: { uid: params.uid } });
    if (item == null) throw new AppError(5101);
    // 名称重复验证
    const amount = await ItemModel.count({
      where: {
        name: params.name,
        uid: {
          [Op.ne]: item.uid,
        },
      },
    });
    if (amount > 0) {
      throw new AppError(5100);
    }
    // 更新字段
    item.name = params.name;
    item.code = params.code;
    item.type = params.type;
    item = await item.save();
    return item.dataValues;
  }

  /**
   * @description: 移除数据项
   * @param {*} 移除uid集合
   * @return {*}
   */
  async remove(params) {
    // 初始化参数
    const ctx = this.ctx;
    const ItemModel = ctx.model.Item;
    const Op = ctx.app.Sequelize.Op;
    // 查询需要删除数据
    const items = await ItemModel.findAll({ where: {
      uid: {
        [Op.in]: params,
      },
    } });
    // 删除数据
    for (let index = 0; index < items.length; index++) {
      const element = items[index];
      if (element.cumulate > 0) { throw new AppError(5102); }
      await element.destroy();
    }
  }

  /**
   * @description: 保存数据项
   * @param {*} 数据集合
   * @return {*}
   */
  async save(params) {
    // 批量处理
    const newRows = [];
    for (let index = 0; index < params.length; index++) {
      const element = params[index];
      if (element.uid) {
        const item = await this.update(element);
        newRows.push(item);
      } else {
        const item = await this.add(element);
        newRows.push(item);
      }
    }
    return newRows;
  }

  /**
   * @description: 检索数据项
   * @param {*} 关键字
   * @return {*}
   */
  async search(params) {
    // 初始化参数
    const ctx = this.ctx;
    const ItemModel = ctx.model.Item;
    const Op = ctx.app.Sequelize.Op;
    const queryParmas = {
      order: [[ 'id', 'desc' ]],
      limit: 10,
      where: {
        [Op.or]: [{
          name: {
            [Op.substring]: params.keyword,
          } }, {
          code: {
            [Op.substring]: params.keyword,
          } }],
      },
    };
    let result = await ItemModel.findAll(queryParmas);
    result = result.map(t => t.dataValues);
    return result;
  }

  /**
   * @description: 根据唯一值查询指定数据项，对数据项进行减法计数
   * @param {*} uid
   * @return {*}
   */
  async subCumulate(uid) {
    const item = await this.ctx.model.Item.findOne({
      where: {
        uid,
      },
      transaction: this.ctx.transaction,
    });
    if (item) {
      await item.subCumulate();

    }
  }
}

module.exports = ItemService;
