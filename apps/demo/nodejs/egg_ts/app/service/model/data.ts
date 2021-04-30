/*
 * @Author: 钟凯
 * @Date: 2021-02-13 21:03:38
 * @LastEditTime: 2021-03-12 10:07:16
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\service\model\data.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { Service } from 'egg';
import { FindAndCountOptions, Op, WhereValue } from 'sequelize';
import AppError from '../../core/appError';
import AppCode from '../../core/appCode';

interface GetFunResult extends Egg.Sequelize.Data.Data
{
  items:Egg.Sequelize.Data.DataItem[],
  behaviors:Egg.Sequelize.Data.DataBehavior[]
}

export default class DataService extends Service {
  protected DataModel = this.ctx.model.Data.Data;
  protected DataItemModel = this.ctx.model.Data.DataItem;
  protected DataBehaviorModel =this.ctx.model.Data.DataBehavior;
  protected ItemModel= this.ctx.model.Data.Item;

  async get(params:{uid:string}):Promise<GetFunResult| null> {
    const dataModel = await this.DataModel.findByPk(params.uid);
    if (dataModel == null) { return dataModel; }
    const result = { ...dataModel } as GetFunResult;
    const items = await this.DataItemModel.findAll({ where: { dataUid: dataModel.uid } });
    result.items = items;
    result.behaviors = await this.DataBehaviorModel.findAll({ where: { dataUid: dataModel.uid } });
    return result;
  }

  /**
   * @description 添加数据模型
   * @param {Egg} params 参数
   * @return {*} 返回数据模型
   */
  public async add(params:Egg.Ow.Data.Data):Promise<Egg.Sequelize.Data.Data> {
    // 验证是否重复
    const [ data, created ] = await this.DataModel.findOrCreate({ where: { name: params.name }, defaults: {
      name: params.name,
      code: params.code,
      use: params.use,
      description: params.description,
    } });
    data.items = [] as Egg.Sequelize.Data.DataItem[];
    data.behaviors = [] as Egg.Sequelize.Data.DataBehavior[];
    const items = params.items || [];
    if (!created) throw new AppError(`该数据模型“${params.name}”名称已存在，无法进行添加！`);
    // 新增数据项
    for (let index = 0; index < items.length; index++) {
      const element = items[index];
      if (data.items.filter(t => t.name === element.name).length > 0) {
        throw new AppError(`该数据项“${element.name}”名称已存在，无法进行重复添加！`);
      }
      const [ item ] = await this.ItemModel.findOrCreate({ where: { name: element.name }, defaults: {
        name: element.name,
        code: element.code,
        type: element.itemType,
      } });
      const dataItem = await this.DataItemModel.create({
        dataUid: data.uid,
        name: element.name,
        code: element.code,
        itemType: element.itemType,
        isNull: element.isNull,
        isUnique: element.isUnique,
        itemUid: item.uid,
      });
      data.items.push(dataItem);
      // 记录数据项计数
      await item.plusCumulate();
    }
    // 新增行为
    const behaviors = params.behaviors || [];
    for (let index = 0; index < behaviors.length; index++) {
      const element = behaviors[index];
      const dataBehavior = await this.DataBehaviorModel.create({
        dataUid: data.uid,
        name: element.name,
        code: element.code,
        operationType: element.operationType,
        description: element.description,
      });
      data.behaviors.push(dataBehavior);
    }
    // 返回结果
    return { ...data.dataValues, items: data.items, behaviors: data.behaviors };
  }

  /**
   * @description 查询数据模型
   * @param {*} params 查询条件
   * @return {*} 查询结果
   */
  public async query(params: any): Promise<{rows:Egg.Sequelize.Data.Data[], count:number}> {
    // 初始化参数
    const where = {} as WhereValue<Egg.Ow.Data.Data>;
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
    if (params.use) {
      Object.assign(where, { use: { [Op.in]: params.use } });
    }
    if (params.status) {
      Object.assign(where, { status: { [Op.in]: params.status } });
    }
    const queryParmas = {
      order: [[ params.order || 'createdAt', (params.sort || AppCode.common.order.desc) ]],
      offset: params.limit * (params.page - 1),
      limit: params.limit,
      where,
    } as FindAndCountOptions<Egg.Sequelize.Data.Data>;
    // 查询
    const result = await this.DataModel.findAndCountAll(queryParmas);
    const dataModels = [] as Egg.Sequelize.Data.Data[];
    for (let i = 0; i < result.rows.length; i++) {
      const dataModel = result.rows[i].dataValues;
      dataModel.items = await this.DataItemModel.findAll({ where: { dataUid: dataModel.uid } });
      dataModel.behaviors = await this.DataBehaviorModel.findAll({ where: { dataUid: dataModel.uid } });
      dataModels.push(dataModel);
    }
    return { count: result.count, rows: dataModels };
  }

  /**
   * @description 修改数据模型
   * @param {*} params 数据模型
   * @return {*} 返回数据模型
   */
  public async update(params:Egg.Sequelize.Data.Data):Promise<Egg.Sequelize.Data.Data> {
    // 验证数据是否正确
    let data = await this.DataModel.findOne({ where: { uid: params.uid } });
    if (!data) throw new AppError(5101);
    // 验证修改名称是否存在重复
    const count = await this.DataModel.count({ where: { name: params.name, uid: {
      [Op.ne]: data.uid,
    } } });
    if (count > 0) throw new AppError(`该数据模型“${params.name}”名称已存在，无法进行修改！`);
    // 修改数据模型
    data.name = params.name;
    data.code = params.code;
    data.description = params.description;
    data.use = params.use;
    data = await data.save();
    data.items = [] as Egg.Sequelize.Data.DataItem[];
    data.behaviors = [] as Egg.Sequelize.Data.DataBehavior[];
    // 处理数据项
    const dataItems = await this.DataItemModel.findAll({ where: { dataUid: data.uid } });
    const itemNames = (params.items || []).map(t => t.name);
    // 处理本次修改中需要移除的数据项
    // TODO 可能数据项得计数有问题，新增得数据项需要加一，旧的数据需要减一
    const deleteItems = dataItems.filter(t => !itemNames.includes(t.name));
    for (let index = 0; index < deleteItems.length; index++) {
      // 移除旧的数据项
      const element = deleteItems[index];
      element.destroy();
      // 更新数据项计数
      const item = await this.ItemModel.findOne({ where: { uid: element.itemUid } });
      if (item) {
        await item.subCumulate();
      }
    }
    // 处理本次中需要修改或新增的数据项
    const items = params.items || [];
    for (let index = 0; index < items.length; index++) {
      const element = items[index] as Egg.Sequelize.Data.DataItem;
      if (data.items.filter(t => t.name === element.name).length > 0) {
        throw new AppError(`该数据项“${element.name}”名称已存在，无法进行重复添加！`);
      }
      const [ item ] = await this.ItemModel.findOrCreate({ where: { name: element.name }, defaults: {
        name: element.name,
        code: element.code,
        type: element.itemType,
        cumulate: 0,
      } });
      const [ dataItem, created ] = await this.DataItemModel.findOrCreate({
        where: { name: element.name, dataUid: data.uid },
        defaults: {
          dataUid: data.uid,
          itemUid: item.uid,
          name: element.name,
          code: element.code,
          itemType: element.itemType,
        },
      });
      if (!created) {
        dataItem.code = element.code;
        dataItem.itemType = element.itemType;
        await dataItem.save();
      }
      data.items.push(dataItem);
      // 记录数据项计数
      await item.plusCumulate();
    }
    // 处理行为
    const dataBehaviors = await this.DataBehaviorModel.findAll({ where: { dataUid: data.uid } });
    // 处理本次修改中需要移除的行为
    const behaviorNames = (params.behaviors || []).map(t => t.name);
    const deleteBehaviorNames = dataBehaviors.filter(t => !behaviorNames.includes(t.name));
    for (let index = 0; index < deleteBehaviorNames.length; index++) {
      const element = deleteBehaviorNames[index];
      await element.destroy();
    }
    // 处理本次中需要修改或新增的行为
    const behaviors = params.behaviors || [];
    for (let index = 0; index < behaviors.length; index++) {
      const element = behaviors[index];
      const [ behavior, created ] = await this.DataBehaviorModel.findOrCreate({
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
      data.behaviors.push(behavior);
    }
    // 返回结果
    return { ...data.dataValues, items: data.items, behaviors: data.behaviors };
  }


  /**
   * @description 移除数据集
   * @param {string} params 移除uid集合
   */
  public async remove(params:string[]):Promise<void> {
    // 查询需要删除数据
    const datas = await this.DataModel.findAll({ where: {
      uid: {
        [Op.in]: params,
      },
    } });
    if (params.length !== datas.length) { throw new AppError('删除数据中存在错误参数值，无法进行删除'); }
    // 删除数据
    for (let i = 0; i < datas.length; i++) {
      const data = datas[i];
      // 移除数据模型的数据项
      const dataItems = await this.DataItemModel.findAll({ where: { dataUid: data.uid } });
      for (let j = 0; j < dataItems.length; j++) {
        const dataItem = dataItems[j];
        // 记录数据项计数
        const item = await this.ItemModel.findOne({ where: { uid: dataItem.itemUid } });
        if (item) {
          await item.subCumulate();
        }
        dataItem.destroy();
      }
      // 移除数据模型的行为
      const dataBehaviors = await this.DataBehaviorModel.findAll({ where: { dataUid: data.uid } });
      for (let j = 0; j < dataBehaviors.length; j++) {
        const dataBehavior = dataBehaviors[j];
        dataBehavior.destroy();
      }

      await data.destroy();
    }
  }

  /**
   * @description 检索数据项
   * @param {object} params 关键字
   * @return {*} 数据模型集合
   */
  public async search(params:{keyword:string}):Promise<Egg.Sequelize.Data.Data[]> {
    // 初始化参数
    const queryParmas = {
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
    } as FindAndCountOptions<Egg.Sequelize.Data.Data>;
    const result = await this.DataModel.findAll(queryParmas);
    const dataModels = [] as Egg.Sequelize.Data.Data[];
    for (let i = 0; i < result.length; i++) {
      const dataModel = result[i].dataValues;
      dataModel.items = await this.DataItemModel.findAll({ where: { dataUid: dataModel.uid } });
      dataModel.behaviors = await this.DataBehaviorModel.findAll({ where: { dataUid: dataModel.uid } });
      dataModels.push(dataModel);
    }
    return dataModels;
  }
}

