/*
 * @Author: 钟凯
 * @Date: 2021-02-13 21:03:38
 * @LastEditTime: 2021-02-25 14:18:25
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\service\model\data.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Service = require('egg').Service;
const AppError = require('../../core/appError');

class DataService extends Service {

  /**
   * @description: 添加数据集
   * @param {*} params
   * @return {*}
   */
  async add(params) {
    const ctx = this.ctx;
    const DataModel = ctx.model.Data;
    const DataItemModel = ctx.model.DataItem;
    const ItemModel = ctx.model.Item;
    const DataBehaviorModel = ctx.model.DataBehavior;
    // 验证名称是否重复
    let data = await DataModel.findOne({ where: { name: params.name } });
    if (data) throw new AppError(`该数据模型“${params.name}”名称已存在，无法进行添加！`);
    // 新增数据模型
    data = {
      name: params.name,
      code: params.code,
      use: params.use,
      description: params.description,
    };
    data = await DataModel.create(data);
    // 新增数据项
    const dataItems = [];
    for (let index = 0; index < params.items.length; index++) {
      const element = params.items[index];
      if (dataItems.filter(t => t.name === element.name).length > 0) {
        throw new AppError(`该数据项“${element.name}”名称已存在，无法进行重复添加！`);
      }
      let dataItem = {
        dataUid: data.uid,
        name: element.name,
        code: element.code,
        itemType: element.itemType,
        isNull: element.isNull,
        isUnique: element.isUnique,
      };
      const [ item ] = await ItemModel.findOrCreate({ where: { name: dataItem.name }, defaults: {
        name: dataItem.name,
        code: dataItem.code,
        type: dataItem.itemType,

      } });
      dataItem.itemUid = item.uid;
      dataItem = await DataItemModel.create(dataItem);
      dataItems.push(dataItem.dataValues);
      // 记录数据项计数
      await item.plusCumulate();
    }
    // 新增行为
    const dataBehaviors = [];
    for (let index = 0; index < params.behaviors.length; index++) {
      const element = params.behaviors[index];
      let dataBehavior = {
        dataUid: data.uid,
        name: element.name,
        code: element.code,
        operationType: element.operationType,
        description: element.description,
      };
      dataBehavior = await DataBehaviorModel.create(dataBehavior);
      dataBehaviors.push(dataBehavior.dataValues);
    }
    // 返回结果
    return { ...data.dataValues, items: dataItems, behaviors: dataBehaviors };
  }

  /**
   * @description: 查询数据模型
   * @param {*} params
   * @return {*}
   */
  async query(params) {
    // 初始化参数
    const ctx = this.ctx;
    const DataModel = ctx.model.Data;
    const DataItemModel = ctx.model.DataItem;
    const DataBehaviorModel = ctx.model.DataBehavior;
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
          description: {
            [Op.substring]: params.keyword,
          } }, {
          code: {
            [Op.substring]: params.keyword,
          } }],
      };
    }
    if (params.use) {
      queryParmas.where.use = {
        [Op.in]: params.use,
      };
    }
    if (params.status) {
      queryParmas.where.status = {
        [Op.in]: params.status,
      };
    }
    // 查询
    const result = await DataModel.findAndCountAll(queryParmas);
    const dataModels = [];
    for (let i = 0; i < result.rows.length; i++) {
      const dataModel = result.rows[i].dataValues;
      dataModel.items = await DataItemModel.findAll({ where: { dataUid: dataModel.uid } });
      dataModel.items = dataModel.items.map(t => t.dataValues);
      dataModel.behaviors = await DataBehaviorModel.findAll({ where: { dataUid: dataModel.uid } });
      dataModel.behaviors = dataModel.behaviors.map(t => t.dataValues);
      dataModels.push(dataModel);
    }
    return { total: result.count, rows: dataModels };
  }

  /**
   * @description: 修改数据模型
   * @param {*} params
   * @return {*}
   */
  async update(params) {
    const ctx = this.ctx;
    const DataModel = ctx.model.Data;
    const DataItemModel = ctx.model.DataItem;
    const ItemModel = ctx.model.Item;
    const DataBehaviorModel = ctx.model.DataBehavior;
    const Op = ctx.app.Sequelize.Op;
    // 验证数据是否正确
    let data = await DataModel.findOne({ where: { uid: params.uid } });
    if (!data) throw new AppError(5101);
    // 验证修改名称是否存在重复
    const count = await DataModel.count({ where: { name: params.name, uid: {
      [Op.ne]: data.uid,
    } } });
    if (count > 0) throw new AppError(`该数据模型“${params.name}”名称已存在，无法进行修改！`);
    // 修改数据模型
    data.name = params.name;
    data.code = params.code;
    data.description = params.description;
    data.use = params.use;
    data = await data.save();
    // 处理数据项
    const dataItems = await DataItemModel.findAll({ where: { dataUid: data.uid } });
    const itemNames = (params.items || []).map(t => t.name);
    // 处理本次修改中需要移除的数据项
    const deleteItems = dataItems.filter(t => !itemNames.includes(t.name));
    for (let index = 0; index < deleteItems.length; index++) {
      // 移除旧的数据项
      const element = deleteItems[index];
      element.destroy();
      // 更新数据项计数
      const item = await ItemModel.findOne({ where: { uid: element.itemUid } });
      if (item) {
        await item.subCumulate();
      }
    }
    // 处理本次中需要修改或新增的数据项
    const newDataItems = [];
    for (let index = 0; index < params.items.length; index++) {
      const element = params.items[index];
      if (newDataItems.filter(t => t.name === element.name).length > 0) {
        throw new AppError(`该数据项“${element.name}”名称已存在，无法进行重复添加！`);
      }
      const [ item ] = await ItemModel.findOrCreate({ where: { name: element.name }, defaults: {
        name: element.name,
        code: element.code,
        type: element.itemType,
        cumulate: 0,
      } });
      if (item.status === ctx.app.appCode.common.status.disable) {
        throw new AppError(`该数据项“${item.name}”状态已禁用，无法进行操作！`);
      }
      const [ dataItem, created ] = await DataItemModel.findOrCreate({
        where: { name: element.name, dataUid: data.uid },
        defaults: {
          dataUid: data.uid,
          itemUid: item.uid,
          name: element.name,
          code: element.code,
          itemType: element.itemType,
          isNull: element.isNull,
          isUnique: element.isUnique,
        },
      });
      if (!created) {
        dataItem.code = element.code;
        dataItem.itemType = element.itemType;
        dataItem.isNull = element.isNull;
        dataItem.isUnique = element.isUnique;
        await dataItem.save(dataItem);
      }
      newDataItems.push(dataItem.dataValues);
      // 记录数据项计数
      await item.plusCumulate();
    }
    // 处理行为
    const dataBehaviors = await DataBehaviorModel.findAll({ where: { dataUid: data.uid } });
    // 处理本次修改中需要移除的行为
    const behaviorNames = (params.behaviors || []).map(t => t.name);
    const deleteBehaviorNames = dataBehaviors.filter(t => !behaviorNames.includes(t.name));
    for (let index = 0; index < deleteBehaviorNames.length; index++) {
      const element = deleteBehaviorNames[index];
      await element.destroy();
    }
    // 处理本次中需要修改或新增的行为
    const newDataBehaviors = [];
    for (let index = 0; index < params.behaviors.length; index++) {
      const element = params.behaviors[index];
      const [ behavior, created ] = await DataBehaviorModel.findOrCreate({
        where: { name: element.name, dataUid: data.uid },
        defaults: {
          dataUid: data.uid,
          name: element.name,
          code: element.code,
          description: element.description,
        },
      });
      if (!created) {
        behavior.name = element.name;
        behavior.code = element.code;
        behavior.description = element.description;
        await behavior.save();
      }
      newDataBehaviors.push(behavior.dataValues);
    }
    // 返回结果
    return { ...data.dataValues, items: newDataItems, behaviors: newDataBehaviors };
  }

  /**
   * @description: 移除数据集
   * @param {*} 移除uid集合
   * @return {*}
   */
  async remove(params) {
    // 初始化参数
    const ctx = this.ctx;
    const DataModel = ctx.model.Data;
    const DataItemModel = ctx.model.DataItem;
    const ItemModel = ctx.model.Item;
    const DataBehaviorModel = ctx.model.DataBehavior;
    const Op = ctx.app.Sequelize.Op;
    // 查询需要删除数据
    const datas = await DataModel.findAll({ where: {
      uid: {
        [Op.in]: params,
      },
    } });
    if (params.length !== datas.length) { throw new AppError('删除数据中存在错误参数值，无法进行删除'); }
    // 删除数据
    for (let i = 0; i < datas.length; i++) {
      const data = datas[i];
      // 移除数据模型的数据项
      const dataItems = await DataItemModel.findAll({ where: { dataUid: data.uid } });
      for (let j = 0; j < dataItems.length; j++) {
        const dataItem = dataItems[j];
        // 记录数据项计数
        const item = await ItemModel.findOne({ where: { uid: dataItem.itemUid } });
        if (item) {
          await item.subCumulate();
        }
        dataItem.destroy();
      }
      // 移除数据模型的行为
      const dataBehaviors = await DataBehaviorModel.findAll({ where: { dataUid: data.uid } });
      for (let j = 0; j < dataBehaviors.length; j++) {
        const dataBehavior = dataBehaviors[j];
        dataBehavior.destroy();
      }

      await data.destroy();
    }
  }

  /**
   * @description: 检索数据项
   * @param {*} 关键字
   * @return {*}
   */
  async search(params) {
    // 初始化参数
    const ctx = this.ctx;
    const DataModel = ctx.model.Data;
    const DataItemModel = ctx.model.DataItem;
    const DataBehaviorModel = ctx.model.DataBehavior;
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
    const result = await DataModel.findAll(queryParmas);
    const dataModels = [];
    for (let i = 0; i < result.length; i++) {
      const dataModel = result[i].dataValues;
      dataModel.items = await DataItemModel.findAll({ where: { dataUid: dataModel.uid } });
      dataModel.items = dataModel.items.map(t => t.dataValues);
      dataModel.behaviors = await DataBehaviorModel.findAll({ where: { dataUid: dataModel.uid } });
      dataModel.behaviors = dataModel.behaviors.map(t => t.dataValues);
      dataModels.push(dataModel);
    }
    return dataModels;
  }
}

module.exports = DataService;
