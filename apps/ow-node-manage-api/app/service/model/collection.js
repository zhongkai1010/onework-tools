/*
 * @Author: 钟凯
 * @Date: 2021-02-13 21:03:25
 * @LastEditTime: 2021-03-12 10:07:37
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\service\model\collection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Service = require('egg').Service;
const { AppError, AppCode } = require('../../core/index');
const Sequelize = require('sequelize');
const { Op } = Sequelize;

class CollectionService extends Service {
  constructor(ctx) {
    super(ctx);
    this.CollectionModel = this.ctx.model.Data.Collection;
    this.ItemModel = this.ctx.model.Data.Item;
    this.ItemService = this.ctx.service.model.item;
  }

  /**
   * @description 添加数据集
   * @param {*} params 参数
   * @return {*}  数据集
   */
  async add(params) {
    // 名称重复验证
    const amount = await this.CollectionModel.count({
      where: {
        name: params.name,
      },
    });
    if (amount > 0) {
      throw new AppError(`该数据集“${params.name}”，已存在无法进行重复添加！`);
    }
    // 处理数据项
    const items = await this.ItemModel.findAll({
      where: {
        uid: {
          [Op.in]: params.itemUids,
        },
      },
    });
    if (items.length !== params.itemUids.length) {
      throw new AppError('该数据集中数据项数据不正确，无法进行添加！');
    }
    // 创建数据集
    const collection = await this.CollectionModel.create({
      ...params,
      items,
    });
    // 记录数据项使用率
    for (let index = 0; index < items.length; index++) {
      const item = items[index];
      await item.plusCumulate();
    }
    return collection.dataValues;
  }

  /**
   * @description 查询数据集
   * @param {*} params 查询条件
   * @return {*} 返回结果
   */
  async query(params) {
    // 初始化参数
    const where = {};
    if (params.keyword) {
      Object.assign(where, {
        [Op.or]: [{
          name: {
            [Op.substring]: params.keyword,
          } }, {
          code: {
            [Op.substring]: params.keyword,
          } }],
      });
    }
    const queryParmas = {
      order: [
        [ params.order || 'createdAt', params.sort || AppCode.common.order.desc ],
      ],
      offset: params.limit * (params.page - 1),
      limit: params.limit,
      where,
    };
    // 查询
    const result = await this.CollectionModel.findAndCountAll(queryParmas);
    // 返回结果
    return { count: result.count, rows: result.rows.map(t => { return { ...t.dataValues, itemUids: (t.items || []).map(o => o.uid) }; }) };
  }

  /**
   * @description 更新数据集
   * @param {Egg} params 数据集参数
   * @return {*} 数据集
   */
  async update(
    params
  ) {
    // 验证数据
    let collection = await this.CollectionModel.findOne({
      where: { uid: params.uid },
    });
    if (collection == null) throw new AppError(5101);
    // 名称重复验证
    const amount = await this.CollectionModel.count({
      where: {
        name: params.name,
        uid: {
          [Op.ne]: collection.uid,
        },
      },
    });
    if (amount > 0) {
      throw new AppError(`该数据集“${params.name}”，已存在无法进行重复修改！`);
    }
    // 减除旧数据项计数
    const oldItems = await this.ItemModel.findAll({
      where: {
        uid: {
          [Op.in]: collection.items.map(t => t.uid) || [],
        },
      },
    });
    for (let index = 0; index < oldItems.length; index++) {
      const item = oldItems[index];
      await item.subCumulate();
    }
    // 增加新数据项计数
    const items = await this.ItemModel.findAll({
      where: {
        uid: {
          [Op.in]: params.itemUids,
        },
      },
    });
    if (items.length !== params.itemUids.length) {
      throw new AppError('该数据集中数据项数据不正确，无法进行修改！');
    }
    for (let index = 0; index < items.length; index++) {
      const item = items[index];
      await item.plusCumulate();
    }
    // 更新字段
    collection.name = params.name;
    collection.code = params.code;
    collection.description = params.description;
    collection.items = items.map(t => t.dataValues);
    collection = await collection.save();
    // 返回结果
    return collection;
  }

  /**
   * @description 检索数据集
   * @param {object} params 搜索条件
   * @return {*} 数据集集合
   */
  async search(params) {
    // 初始化参数
    const queryParmas = {
      order: [[ 'createdAt', 'desc' ]],
      limit: 10,
      where: {
        [Op.or]: [
          { name: { [Op.substring]: params.keyword } },
          { code: { [Op.substring]: params.keyword } },
          { description: { [Op.substring]: params.keyword } },
        ],
      },
    };
    return await this.CollectionModel.findAll(queryParmas);
  }

  /**
   * @description 移除数据项
   * @param {string} params 移除uid集合
   */
  async remove(params) {
    // 查询需要删除数据
    const collections = await this.CollectionModel.findAll({
      where: {
        uid: {
          [Op.in]: params,
        },
      },
    });
    // 移除数据集
    const items = [];
    for (let index = 0; index < collections.length; index++) {
      const collection = collections[index];
      items.push(...collection.items);
      await collection.destroy();
    }
    // 更新关联数据项计数
    // TODO sequelize的Model操作中forEach导致事务异常 https://stackoverflow.com/questions/61369310/sequelize-transactions-inside-foreach-issue
    for (let index = 0; index < items.length; index++) {
      await this.ItemService.subCumulate(items[index].uid);
    }
  }
}

module.exports = CollectionService;
