/*
 * @Author: 钟凯
 * @Date: 2021-02-13 21:03:25
 * @LastEditTime: 2021-03-01 14:27:32
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\service\model\collection.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Service = require('egg').Service;
const AppError = require('../../core/appError');
const AppCode = require('../../core/appCode');

class CollectionService extends Service {

  /**
   * @description: 添加数据集
   * @param {*} params
   * @return {*}
   */
  async add(params) {
    // 初始化对象
    const ctx = this.ctx;
    const CollectionModel = ctx.model.Data.Collection;
    const ItemModel = ctx.model.Data.Item;
    const Op = ctx.app.Sequelize.Op;
    // 名称重复验证
    const amount = await CollectionModel.count({
      where: {
        name: params.name,
      },
    });
    if (amount > 0) {
      throw new AppError(`该数据集“${params.name}”，已存在无法进行重复添加！`);
    }
    // 处理数据项
    let collection = params;
    const items = await ItemModel.findAll({
      where: {
        uid: {
          [Op.in]: params.items,
        },
      },
    });
    if (items.length !== params.items.length) {
      throw new AppError('该数据集中数据项数据不正确，无法进行添加！');
    }
    collection.items = items.map(t => t.uid);
    // 创建数据集
    collection = await CollectionModel.create(collection);
    // 记录数据项使用率
    for (let index = 0; index < items.length; index++) {
      const item = items[index];
      await item.plusCumulate();
    }
    const result = collection.dataValues;
    result.items = items.map(t => t.dataValues);
    return result;
  }

  /**
   * @description: 查询数据集
   * @param {*} params
   * @return {*}
   */
  async query(params) {
    // 初始化参数
    const ctx = this.ctx;
    const CollectionModel = ctx.model.Data.Collection;
    const ItemModel = ctx.model.Data.Item;
    const Op = ctx.app.Sequelize.Op;
    const queryParmas = {
      order: [[ 'id', 'desc' ]],
      offset: params.limit * (params.page - 1),
      limit: params.limit,
      where: {},
    };
    // 排序

    const sort = params.sort === AppCode.common.order.desc ? 'DESC' : 'ASC';
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
    // 查询
    const { count, rows } = await CollectionModel.findAndCountAll(queryParmas);
    const result = [];
    for (let i = 0; i < rows.length; i++) {
      const element = rows[i].dataValues;
      // 补充数据项其它数据
      const items = await ItemModel.findAll({ where: {
        uid: {
          [Op.in]: element.items,
        },
      } });
      element.items = items.map(t => t.dataValues);
      result.push(element);
    }
    return { total: count, rows: result };
  }

  /**
   * @description: 更新数据集
   * @param {*} 更新数据
   * @return {*}
   */
  async update(params) {
  // 初始化参数
    const ctx = this.ctx;
    const CollectionModel = ctx.model.Data.Collection;
    const ItemModel = ctx.model.Data.Item;
    const Op = ctx.app.Sequelize.Op;
    // 验证数据
    let collection = await CollectionModel.findOne({ where: { uid: params.uid } });
    if (collection == null) throw new AppError(5101);
    // 名称重复验证
    const amount = await CollectionModel.count({
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
    const oldItems = await ItemModel.findAll({ where: { uid: {
      [Op.in]: collection.items || [],
    } } });
    for (let index = 0; index < oldItems.length; index++) {
      const item = oldItems[index];
      await item.subCumulate();
    }
    // 增加新数据项计数
    const items = await ItemModel.findAll({
      where: {
        uid: {
          [Op.in]: params.items,
        },
      },
    });
    if (items.length !== params.items.length) {
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
    collection.items = items.map(t => t.uid);
    collection = await collection.save();
    // 返回结果
    const result = collection.dataValues;
    result.items = items.map(t => t.dataValues);
    return result;
  }

  /**
   * @description: 检索数据集
   * @param {*} 关键字
   * @return {*}
   */
  async search(params) {
    // 初始化参数
    const ctx = this.ctx;
    const CollectionModel = ctx.model.Data.Collection;
    const ItemModel = ctx.model.Data.Item;
    const Op = ctx.app.Sequelize.Op;
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
    const rows = await CollectionModel.findAll(queryParmas);
    const result = [];
    for (let i = 0; i < rows.length; i++) {
      const element = rows[i].dataValues;
      // 补充数据项其它数据
      const items = await ItemModel.findAll({ where: {
        uid: {
          [Op.in]: element.items,
        },
      } });
      element.items = items.map(t => t.dataValues);
      result.push(element);
    }
    return result;
  }

  /**
   * @description: 移除数据项
   * @param {*} 移除uid集合
   * @return {*}
   */
  async remove(params) {
    // 初始化参数
    const ctx = this.ctx;
    const CollectionModel = ctx.model.Data.Collection;

    const Op = ctx.app.Sequelize.Op;
    // 查询需要删除数据
    const collections = await CollectionModel.findAll({
      where: {
        uid: {
          [Op.in]: params,
        },
      } });
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
      const uid = items[index];
      await ctx.service.model.item.subCumulate(uid);
    }
  }
}

module.exports = CollectionService;
