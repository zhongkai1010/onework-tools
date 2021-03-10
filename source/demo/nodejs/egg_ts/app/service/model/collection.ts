/*
 * @Author: 钟凯
 * @Date: 2021-02-13 21:03:25
 * @LastEditTime: 2021-03-11 00:17:53
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\service\model\collection.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { Service } from 'egg';
import { FindAndCountOptions, Op } from 'sequelize';
import AppError from '../../core/appError';
import AppCode from '../../core/appCode';

export default class CollectionService extends Service {
  protected CollectionModel = this.ctx.model.Data.Collection;
  protected ItemModel = this.ctx.model.Data.Item;
  protected ItemService = this.ctx.service.model.item;
  /**
   * @description 添加数据集
   * @param {*} params 参数
   * @return {*}  数据集
   */
  public async add(params:Egg.Ow.Data.Collection):Promise<Egg.Sequelize.Data.Collection> {
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
          [Op.in]: params.items.map(t => t.uid),
        },
      },
    });
    if (items.length !== params.items.length) {
      throw new AppError('该数据集中数据项数据不正确，无法进行添加！');
    }
    // 创建数据集
    const collection = await this.CollectionModel.create(params);
    // 记录数据项使用率
    for (let index = 0; index < items.length; index++) {
      const item = items[index];
      await item.plusCumulate();
    }
    return collection;
  }

  /**
   * @description 查询数据集
   * @param {*} params 查询条件
   * @return {*} 返回结果
   */
  public async query(params: any) : Promise<{rows:Egg.Sequelize.Data.Collection[], count:number}> {
    // 初始化参数
    const queryParmas = {
      order: [[ params.order || 'createdAt', (params.sort || AppCode.common.order.desc) ]],
      offset: params.limit * (params.page - 1),
      limit: params.limit,
      where: {
        [Op.or]: params.keyword ? [{
          name: {
            [Op.substring]: params.keyword,
          } }, {
          code: {
            [Op.substring]: params.keyword,
          } }] : undefined,
      },
    } as FindAndCountOptions<Egg.Sequelize.Data.Collection>;
    // 查询
    const result = await this.CollectionModel.findAndCountAll(queryParmas);
    return result;
  }

  /**
   * @description 更新数据集
   * @param {Egg} params 数据集参数
   * @return {*} 数据集
   */
  public async update(params:Egg.Sequelize.Data.Collection):Promise<Egg.Sequelize.Data.Collection> {
    // 验证数据
    let collection = await this.CollectionModel.findOne({ where: { uid: params.uid } });
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
    const oldItems = await this.ItemModel.findAll({ where: { uid: {
      [Op.in]: collection.items.map(t => t.uid) || [],
    } } });
    for (let index = 0; index < oldItems.length; index++) {
      const item = oldItems[index];
      await item.subCumulate();
    }
    // 增加新数据项计数
    const items = await this.ItemModel.findAll({
      where: {
        uid: {
          [Op.in]: params.items.map((t: { uid: any; }) => t.uid),
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
    collection.items = params.items;
    collection = await collection.save();
    // 返回结果
    return collection;
  }

  /**
   * @description 检索数据集
   * @param {object} params 搜索条件
   * @return {*} 数据集集合
   */
  public async search(params:{keyword:string}):Promise<Egg.Sequelize.Data.Collection[]> {
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
    } as FindAndCountOptions<Egg.Sequelize.Data.Collection>;
    return await this.CollectionModel.findAll(queryParmas);

  }

  /**
   * @description 移除数据项
   * @param {string} params 移除uid集合
   */
  public async remove(params:string[]):Promise<void> {
    // 查询需要删除数据
    const collections = await this.CollectionModel.findAll({
      where: {
        uid: {
          [Op.in]: params,
        },
      } });
    // 移除数据集
    const items = [] as Egg.Sequelize.Data.Item[];
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

