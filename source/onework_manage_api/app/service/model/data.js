/*
 * @Author: 钟凯
 * @Date: 2021-02-13 21:03:38
 * @LastEditTime: 2021-02-17 20:26:20
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_webd:\github\OneWork\source\onework_manage_api\app\service\model\data.js
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
    if (data) throw new AppError(`${params.name},已存在无法进行添加！`);
    // 新增数据模型
    data = {
      name: params.name,
      code: params.code,
      type: params.type,
      description: params.description,
    };
    data = await DataModel.create(data);
    // 新增数据项
    const dataItems = [];
    for (let index = 0; index < params.items.length; index++) {
      const element = params.items[index];
      let dataItem = {
        dataUid: data.uid,
        itemUid: element.uid,
        itemType: element.type,
        itemName: element.name,
        itemCode: element.code,
        isNull: element.isNull,
        length: element.length,
        precision: element.precision,
        defaultValue: element.defaultValue,
      };
      dataItem = await DataItemModel.create(dataItem);
      dataItems.push(dataItem.dataValues);
      // 记录数据项计数
      const item = await ItemModel.findOne({ where: { uid: dataItem.itemUid } });
      if (item) {
        await item.plusCumulate();
      }
    }
    // 新增行为
    const dataBehaviors = [];
    for (let index = 0; index < params.behaviors.length; index++) {
      const element = params.behaviors[index];
      let dataBehavior = {
        dataUid: data.uid,
        behaviorName: element.name,
        behaviorCode: element.code,
        inputs: element.inputs,
        outputType: element.outputType,
        outputValue: element.outputValue,
        description: element,
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
    if (params.type) {
      queryParmas.where.type = {
        [Op.in]: params.type,
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
    if (count > 0) throw new AppError(5100);
    // 修改数据模型
    data.name = params.name;
    data.code = params.code;
    data.description = params.description;
    data.type = params.type;
    data = await data.save();
    // 处理数据项
    const dataItems = await DataItemModel.findAll({ where: { dataUid: data.uid } });
    for (let index = 0; index < dataItems.length; index++) {
      // 移除旧的数据项
      const element = dataItems[index];
      element.destroy();
      // 更新数据项计数
      const item = await ItemModel.findOne({ where: { uid: element.itemUid } });
      if (item) {
        await item.subCumulate();
      }
    }
    // 更新数据项
    const newDataItems = [];
    for (let index = 0; index < params.items.length; index++) {
      const element = params.items[index];
      let dataItem = {
        dataUid: data.uid,
        itemUid: element.uid,
        itemType: element.type,
        itemName: element.name,
        itemCode: element.code,
        isNull: element.isNull,
        length: element.length,
        precision: element.precision,
        defaultValue: element.defaultValue,
      };
      dataItem = await DataItemModel.create(dataItem);
      newDataItems.push(dataItem.dataValues);
      // 记录数据项计数
      const item = await ItemModel.findOne({ where: { uid: dataItem.itemUid } });
      if (item) {
        await item.plusCumulate();
      }
    }
    // 处理旧行为数据
    const dataBehaviors = await DataBehaviorModel.findAll({ where: { dataUid: data.uid } });
    for (let index = 0; index < dataBehaviors.length; index++) {
      const element = dataBehaviors[index];
      await element.destroy();
    }
    // 更新行为数据
    const newDataBehaviors = [];
    for (let index = 0; index < params.behaviors.length; index++) {
      const element = params.behaviors[index];
      let dataBehavior = {
        dataUid: data.uid,
        behaviorName: element.name,
        behaviorCode: element.code,
        inputs: element.inputs,
        outputType: element.outputType,
        outputValue: element.outputValue,
        description: element,
      };
      dataBehavior = await DataBehaviorModel.create(dataBehavior);
      dataBehaviors.push(dataBehavior.dataValues);
      // 返回结果
      return { ...data.dataValues, items: newDataItems, behaviors: newDataBehaviors };
    }
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
