/*
 * @Author: 钟凯
 * @Date: 2021-02-25 14:17:14
 * @LastEditTime: 2021-03-10 23:23:57
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \egg_ts\app\service\model\dataBehavior.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { Service } from 'egg';
import { Op } from 'sequelize';
import { AppError, AppCode } from '../../core/index';

export default class DataBehaviorService extends Service {
  protected DataModel = this.ctx.model.Data.Data;
  protected DataBehaviorModel = this.ctx.model.Data.DataBehavior;
  /**
   * @description 添加数据模型行为
   * @param {*} params 参数
   * @return {*} 返回数据模型行为
   */
  public async add(params:Egg.Ow.Data.DataBehavior):Promise<Egg.Sequelize.Data.DataBehavior> {
    // 验证所属数据模型是否正常
    const dataModel = await this.DataModel.findByPk(params.dataUid);
    if (dataModel == null) throw new AppError('该指定所属的数据模型数据不存在，无法进行添加！');
    // 验证名称是否重复
    let dataBehavior = await this.DataBehaviorModel.findOne({ where: { name: params.name, dataUid: dataModel.uid } });
    if (dataBehavior === null) throw new AppError(`该数据模型中行为“${params.name}”名称已存在，无法进行添加！`);
    // 验证参数
    await this.verifyParams(params);
    // 新增数据
    dataBehavior = await this.DataBehaviorModel.create({
      dataUid: dataModel.uid,
      name: params.name,
      code: params.code,
      inputs: params.inputs,
      outputs: params.outputs,
      operationType: params.operationType,
      description: params.description,
    });
    // 返回结果
    return dataBehavior;
  }

  /**
   * @description 查询数据模型行为
   * @param {*} pageParams 分页参数
   * @param {*} queryParams 筛选参数
   * @return {*} 数据模型行为
   */
  public async query(pageParams:any, queryParams:any):Promise<{rows:Egg.Sequelize.Data.DataBehavior[], count:number}> {
    // 初始化参数
    const queryParmas = {
      order: [[ 'id', 'desc' ]],
      offset: pageParams.limit * (pageParams.page - 1),
      limit: pageParams.limit,
      where: {},
    } as any;
    // 排序
    const sort = pageParams.sort === AppCode.common.order.desc ? 'DESC' : 'ASC';
    if (pageParams.order) {
      queryParmas.order = [[ pageParams.order, sort ]];
    }
    // 条件
    for (const key in queryParams) {
      if (Object.hasOwnProperty.call(queryParams, key)) {
        queryParmas.where[key] = queryParams[key];
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
    const { count, rows } = await this.DataBehaviorModel.findAndCountAll(queryParmas);
    const datas = [] as Egg.Sequelize.Data.DataBehavior[];
    const modelUids = rows.map(t => t.uid);
    const models = await this.DataModel.findAll({ where: {
      uid: {
        [Op.in]: modelUids,
      },
    } });
    for (let i = 0; i < rows.length; i++) {
      const dataModel = rows[i];
      const model = models.find(t => t.uid === dataModel.dataUid);
      if (model) {
        dataModel.dataName = model.name;
      }
      datas.push(dataModel);
    }
    return { count, rows: datas };
  }

  /**
   * @description 修改数据模型行为
   * @param {*} params 数据模型行为
   * @return {*} 返回数据模型行为
   */
  public async update(params:Egg.Sequelize.Data.DataBehavior):Promise<Egg.Sequelize.Data.DataBehavior> {
    // 验证所属数据是否存在
    const dataBehavior = await this.DataBehaviorModel.findByPk(params.uid);
    if (!dataBehavior) throw new AppError('该数据模型的行为不存在，无法进行修改！');
    // 验证名称是否重复
    const count = await this.DataBehaviorModel.findOne({ where: { name: params.name, dataUid: dataBehavior.dataUid, uid: {
      [Op.ne]: dataBehavior.uid,
    } } });
    if (count) throw new AppError(`该数据模型中行为“${params.name}”名称已存在，无法进行修改！`);
    // 验证参数
    await this.verifyParams(params);
    // 修改数据
    dataBehavior.name = params.name;
    dataBehavior.code = params.code;
    dataBehavior.inputs = params.inputs;
    dataBehavior.outputs = params.outputs;
    dataBehavior.operationType = params.operationType;
    dataBehavior.description = params.description;
    await dataBehavior.save();
    // 返回结果
    return dataBehavior;
  }

  /**
   * @description 移除数据模型行为
   * @param {*} params 数据模型行为uid集合
   */
  public async remove(params:string[]):Promise<void> {
    // 查询需要删除数据
    const datas = await this.DataBehaviorModel.findAll({ where: {
      uid: {
        [Op.in]: params,
      },
    } });
    if (params.length !== datas.length) { throw new AppError('删除数据中存在错误参数值，无法进行删除'); }
    // 删除数据
    for (let i = 0; i < datas.length; i++) {
      const element = datas[i];
      await element.destroy();
    }
  }

  /**
   * @description 验证数据模型行为参数
   * @param {*} params 数据模型参数
   */
  protected async verifyParams(params:Egg.Sequelize.Data.DataBehavior|Egg.Ow.Data.DataBehavior): Promise<void> {
    const ctx = this.ctx;
    const DataModel = ctx.model.Data.Data;
    // 验证输入
    if (params.inputs) {
      for (let i = 0; i < params.inputs.length; i++) {
        const input = params.inputs[i];
        if (input.type === AppCode.model.itemType.array) {
          if (!input.arrayType) {
            throw new AppError('请填写输入参数中数组类型的具体类型');
          }
          if (input.arrayType === AppCode.model.itemType.object) {
            if (!input.value) {
              throw new AppError('请填写输入参数中数组类型的对象应用类型');
            }
            const dataModel = await DataModel.findByPk(input.value);
            if (dataModel == null) {
              throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
            }
          }
        }
        if (input.type === AppCode.model.itemType.object) {
          if (!input.value) {
            throw new AppError('请填写输入参数中数组类型的对象应用类型');
          }
          const dataModel = await DataModel.findByPk(input.value);
          if (dataModel == null) {
            throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
          }
        }
      }
    }
    // 验证输出
    if (params.outputs) {
      if (params.outputs.type === AppCode.model.itemType.array) {
        if (params.outputs.arrayType === AppCode.model.itemType.object) {
          if (!params.outputs.value) {
            throw new AppError('请填写输入参数中数组类型的对象应用类型');
          }
          const dataModel = await DataModel.findByPk(params.outputs.value);
          if (dataModel == null) {
            throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
          }
        }
      }
      if (params.outputs.type === AppCode.model.itemType.object) {
        if (!params.outputs.value) {
          throw new AppError('请填写输入参数中数组类型的对象应用类型');
        }
        const dataModel = await DataModel.findByPk(params.outputs.value);
        if (dataModel == null) {
          throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
        }
      }
    }
  }
}

module.exports = DataBehaviorService;
