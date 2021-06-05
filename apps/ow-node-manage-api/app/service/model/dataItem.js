/*
 * @Author: 钟凯
 * @Date: 2021-02-25 14:17:10
 * @LastEditTime: 2021-03-13 10:15:15
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\service\model\dataItem.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */

'use strict';

const Service = require('egg').Service;
const { AppError, AppCode } = require('../../core/index');
const Sequelize = require('sequelize');
const { Op } = Sequelize;


class DataItemService extends Service {
  constructor(ctx) {
    super(ctx);
    this.DataModel = this.ctx.model.Data.Data;
    this.ItemModel = this.ctx.model.Data.Item;
    this.DataItemModel = this.ctx.model.Data.DataItem;
  }

  /**
   * @description  添加数据模型数据项
   * @param {*} params  数据模型数据项
   * @return {*} 返回数据模型数据项
   */
  async add(params) {
    const ctx = this.ctx;
    const DataModel = ctx.model.Data.Data;
    const ItemModel = ctx.model.Data.Item;
    const DataItemModel = ctx.model.Data.DataItem;
    // 验证所属数据模型是否正常
    const dataModel = await DataModel.findByPk(params.dataUid);
    if (dataModel == null) throw new AppError('该指定所属的数据模型数据不存在，无法进行添加！');
    // 验证名称是否重复
    const count = await DataItemModel.count({ where: { name: params.name, dataUid: dataModel.uid } });
    if (count > 0) throw new AppError(`该数据模型中数据项“${params.name}”名称已存在，无法进行添加！`);
    // 验证参数
    await this.verifyParams(params);
    // 计算数据项计算
    const [ item ] = await ItemModel.findOrCreate({ where: { name: params.name }, defaults: {
      name: params.name,
      code: params.code,
      type: params.itemType,
    } });
    await item.plusCumulate();
    // 新增数据模型
    const dataItem = await DataItemModel.create({
      dataUid: dataModel.uid,
      itemUid: item.uid,
      name: params.name,
      code: params.code,
      itemType: params.itemType,
      typeValue: params.typeValue,
      arrayType: params.arrayType,
      objectRef: params.objectRef,
      defaultValue: params.defaultValue,
      isNull: params.isNull,
      length: params.length,
      precision: params.precision,
      isUnique: params.isUnique,
    });
    // 返回结果
    return dataItem;
  }

  /**
 * @description 查询数据模型数据项
 * @param {*} pageParams 分页参数
 * @param {*} queryParams 查询参数
 * @return {*} 返回数据模型数据项集合和总个数
 */
  async query(pageParams, queryParams) {
    // 初始化参数
    const ctx = this.ctx;
    const DataModel = ctx.model.Data.Data;
    const DataItemModel = ctx.model.Data.DataItem;
    const Op = ctx.app.Sequelize.Op;
    const queryParmas = {
      order: [[ 'createdAt', 'desc' ]],
      offset: pageParams.limit * (pageParams.page - 1),
      limit: pageParams.limit,
      where: {},
    };
    // 排序
    const sort = pageParams.sort === AppCode.common.order.desc ? 'DESC' : 'ASC';
    if (pageParams.order) {
      queryParmas.order = [[ pageParams.order, sort ]];
    }
    // 条件
    for (const key in queryParams) {
      if (Object.hasOwnProperty.call(queryParams, key)) {
        const value = queryParams[key];
        if (value) {
          queryParmas.where[key] = queryParams[key];
        }
      }
    }
    if (pageParams.keyword) {
      queryParmas.where = {
        ...queryParmas.where,
        [Op.or]: [
          { name: { [Op.substring]: pageParams.keyword } },
          { code: { [Op.substring]: pageParams.keyword } },
        ],
      };
    }
    // 查询
    const { count, rows } = await DataItemModel.findAndCountAll(queryParmas);
    const datas = [];
    const modelUids = rows.map(t => t.dataUid);
    const objectRefUids = rows.map(t => t.objectRef).filter(t => t != null);
    const models = await DataModel.findAll({ where: {
      uid: {
        [Op.in]: [ ...modelUids, ...objectRefUids ],
      },
    } });
    for (let i = 0; i < rows.length; i++) {
      const dataModel = rows[i].dataValues;
      const objectModel = models.find(t => t.uid === dataModel.dataUid);
      if (objectModel) {
        dataModel.dataName = objectModel.name;
      }
      const refModel = models.find(t => t.uid === dataModel.objectRef);
      if (refModel) {
        dataModel.objectRefName = refModel.name;
      }
      datas.push(dataModel);
    }
    return { count, rows: datas };
  }

  /**
 * @description 修改数据模型数据项
 * @param {*} params 数据模型数据项
 * @return {*} 返回数据模型数据项
 */
  async update(params) {
    // 验证所属数据模型是否正常
    const dataItem = await this.DataItemModel.findByPk(params.uid);
    if (!dataItem) throw new AppError('该数据模型的数据项不存在，无法进行修改！');
    // 验证名称是否重复
    const count = await this.DataItemModel.findOne({ where: { name: params.name, dataUid: dataItem.dataUid, uid: {
      [Op.ne]: dataItem.uid,
    } } });
    if (count) throw new AppError(`该数据模型中数据项“${params.name}”名称已存在，无法进行修改！`);
    // 验证参数
    await this.verifyParams(params);
    // 数据项计数
    if (params.name !== dataItem.name) {
      const oldItem = await this.ItemModel.findOne({ where: {
        name: dataItem.name,
      } });
      if (oldItem) {
        await oldItem.subCumulate();
      }
    } else {
      const [ item ] = await this.ItemModel.findOrCreate({ where: { name: params.name }, defaults: {
        name: params.name,
        code: params.code,
        type: params.itemType,
        cumulate: 0,
      } });
      await item.plusCumulate();
    }
    // 修改数据
    dataItem.name = params.name;
    dataItem.code = params.code;
    dataItem.itemType = params.itemType;
    dataItem.typeValue = params.typeValue;
    dataItem.arrayType = params.arrayType;
    dataItem.arrayDepth = params.arrayDepth;
    dataItem.objectRef = params.objectRef;
    dataItem.defaultValue = params.defaultValue;
    dataItem.isNull = params.isNull;
    dataItem.length = params.length;
    dataItem.precision = params.precision;
    dataItem.isUnique = params.isUnique;
    await dataItem.save();
    // 返回结果
    return dataItem;
  }

  async remove(params) {
    // 查询需要删除数据
    const dataItems = await this.DataItemModel.findAll({ where: {
      uid: {
        [Op.in]: params,
      },
    } });
    if (params.length !== dataItems.length) { throw new AppError('删除数据中存在错误参数值，无法进行删除'); }
    // 删除数据
    for (let i = 0; i < dataItems.length; i++) {
      const dataItem = dataItems[i];
      // 移除数据模型的数据项
      const item = await this.ItemModel.findByPk(dataItem.itemUid);
      if (item !== null) {
        await item.subCumulate();
      }
      await dataItem.destroy();
    }
  }

  async verifyParams(params) {
    const ctx = this.ctx;
    const DataModel = ctx.model.Data.Data;
    // 判断是否是数组类型
    if (params.itemType === AppCode.model.itemType.array) {
      if (!params.arrayType) {
        throw new AppError('请填写该数据项数组类型中得具体类型！');
      }
      if (params.arrayType === AppCode.model.itemType.object) {
        if (params.objectRef) {
          const dataModel = await DataModel.findByPk(params.objectRef);
          if (dataModel == null) {
            throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
          } else {
            if (dataModel.status === AppCode.common.status.disable) {
              throw new AppError('请填写该数据项对象类型中具体引用具体数据模型状态已禁用');
            }
          }
        }
      }
    }
    // 判断是否是对象类型，需要填写引用的数据模型
    if (params.itemType === AppCode.model.itemType.object) {
      if (params.objectRef) {
        const dataModel = await DataModel.findByPk(params.objectRef);
        if (dataModel == null) {
          throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
        } else {
          if (dataModel.status === AppCode.common.status.disable) {
            throw new AppError('请填写该数据项对象类型中具体引用具体数据模型状态已禁用');
          }
        }
      }
    }
  }
}

module.exports = DataItemService;
