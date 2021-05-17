/*
 * @Author: 钟凯
 * @Date: 2021-02-13 21:01:23
 * @LastEditTime: 2021-03-31 15:48:31
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\service\model\item.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Service = require('egg').Service;
const { AppError, AppCode } = require('../../core/index');
const Sequelize = require('sequelize');
const { Op } = Sequelize;

class ItemService extends Service {
  constructor(ctx) {
    super(ctx);
    this.ItemModel = this.ctx.model.Data.Item;
  }

  /**
   * @description 添加数据项
   * @param {Egg} params 新增数据项
   * @return {Egg.Sequelize.Data.Item} 返回新增后的数据项
   */
  async add(params) {
    // 验证参数
    const amount = await this.ItemModel.count({
      where: {
        name: params.name,
      },
    });
    if (amount > 0) {
      throw new AppError(`该数据项“${params.name}”，已存在无法进行重复添加！`);
    }
    const item = await this.ItemModel.create(params);
    return item;
  }

  /**
   * @description  查询数据项
   * @param {*} pageParams 查询参数
   * @param {*} queryParams 查询参数
   * @return {*} 返回数据项结果，包括总数、数据项集合
   */
  async query(
    pageParams,
    queryParams) {
    // 初始化参数
    const where = {};
    if (pageParams.keyword) {
      Object.assign(where, {
        [Op.or]: [{
          name: {
            [Op.substring]: pageParams.keyword,
          } }, {
          code: {
            [Op.substring]: pageParams.keyword,
          } }],
      });
    }
    if (queryParams.type) {
      Object.assign(where, {
        type: {
          [Op.in]: queryParams.type,
        },
      });
    }
    const queryParmas = {
      order: [[ pageParams.order || 'createdAt', (pageParams.sort || AppCode.common.order.desc) ]],
      offset: pageParams.limit * (pageParams.page - 1),
      limit: pageParams.limit,
      where,
    };
    // 查询
    const result = await this.ctx.model.Data.Item.findAndCountAll(queryParmas);
    return result;
  }

  /**
   * @description 修改数据项
   * @param {Egg.Sequelize.Data.Item} params 数据项
   * @return {Egg.Sequelize.Data.Item} 数据项
   */
  async update(params) {
    // 验证数据
    let item = await this.ItemModel.findOne({ where: { uid: params.uid } });
    if (item == null) throw new AppError('该数据项数据已不存在，无法进行修改！');
    // 名称重复验证
    const amount = await this.ItemModel.count({
      where: {
        name: params.name,
        uid: {
          [Op.ne]: item.uid,
        },
      },
    });
    if (amount > 0) {
      throw new AppError(`该数据项“${params.name}”，已存在无法进行重复修改！`);
    }
    // 更新字段
    item.name = params.name;
    item.code = params.code;
    item.type = params.type;
    item = await item.save();
    return item;
  }

  /**
   * @description 修改数据项
   * @param {string[]} params 数据项
   */
  async remove(params) {
    // 初始化参数
    const ctx = this.ctx;
    const ItemModel = ctx.model.Data.Item;
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
      if (element.cumulate > 0) { throw new AppError('该数据项已在其它功能使用，无法进行移除！'); }
      await element.destroy();
    }
  }

  /**
   * @description 批量保存数据项
   * @param {Egg.Sequelize.Data.Item[]} params 数据项
   * @return {Egg.Sequelize.Data.Item[]} 数据项
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
   * @description 查询数据项
   * @param {{keyword:string}} params 查询条件
   * @return {Egg.Sequelize.Data.Item[]} 数据项
   */
  async search(params) {
    // 初始化参数
    const result = await this.ItemModel.findAll({
      order: [[ 'createdAt', 'desc' ]],
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
    });
    return result;
  }

  /**
   * @description 减去数据项计数
   * @param {string} uid 数据项唯一
   */
  async subCumulate(uid) {
    const item = await this.ItemModel.findOne({
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
